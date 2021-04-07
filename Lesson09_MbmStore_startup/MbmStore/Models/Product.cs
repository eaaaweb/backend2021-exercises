using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MbmStore.Models {

    public class Product {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public string Category { get; set; }


        // constructor
        public Product() { }

        // constructor
        public Product(int productID, string title, decimal price) {
            ProductID = productID;
            Title = title;
            Price = price;
        }
    }
}