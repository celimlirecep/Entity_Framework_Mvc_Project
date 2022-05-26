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

    public class YayineviController : Controller
    {


        private readonly KutuphaneSabahContext _context;
        public YayineviController(KutuphaneSabahContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Yayinevleris.ToList());
        }

        public IActionResult Details(int id)
        {
            Yayinevleri yayinEviDetay = _context.Yayinevleris.Find(id);
            return View(yayinEviDetay);
        }

        public IActionResult Edit(int id)
        {


            Yayinevleri editlenecekYayinEvi = _context.Yayinevleris.Find(id);
            return View(editlenecekYayinEvi);

        }

        [HttpPost]
        public IActionResult Edit(Yayinevleri yayinevi)
        {
            if (ModelState.IsValid)
            {
                _context.Update(yayinevi);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yayinevi);
        }

        //create get
        public IActionResult Create()
        {
            return View();
        }


        //Create İşlemleri
        [HttpPost]
        public IActionResult Create(Yayinevleri yayinevi)
        {
            if (ModelState.IsValid)
            {
                System.Console.WriteLine("Burda");
                _context.Add(yayinevi);
                _context.SaveChanges();
               return RedirectToAction("Index");

            }
            else
            {
                return View(yayinevi);
            }
        }

        //Create read

        public IActionResult Delete(int id){
            Yayinevleri SilinecekYayinEvi=_context.Yayinevleris.Find(id);
            return View(SilinecekYayinEvi);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteYayinEvi(int id){
            Yayinevleri silinicekYayinEvi=_context.Yayinevleris.Find(id);
            _context.Yayinevleris.Remove(silinicekYayinEvi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}