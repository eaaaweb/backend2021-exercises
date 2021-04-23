using lesson11.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace lesson11.Controllers
{
    public class Exercise02Controller : Controller
    {
        public IActionResult Index() => View(new Interviewee {Zip = 8000, FirstInterview = DateTime.Now, SecondInterview = DateTime.Now});
        
        [HttpPost]
        public IActionResult Index(Interviewee interviewee)
        {
            if (interviewee.FirstInterview >= interviewee.SecondInterview)
            {
                ModelState.AddModelError("", ("The first interview must come before the second"));
            }
            return View(interviewee);
        }
    }
}
