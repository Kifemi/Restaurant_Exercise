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

        public string GetDishInfo()
        {
            return ($"{this.Name} - {this.Price}€\n{this.Description}\n");
        }

        public static Dish CreateNewDish()
        {
            
            Console.WriteLine("Name of the dish: ");
            string dishName = Console.ReadLine();
            Console.WriteLine("Description of the dish: ");
            string dishDescription = Console.ReadLine();
            Console.WriteLine("Price of the dish: ");
            double dishPrice = Convert.ToDouble(Console.ReadLine());
            Dish dish = new Dish(dishName, dishDescription, dishPrice);
            return dish;

        }



    }
}
