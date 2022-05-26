using Microsoft.AspNetCore.Mvc;
using Sales.Models.Concreate;
using Sales.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var _context = new ProductDAL();
            return View(_context.GetAll());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product!=null)
            {
                var _context = new ProductDAL();
                string imageExtension = Path.GetExtension(product.Imagefile.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/${imageName}");
                var stream = new FileStream(path, FileMode.Create);
                product.Imagefile.CopyTo(stream);
                


                _context.Add(product);
               
            }







            return RedirectToAction("Index");
        }
    }
}
