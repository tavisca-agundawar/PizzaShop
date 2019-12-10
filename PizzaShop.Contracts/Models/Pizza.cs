using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShop.Contracts
{
    public class Pizza : IPizza
    {
        public Pizza(string name, string category, double price, List<Topping> toppings, string @base)
        {
            Name = name;
            Category = category;
            Price = price;
            Toppings = toppings;
            Base = @base;
            IsNonVeg = category == "Non-Vegetarian" ? true : false;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
        public bool IsNonVeg { get; set; }
        [JsonProperty(PropertyName = "toppings")]
        public List<Topping> Toppings { get; set; }
        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }
    }
}
