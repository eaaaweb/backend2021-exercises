using lesson11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace lesson11.Controllers
{
    public class Exercise01Controller : Controller
    {
        public IActionResult Index() => View(new User());


        [HttpPost]
        public IActionResult Index(User user) {

            if (ModelState.IsValid) { // validation succeeded
                
                // for testing
                // return Content("Valid");
                
                return View("Completed", user);
                
            }
            else { // validation failed

                // for testing
                // return Content("Not valid");
                
                return View(user);
            }
        }

    }
}
