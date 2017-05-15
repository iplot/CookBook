using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookBook.Models
{
    public class IngredientVM
    {
        public double Amount { get; set; }
        public string Measurements { get; set; }
        public string Name { get; set; }
    }
}