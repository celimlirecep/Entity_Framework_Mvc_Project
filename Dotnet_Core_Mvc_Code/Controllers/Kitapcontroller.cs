using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_Core_Mvc_Code.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dotnet_Core_Mvc_Code.Controllers
{

    public class Kitapcontroller : Controller
    {

        private readonly KutuphaneSabahContext _context;

        public Kitapcontroller(KutuphaneSabahContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Kitaplars.ToList());
        }

        public IActionResult Details(string id)
        {
            var secilenKitap = _context.Kitaplars
            .Include(k => k.Tur)
            .Include(x => x.YayinEvi)
            .Include(y => y.Yazar)
            .FirstOrDefault(m => m.Isbn == id);


            return View(secilenKitap);

        }

        public IActionResult Edit(string id)
        {
            var seciliKitap = _context.Kitaplars.Find(id);
            ViewData["Tur"] = new SelectList(_context.Turlers, "Id", "TurAd", seciliKitap.TurId);
            ViewData["Yazar"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", seciliKitap.YazarId);
            ViewData["YayinEvi"] = new SelectList(_context.Yayinevleris, "Id", "Ad", seciliKitap.YayinEviId);
            return View(seciliKitap);

        }

        [HttpPost]
        public IActionResult Edit(Kitaplar kitap)
        {

            _context.Update(kitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewData["Tur"] = new SelectList(_context.Turlers, "Id", "TurAd");
            ViewData["Yazar"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad");
            ViewData["YayinEvi"] = new SelectList(_context.Yayinevleris, "Id", "Ad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kitaplar kitap)
        {

            _context.Add(kitap);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(string id){
          
            Kitaplar secilenKitap=_context.Kitaplars
            .Include(x=>x.Yazar)
            .Include(y=>y.YayinEvi)
            .Include(y=>y.Tur)
            .FirstOrDefault(z=>z.Isbn==id);
            return View(secilenKitap);
        }

        [HttpPost,ActionName("Delete")]

        public IActionResult DeleteKitap(string id){
            Kitaplar secilenKitap=_context.Kitaplars.Find(id);
            _context.Kitaplars.Remove(secilenKitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}