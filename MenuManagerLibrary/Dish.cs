using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary
{
    public class Dish
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Dish(string name, string description, double price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }



    }
}
