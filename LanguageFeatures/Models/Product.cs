using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models {
    public class Product {
        //First version
        //private string name;        
        //public string Name {
        //    get { return name; }
        //    set { name = value; }
        //}

        //Second version
        //public int ProductID { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public decimal Price { get; set; }
        //public string Category { set; get; }

        //Third version
        private string name;
        public int ProductID { get; set; }
        public string Name {
            get {
                return ProductID + name;
            }
            set {
                name = value;
            }
        }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
    }
}