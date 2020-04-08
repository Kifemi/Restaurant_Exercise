using System;
using System.Collections.Generic;
using System.Text;
using MenuManagerLibrary;
using Caliburn.Micro;

namespace MenuManagerLibrary
{
    public class DataHandler
    {
        public static List<Dish> SynchronizeLists(BindableCollection<Dish> dishesBindable)
        {
            return new List<Dish>(dishesBindable);
        }

        public static Dish CreateNewDish(string name, string description, double price)
        {
            Dish dish = new Dish(name, description, price);
            return dish;
        }

        public static void AddDish(MenuManager menuManager, Menu menu, Dish dish)
        {
            if (menu == null)
            {
                if (!menuManager.Dishes.Contains(dish))
                {
                    menuManager.Dishes.Add(dish);
                }
            }
            else
            {
                if (!menu.MenuDishList.Contains(dish))
                {
                    menu.MenuDishList.Add(dish);
                }


                if (!menuManager.Dishes.Contains(dish))
                {
                    menuManager.Dishes.Add(dish);
                }
            }

        }

        public static void FillDishesWithDemoData(MenuManager menuManager)
        {

            menuManager.allMenus.Add(new Menu("A la Carte"));
            menuManager.allMenus.Add(new Menu("Desserts"));
            AddDish(menuManager, menuManager.allMenus[1], new Dish("Haggis", "I dare you", 15));
            AddDish(menuManager, menuManager.allMenus[2], new Dish("Vodka", "I dare you", 6.7));
            AddDish(menuManager, menuManager.allMenus[2], new Dish("Maggara", "I dare you", 4.7));
            AddDish(menuManager, menuManager.allMenus[1], new Dish("Sushi", "I dare you", 9.50));
            AddDish(menuManager, menuManager.allMenus[1], new Dish("Nakit ja muusi", "I dare you", 8.0));
            AddDish(menuManager, menuManager.allMenus[2], new Dish("Vodka", "I dare you", 6.7));
        }

        
    }
}
