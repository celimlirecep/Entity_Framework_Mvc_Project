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

    public class TurController : Controller
    {

        private readonly KutuphaneSabahContext _context;

        public TurController(KutuphaneSabahContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Turlers.ToList());
        }
            //get detay
        public IActionResult Details(int id)
        {
            var tur = _context.Turlers.Find(id);
            return View(tur);
        }
        //Düzenlenecek kitap türü bilgileri Gösterilecek
        public IActionResult Edit(int id)
        {
            var tur = _context.Turlers.Find(id);
            return View(tur);
        }

        [HttpPost]
        public IActionResult Edit(Turler tur)
        {
            if (ModelState.IsValid)
            {
                _context.Update(tur);//Bu satır sadece contextimimi güncelledi
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tur);
        }
          //Silinecek kitap türü bilgileri Gösterilecek
        public IActionResult Delete(int id)
        {
            Turler tur = _context.Turlers.Find(id);
            return View(tur);
        }
            //delete veremedik overload bozulmasın diye
        [HttpPost,ActionName("delete")]
        public IActionResult DeleteConfirmed(int id){
            Turler silinecekKitapTuru=_context.Turlers.Find(id);
            _context.Turlers.Remove(silinecekKitapTuru);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
      
        public IActionResult Create(){

            return View();
        }

          [HttpPost]
          public IActionResult Create(Turler tur){
              _context.Add(tur);
              _context.SaveChanges();
              return RedirectToAction("Index");
          }


    }
}