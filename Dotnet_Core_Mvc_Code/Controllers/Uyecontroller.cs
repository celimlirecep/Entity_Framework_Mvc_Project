using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_Core_Mvc_Code.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dotnet_Core_Mvc_Code.Controllers
{

    public class Uyecontroller : Controller
    {


        private readonly KutuphaneSabahContext _context;
        public Uyecontroller(KutuphaneSabahContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Uyelers.ToList());
        }

        public IActionResult Details(int id)
        {
            Uyeler getUye = _context.Uyelers.Find(id);
            return View(getUye);
        }

        //delete get

        public IActionResult Delete(int id)
        {
            Uyeler getUye = _context.Uyelers.Find(id);
            return View(getUye);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteUye(int id)
        {
            Uyeler getUye = _context.Uyelers.Find(id);
            _context.Uyelers.Remove(getUye);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            Uyeler getUye = _context.Uyelers.Find(id);
            return View(getUye);
        }


    }
}