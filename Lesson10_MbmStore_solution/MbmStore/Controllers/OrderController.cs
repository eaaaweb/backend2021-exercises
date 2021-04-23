using MbmStore.Data;
using MbmStore.Models;
using MbmStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MbmStore.Controllers
{
    public class OrderController : Controller
    {
        private Cart cart;
        private IInvoiceRepository invoiceRepo;


        public OrderController(Cart cartService, IInvoiceRepository invoiceRepo)
        {
            cart = cartService;
            this.invoiceRepo = invoiceRepo;
        }

        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                invoiceRepo.SaveInvoice(cart, order);
                
                return View("Completed");

            }
            else
            {
                return View(order);
            }
        }
    }
}