﻿using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers {
    public class HomeController : Controller {
        public string Index() {            
            return "Navigate to a URL to show an example";
        }
        public ViewResult AutoProperty() {
            // создается новый объект Product
            Product myProduct = new Product();
            // устанавливается значение свойства
            myProduct.Name = "Kayak";
            // читается свойство
            string productName = myProduct.Name;
            // генерируется представление
            return View("Result",
            (object)String.Format("Product name: {0}", productName));
        }
        public ViewResult CreateProduct() {
            // создание нового объекта Product
            Product myProduct = new Product();
            // установка значений свойств
            myProduct.ProductID = 100;
            myProduct.Name = "Kayak"; 
            myProduct.Description = "A boat for one person";
            myProduct.Price = 275M;
            myProduct.Category = "Watersports";
            return View("Result",
            (object)String.Format("Category: {0}", myProduct.Category));
        }
        public ViewResult CreateCollection() {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int> {
            { "apple", 10 }, { "orange", 20 }, { "plum", 30 }};
            return View("Result", (object)stringArray[1]);
        }
        public ViewResult UseExtension() {
            // создание и заполнение ShoppingCart
            ShoppingCart cart = new ShoppingCart {
                Products = new List<Product> {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
                }
            };
            // получение общей стоимости продуктов в корзине
            decimal cartTotal = cart.TotalPrices();
            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }
        public ViewResult UseExtensionEnumerable() {
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
                }
            };
            // создание и заполнение массива объектов Product
            Product[] productArray = {
            new Product {Name = "Kayak", Price = 275M},
            new Product {Name = "Lifejacket", Price = 48.95M},
            new Product {Name = "Soccer ball", Price = 19.50M},
            new Product {Name = "Corner flag", Price = 34.95M}
            };
            // получение общей стоимости продуктов в корзине
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            return View("Result",
            (object)String.Format("Cart Total: {0}, Array Total: {1}",
            cartTotal, arrayTotal));
        }
        public ViewResult UseFilterExtensionMethod() {
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                    }
            };
            decimal total = 0;
            foreach (Product prod in products.FilterByCategory("Soccer")) {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
        public ViewResult UseFilterExtensionMethod1() {
            // создаем и заполняем ShoppingCart
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                    }
            };
            Func<Product, bool> categoryFilter = delegate (Product prod) {
                return prod.Category == "Soccer";
            };
            decimal total = 0;
            foreach (Product prod in products.Filter(categoryFilter)) {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
        public ViewResult UseFilterExtensionMethod2() {
            // создаем и заполняем ShoppingCart
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                    }
            };
            Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";
            decimal total = 0;
            foreach (Product prod in products.Filter(categoryFilter)) {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
        public ViewResult UseFilterExtensionMethod3() {
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                    }
            };
            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer")) {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
        public ViewResult UseFilterExtensionMethod4() {
            IEnumerable<Product> products = new ShoppingCart {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                    }
            };
            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20)) {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0}", total));
        }
        public ViewResult CreateAnonArray() {
            var oddsAndEnds = new[] {
                new { Name = "MVC", Category = "Pattern"},
                new { Name = "Hat", Category = "Clothing"},
                new { Name = "Apple", Category = "Fruit"}
                };
            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds) {
                result.Append(item.Name).Append(" ");
            }
            return View("Result", (object)result.ToString());
        }
        public ViewResult FindProducts() {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                };
            // определяем массив для результатов
            Product[] foundProducts = new Product[3];
            // сортируем содержание массива
            Array.Sort(products, (item1, item2) =>
            {
                return Comparer<decimal>.Default.Compare(item1.Price, item2.Price);
            });
            // получаем три первых элемента массива в качестве результата
            Array.Copy(products, foundProducts, 3);
            // создаем результат
            StringBuilder result = new StringBuilder();
            foreach (Product p in foundProducts) {
                result.AppendFormat("Price: {0} ", p.Price);
            }
            return View("Result", (object)result.ToString());
        }
        public ViewResult FindProducts1() {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                };
            var foundProducts = from match in products
                                orderby match.Price descending
                                select new {
                                    match.Name,
                                    match.Price
                                };
            // создаем результат
            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts) {               
            result.AppendFormat("Price: {0} ", p.Price);
                if (++count == 3) {
                    break;
                }
            }
            return View("Result", (object)result.ToString());
        }
        public ViewResult FindProducts2() {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                };
            var foundProducts = products.OrderByDescending(e => e.Price)
            .Take(3)
            .Select(e => new {
                e.Name,
                e.Price
            });
            // adding array data after linq querry. and it counts!!!
            products[2] = new Product { Name = "Stadium", Price = 79600M };

            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts) {
                result.AppendFormat("Price: {0} ", p.Price);
            }
            return View("Result", (object)result.ToString());
        }
        public ViewResult SumProducts() {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                };
            var results = products.Sum(e => e.Price);
            products[2] = new Product { Name = "Stadium", Price = 79500M };
            return View("Result", (object)String.Format("Sum: {0:c}", results));
        }
    }
}
