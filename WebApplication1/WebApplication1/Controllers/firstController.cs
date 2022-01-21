using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DBContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class firstController : Controller
    {
        shoppingcartContext _shoppingcartContext;

        public firstController(shoppingcartContext shoppingcartContext)
        {
            _shoppingcartContext = shoppingcartContext;
        }
        public IActionResult abc()
        {
            List<Category> l_data = _shoppingcartContext.Categories.ToList();

            return View(l_data);
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(Category category)
        {
            if (ModelState.IsValid)
            {
                _shoppingcartContext.Categories.Add(category);
                _shoppingcartContext.SaveChanges();
                return RedirectToAction("abc");
            }


            return View();
        }


        public IActionResult Edit(int CategoryId)
        {
            Category l_data = _shoppingcartContext.Categories.Where(m => m.CategoryId == CategoryId).FirstOrDefault();

            return View(l_data);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                Category l_data = _shoppingcartContext.Categories.Where(m => m.CategoryId == category.CategoryId).FirstOrDefault();

                l_data.Name = category.Name;

                _shoppingcartContext.Categories.Update(l_data);
                _shoppingcartContext.SaveChanges();
                return RedirectToAction("abc");
            }


            return View();
        }
    }
}
