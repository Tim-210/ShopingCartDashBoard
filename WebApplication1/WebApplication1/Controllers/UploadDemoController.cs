using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    public class UploadDemoController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadDemoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(IFormFile file)
        {
            //var files = Request.Form.Files;


            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            long fileSize = 0;


            if (file.Length > 0)

            {
                string fileExt = Path.GetExtension(file.FileName); //副檔名，不含“.”

                fileSize = file.Length; //獲得檔案大小，以位元組為單位

                string newFileName = Guid.NewGuid().ToString()  + fileExt; //隨機生成新的檔名

                //最終的完整儲存路徑
                var filePath = webRootPath + "/upload/" + newFileName;

                var fileFolderPath = webRootPath + "/upload";
                if (!System.IO.Directory.Exists(fileFolderPath))
                {
                    System.IO.Directory.CreateDirectory(fileFolderPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return Ok(new { fileSize });
        }

        //public class FileViewModel
        //{
        //    public IFormFile file { get; set; }
        //}
    }
}
