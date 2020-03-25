using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary
{
    public class Dish : IEquatable<Dish>, IComparable<Dish>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

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

        //=====================================================================================
        //Modifying Sort()- method 
        //=====================================================================================
        public override string ToString()
        {
            return ($"{this.Name} - {this.Price}€\n{this.Description}\n");
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Dish objAsPart = obj as Dish;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public int SortByNameAscending(string name1, string name2)
        {

            return name1.CompareTo(name2);
        }

        // Default comparer for Part type.
        public int CompareTo(Dish comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;

            else
                return this.Price.CompareTo(comparePart.Price);
        }
        public override int GetHashCode()
        {
            return Convert.ToInt32(Price);
        }
        public bool Equals(Dish other)
        {
            if (other == null) return false;
            return (this.Price.Equals(other.Price));
        }
        // Should also override == and != operators.

        //=====================================================================================
        //=====================================================================================


        //public string GetDishInfo()
        //{
        //    return ($"{this.Name} - {this.Price}€\n{this.Description}\n");
        //}

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
