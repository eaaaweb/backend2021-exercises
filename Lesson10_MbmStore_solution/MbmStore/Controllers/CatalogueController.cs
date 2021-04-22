using MbmStore.Infrastructure;
using MbmStore.Models.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MbmStore.Data;
using System.Collections.Generic;
using MbmStore.Models;

namespace MbmStore.Controllers
{
    public class CatalogueController : Controller
    {
        private MbmStoreContext dataContext;

        public int PageSize = 4;

        public CatalogueController(MbmStoreContext dbContext)
        {
            dataContext = dbContext;
        }


        // GET: Catalogue
        public ActionResult Index(string category, int page = 1)
        {

            // Queries to include tracks
            IEnumerable<Product> music = dataContext.Products.OfType<MusicCD>().Include(m => m.Tracks);
            IEnumerable<Product> books = dataContext.Products.OfType<Book>();
            IEnumerable<Product> movies = dataContext.Products.OfType<Movie>();

            IEnumerable<Product> products = music.Union(books).Union(movies).ToList();
                
                

            ProductsListViewModel model = new ProductsListViewModel();
            model = new ProductsListViewModel
            {
                Products = products
                .OrderBy(p => p.ProductId)
                .Where(p => category == null || p.Category == category)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    dataContext.Products.Count() :
                    dataContext.Products.Where(e =>
                    e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}
