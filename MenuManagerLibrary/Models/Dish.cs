using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace MenuManagerLibrary
{
    public class Dish
    {
        private string _name;
        private string _description;
        private double _price;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }


        /// <summary>
        /// Constructor for the dish
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        public Dish(string name, string description, double price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        
        public override string ToString()
        {
            return ($"{this.Name} - {this.Price}€\n{this.Description}\n");
        }

       
        //public string GetDishInfo()
        //{
        //    return ($"{this.Name} - {this.Price}€\n{this.Description}\n");
        //}

        //public static Dish CreateNewDish()
        //{
            
        //    Console.WriteLine("Name of the dish: ");
        //    string dishName = Console.ReadLine();
        //    Console.WriteLine("Description of the dish: ");
        //    string dishDescription = Console.ReadLine();
        //    Console.WriteLine("Price of the dish: ");
        //    double dishPrice = Convert.ToDouble(Console.ReadLine());
        //    Dish dish = new Dish(dishName, dishDescription, dishPrice);
        //    return dish;

        //}

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if(!(obj is Dish))
            {
                return false;
            }

            if (this.Name == ((Dish)obj).Name)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

    }
}
