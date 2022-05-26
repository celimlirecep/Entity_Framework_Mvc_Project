using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_Core_Mvc_Code.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Dotnet_Core_Mvc_Code.Controllers
{

    public class OduncController : Controller
    {
       private readonly KutuphaneSabahContext _context;
       public OduncController(KutuphaneSabahContext context){
           _context=context;
       }

        public IActionResult Index()
        {  var odunc= _context.Oduncs
            .Include(x=>x.Uye)
            .Include(y=>y.KitapIsbnNavigation);
         
            return View(odunc.ToList());
        }
        

       
    }
}