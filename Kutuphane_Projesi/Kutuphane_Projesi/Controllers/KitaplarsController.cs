using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kutuphane_Projesi.Models;

namespace Kutuphane_Projesi.Controllers
{
    public class KitaplarsController : Controller
    {
        private readonly KutuphaneSabahContext _context;

        public KitaplarsController(KutuphaneSabahContext context)
        {
            _context = context;
        }

        // GET: Kitaplars
        public async Task<IActionResult> Index()
        {
            var kutuphaneSabahContext = _context.Kitaplars.Include(k => k.Tur).Include(k => k.YayinEvi).Include(k => k.Yazar);
            return View(await kutuphaneSabahContext.ToListAsync());
        }

        // GET: Kitaplars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars
                .Include(k => k.Tur)
                .Include(k => k.YayinEvi)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (kitaplar == null)
            {
                return NotFound();
            }

            return View(kitaplar);
        }

        // GET: Kitaplars/Create
        public IActionResult Create()
        {
            ViewData["TurId"] = new SelectList(_context.Turlers, "Id", "TurAd");
            ViewData["YayinEviId"] = new SelectList(_context.Yayinevleris, "Id", "Ad");
            ViewData["YazarId"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad");
            return View();
        }

        // POST: Kitaplars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Isbn,Ad,SayfaSayisi,Stok,TurId,YazarId,YayinEviId")] Kitaplar kitaplar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitaplar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurId"] = new SelectList(_context.Turlers, "Id", "TurAd", kitaplar.TurId);
            ViewData["YayinEviId"] = new SelectList(_context.Yayinevleris, "Id", "Ad", kitaplar.YayinEviId);
            ViewData["YazarId"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", kitaplar.YazarId);
            return View(kitaplar);
        }

        // GET: Kitaplars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars.FindAsync(id);
            if (kitaplar == null)
            {
                return NotFound();
            }
            ViewData["TurId"] = new SelectList(_context.Turlers, "Id", "TurAd", kitaplar.TurId);
            ViewData["YayinEviId"] = new SelectList(_context.Yayinevleris, "Id", "Ad", kitaplar.YayinEviId);
            ViewData["YazarId"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", kitaplar.YazarId);
            return View(kitaplar);
        }

        // POST: Kitaplars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Isbn,Ad,SayfaSayisi,Stok,TurId,YazarId,YayinEviId")] Kitaplar kitaplar)
        {
            if (id != kitaplar.Isbn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitaplar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitaplarExists(kitaplar.Isbn))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurId"] = new SelectList(_context.Turlers, "Id", "TurAd", kitaplar.TurId);
            ViewData["YayinEviId"] = new SelectList(_context.Yayinevleris, "Id", "Ad", kitaplar.YayinEviId);
            ViewData["YazarId"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", kitaplar.YazarId);
            return View(kitaplar);
        }

        // GET: Kitaplars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitaplar = await _context.Kitaplars
                .Include(k => k.Tur)
                .Include(k => k.YayinEvi)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.Isbn == id);
            if (kitaplar == null)
            {
                return NotFound();
            }

            return View(kitaplar);
        }

        // POST: Kitaplars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var kitaplar = await _context.Kitaplars.FindAsync(id);
            _context.Kitaplars.Remove(kitaplar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitaplarExists(string id)
        {
            return _context.Kitaplars.Any(e => e.Isbn == id);
        }
    }
}
