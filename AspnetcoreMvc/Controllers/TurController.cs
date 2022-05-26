using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspnetcoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspnetcoreMvc.Controllers
{

    public class TurController : Controller
    {
        private readonly KutuphaneSabahContext _context;
        public TurController(KutuphaneSabahContext context)
        {
            _context=context;
            //Bu aşamadan sonra _context değişkeni benim modelimi temsil ediyor olmuş olacak
        }

        //Get Kitap Turleri Listeler
        public IActionResult Index()
        {
            return View(_context.Turlers.ToList());
        }
        
        //Get Kitap TürüDetayını göster

        public IActionResult Details(int id){

            var tur=_context.Turlers.Find(id);
            return View(tur);
        }

       
    }
}