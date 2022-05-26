using DatabaseImageProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseImageProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly DatabaseImageProjectContext _context;
        public HomeController(DatabaseImageProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product!=null)
            {
                string imageExtension = Path.GetExtension(product.file.FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/${imageName}");
                var stream = new FileStream(path, FileMode.Create);
                product.file.CopyTo(stream);
                product.ImagePath=$"/images/${imageName}";
                _context.Add(product);
                _context.SaveChanges();

            }
            
            return RedirectToAction("Index");
        }

        

        
    }
}
