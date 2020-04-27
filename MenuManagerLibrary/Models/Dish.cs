using System;
using System.Collections.Generic;
//using System.Text;
//using Caliburn.Micro;
using MenuManagerLibrary.Models;

namespace MenuManagerLibrary
{
    public class Dish
    {
        private int _dishId;
        private string _name;
        private string _description;
        private decimal _price;
        private List<Allergen> _allergens;

        public List<Allergen> Allergens
        {
            get { return _allergens; }
            set { _allergens = value; }
        }

        public int DishId
        {
            get { return _dishId; }
            set { _dishId = value; }
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

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }


        // Constructor for the Dish
        public Dish(string name, string description, decimal price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Allergens = new List<Allergen>();
        }

        public Dish(int DishId, string name, string description, decimal price)
        {
            this.DishId = DishId;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Allergens = new List<Allergen>();
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
