using System;
using MenuManagerLibrary;
using System.Collections.Generic;

namespace MenuManagerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Menu menu = new Menu("A la Carte - menu ");
            //menu.SetPresetCategories();
            List<Dish> dishes = new List<Dish>();
            dishes.Add(new Dish("Haggis", "I dare you", 15));
            dishes.Add(new Dish("Maggara", "I dare you", 14.54));
            dishes.Add(new Dish("sgwgwgw", "I dare you", 43));
            dishes.Add(new Dish("sushi", "I dare you", 3));

            dishes.Sort();

            foreach (Dish dish in dishes)
            {
                Console.WriteLine(dish);
            }

            dishes.Sort(delegate (Dish x, Dish y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });

            Console.WriteLine("After sort be name");
            foreach (Dish dish in dishes)
            {
                Console.WriteLine(dish);
            }

            //Console.WriteLine(dish.GetDishInfo());

            //menu.AddDish(dish);

            //menu.AddDishToCategory(dish);

            //menu.PrintMenu();

            //List<double> list = new List<double>();

            //list.Add(5);
            //list.Add(25.3);
            //list.Add(-235);
            //list.Add(0);
            //list.Add(100);
            //list.Add(25.7);
            //list.Insert(3, 32);
            //List<double> sortedList = (Utilities.SortListDouble(list));

            //foreach (double number in sortedList)
            //{
            //    Console.WriteLine(number);
            //}

            //foreach(double number in list)
            //{
            //    Console.WriteLine(number);
            //}


        }
    }
}
