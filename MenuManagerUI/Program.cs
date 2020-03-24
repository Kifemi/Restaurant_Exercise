using System;
using MenuManagerLibrary;

namespace MenuManagerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu menu = new Menu("A la Carte - menu ");
            menu.SetPresetCategories();

            Dish dish = new Dish("Haggis", "I dare you", 15);

            Console.WriteLine(dish.GetDishInfo());

            menu.AddDish(dish);

            menu.AddDishToCategory(dish);
                
            menu.PrintMenu();

        }
    }
}
