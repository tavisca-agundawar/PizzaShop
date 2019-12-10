using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public class Topping : ITopping
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
        public bool IsNonVeg { get; set; }
        public Topping(string name, string category, double price)
        {
            Name = name;
            Category = category;
            Price = price;
            IsNonVeg = category == "Non-Vegetarian" ? true : false;
        }
    }
}
