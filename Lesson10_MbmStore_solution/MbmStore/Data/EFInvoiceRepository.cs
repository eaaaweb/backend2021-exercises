using MbmStore.Models;
using MbmStore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MbmStore.Data
{
    public class EFInvoiceRepository : IInvoiceRepository
    {
        private readonly MbmStoreContext dataContext;
        public EFInvoiceRepository(MbmStoreContext context)
        {
            dataContext = context;
        }

        public void SaveInvoice(Cart cart, Order order)
        {
            // order processing logic
            Customer customer = new Customer
            {
                Firstname = order.Firstname,
                Lastname = order.Lastname,
                Address = order.Line1 + " " + order.Line2 + " " + order.Line3,
                City = order.City,
                Zip = order.Zip,
                Email = order.Email
            };

            if (dataContext.Customers.Any(c => c.Firstname == customer.Firstname && c.Lastname == customer.Lastname && c.Email == customer.Email))
            {
                customer = dataContext.Customers.Where(c => c.Firstname ==
               customer.Firstname && c.Lastname == customer.Lastname && c.Email == customer.Email).First();
                customer.Address = order.Line1 + " " + order.Line2 + " " + order.Line3;
                customer.Zip = order.Zip;
                // ensure update instead of insert
                dataContext.Entry(customer).State = EntityState.Modified;
            }
            Invoice invoice = new Invoice { Customer = customer, OrderDate = DateTime.Now };


            foreach (CartLine cartLine in cart.Lines)
            {
                OrderItem orderItem = new OrderItem(cartLine.Product, cartLine.Quantity);
                orderItem.ProductId = cartLine.Product.ProductId;
                orderItem.Product = null;
                invoice.OrderItems.Add(orderItem);
            }
            // Save to data store
            dataContext.Invoices.Add(invoice);
            dataContext.SaveChanges();
            cart.Clear();
        }
    }
}
