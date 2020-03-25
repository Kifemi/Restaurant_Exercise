using System;
using MenuManagerLibrary;
using System.Collections.Generic;

namespace MenuManagerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Menu menu = new Menu("A la Carte - menu ");
            menu.SetPresetCategories();
            List<Dish> dishes = new List<Dish>();
            menu.Categories[1].ListOfDishes.Add(new Dish("Haggis", "I dare you", 15));
            menu.Categories[1].ListOfDishes.Add(new Dish("vodka", "I dare you", 6.7));
            menu.Categories[1].ListOfDishes.Add(new Dish("Maggara", "I dare you", 14.54));
            menu.Categories[3].ListOfDishes.Add(new Dish("sgwgwgw", "I dare you", 43));
            menu.Categories[0].ListOfDishes.Add(new Dish("sushi", "I dare you", 3));


            List<Dish> fullListOfDishes = menu.CombineCategoriesToList();
            Menu.PrintMenuAlphabeticalOrder(fullListOfDishes);
            Console.WriteLine("================");
            Menu.PrintMenuPriceOrder(fullListOfDishes);
            Console.WriteLine("================");
            menu.PrintMenuCategoryOrder();

            //Console.WriteLine("Welcome to Menu Manager: ");
            //while (true)
            //{
            //    Console.WriteLine("Commands: \n" +
            //        "\t create\n" +
            //        "\t print\n" +
            //        "\t help\n" +
            //        "\t exit");
            //    string input = Utilities.TrimInput();

            //    if (input.Equals("create"))
            //    {
            //        Console.WriteLine("Commands: \n" +
            //            "\t menu\n" +
            //            "\t category\n" +
            //            "\t dish\n" +
            //            "\t back");

            //        string inputAddPhase = Utilities.TrimInput();

            //        if (inputAddPhase.Equals("menu"))
            //        {
            //            //CreateMenu();
            //        }
            //        if (inputAddPhase.Equals("category"))
            //        {
            //            //CreateCategory();
            //        }
            //        if (inputAddPhase.Equals("dish"))
            //        {
            //            //CreateDish();
            //        }
            //        if (inputAddPhase.Equals("back"))
            //        {
            //            continue;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Invalid input");
            //            continue;
            //        }

            //    }

            //    if (input.Equals("print"))
            //    {
            //        Console.WriteLine("Commands: \n" +
            //        "\t abc --- Prints the menu in alphabetical order\n" +
            //        "\t 123 --- Prints the menu from the cheapest dish to the most expensive dish\n" +
            //        "\t cate --- Prints the menu, one category at the time\n" +
            //        "\t back");

            //        string inpoutPrintPhase = Utilities.TrimInput();

            //        if (inpoutPrintPhase.Equals("back"))
            //        {
            //            continue;
            //        }
            //        if (inpoutPrintPhase.Equals("abs"))
            //        {
            //            //PrintMenuAlphabeticalOrder();
            //        }
            //        if (inpoutPrintPhase.Equals("123"))
            //        {
            //            //PrintMenuPriceOrder();
            //        }
            //        if (inpoutPrintPhase.Equals("cate"))
            //        {
            //            //PrintMenuCategoryOrder();
            //        }
            //        else
            //        {
            //            Console.WriteLine("Invalid input");
            //            continue;
            //        }
            //    }

            //    if (input.Equals("exit"))
            //    {
            //        Console.WriteLine("Thank you, welcome again");
            //        break;
            //    }


            //}






        }
    }
}
