using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormsAppPractice.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { Id = 1, Name = "Telefon"});
            _categories.Add(new Category { Id = 2, Name = "Bilgisayar"});

            _products.Add(new Product { Id = 1, Name = "IPhone 14", Price = 40000, IsActive = true, Image = "1.jpg", CategoryId = 1});
            _products.Add(new Product { Id = 2, Name = "IPhone 15", Price = 50000, IsActive = true, Image = "2.jpg", CategoryId = 1});
            _products.Add(new Product { Id = 3, Name = "IPhone 16", Price = 60000, IsActive = true, Image = "3.jpg", CategoryId = 1});
            _products.Add(new Product { Id = 4, Name = "IPhone 17", Price = 70000, IsActive = true, Image = "4.jpg", CategoryId = 1});

            _products.Add(new Product { Id = 5, Name = "Macbook Air", Price = 80000, IsActive = true, Image = "5.jpg", CategoryId = 2});
            _products.Add(new Product { Id = 6, Name = "MAcbook Pro", Price = 90000, IsActive = true, Image = "6.jpg", CategoryId = 2});


        }


        public static List<Product> GetProducts{
            get {
                return _products;
            }
        }

        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public static List<Category> GetCategories{
            get {
                return _categories;
            }
        }

    }
}