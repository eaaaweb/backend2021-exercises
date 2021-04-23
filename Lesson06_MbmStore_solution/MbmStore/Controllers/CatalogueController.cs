using MbmStore.Infrastructure;
using MbmStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MbmStore.Controllers
{
    public class CatalogueController : Controller
    {
        // GET: Catalogue
        public IActionResult Index()
        {
            return View(Repository.Products);
            
        }
    }
}