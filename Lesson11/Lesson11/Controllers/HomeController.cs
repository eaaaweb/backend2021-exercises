using Microsoft.AspNetCore.Mvc;

namespace lesson11.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public IActionResult Index()
        {
            return View();
        }

    }
}
