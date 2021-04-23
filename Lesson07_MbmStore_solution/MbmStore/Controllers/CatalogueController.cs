using MbmStore.Infrastructure;
using MbmStore.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MbmStore.Controllers
{
    public class CatalogueController : Controller
    {
        public int PageSize = 4;

        // GET: Catalogue
        public ActionResult Index(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel();
            model = new ProductsListViewModel
            {
                Products = Repository.Products
                .OrderBy(p => p.ProductID)
                .Where(p => category == null || p.Category == category)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    Repository.Products.Count() :
                    Repository.Products.Where(e =>
                    e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
