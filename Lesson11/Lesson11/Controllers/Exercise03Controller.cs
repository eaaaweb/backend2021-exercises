using lesson11.Models;
using Microsoft.AspNetCore.Mvc;

namespace lesson11.Controllers
{
    public class Exercise03Controller : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Index(User user) {
           return View(user);
       }

    }
}
