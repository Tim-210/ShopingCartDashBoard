using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DBContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        shoppingcartContext _shoppingcartContext;

        public ProductController(shoppingcartContext shoppingcartContext)
        {
            _shoppingcartContext = shoppingcartContext;
        }
        public IActionResult Index()
        {
            List<Product> l_data = _shoppingcartContext.Products.Include(m => m.Category).ToList();

            return View(l_data);
        }
    }
}
