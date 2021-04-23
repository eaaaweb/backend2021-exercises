using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MbmStore.Models.ViewModels;

namespace MbmStore.Data
{
    public interface IInvoiceRepository
    {
        void SaveInvoice(Cart cart, Order order);
    }
}
