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

            //Dish dish = new Dish("Haggis", "I dare you", 15);

            //Console.WriteLine(dish.GetDishInfo());

            //menu.AddDish(dish);

            //menu.AddDishToCategory(dish);

            //menu.PrintMenu();

            List<double> list = new List<double>();

            list.Add(5);
            list.Add(25.3);
            list.Add(-235);
            list.Add(0);
            list.Add(100);
            list.Add(25.7);
            list.Insert(3, 32);
            List<double> sortedList = (Utilities.SortListDouble(list));

            foreach (double number in sortedList)
            {
                Console.WriteLine(number);
            }
            

        }
    }
}
