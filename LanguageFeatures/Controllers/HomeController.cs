using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}