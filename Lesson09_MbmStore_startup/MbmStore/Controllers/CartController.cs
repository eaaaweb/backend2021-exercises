using MbmStore.Infrastructure;
using MbmStore.Models;
using MbmStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MbmStore.Controllers
{
    public class CartController : Controller
    {
        private Cart cart;

        public CartController(Cart cartService)
        {
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productID, string returnUrl)
        {
            Product product = Repository.Products
            .FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productID, string returnUrl)
        {
            Product product = Repository.Products
            .FirstOrDefault(p => p.ProductID == productID);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
