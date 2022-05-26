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

    public class YazarController : Controller
    {
  

       private readonly KutuphaneSabahContext _context;
       public YazarController(KutuphaneSabahContext context){
           _context=context;
       }

        public IActionResult Index()
        {
            return View(_context.Yazarlars.ToList());
        }

    
     
    }
}