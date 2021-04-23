using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbmStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MbmStore.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {

            // create a new Movie object with instance name jungleBook
            var jungleBook = new Movie("Jungle Book", 160.50m, "junglebook.jpg");

            // assign a ViewBag property to the new Movie object
            ViewBag.JungleBook = jungleBook;

            // return the default view
            return View();
        }
    }
}