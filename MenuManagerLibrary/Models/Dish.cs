using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary.Models;
using System.Linq;

namespace MenuManagerLibrary
{
    public class Dish
    {
        private string _name;
        private string _description;
        private double _price;
        private Dictionary<Allergen, bool> _allergens;

        public Dictionary<Allergen, bool> Allergens
        {
            get { return _allergens; }
            set { _allergens = value; }
        }


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


        // Constructor for the Dish
        public Dish(string name, string description, double price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Allergens = new Dictionary<Allergen, bool>();
        }


        // Overrides
        
        public override string ToString()
        {
            return ($"{this.Name} - {this.Price}€\n{this.Description}\n");
        }

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
