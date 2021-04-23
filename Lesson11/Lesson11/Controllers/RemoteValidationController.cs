using lesson11.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace lesson11.Controllers
{


    public class RemoteValidationController : Controller
    {
        public JsonResult UniqueUserName(string username)
        {
            if (!Users.UsernameIsUnique(username))
            {
                return Json("The username is already taken (ajax)");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
