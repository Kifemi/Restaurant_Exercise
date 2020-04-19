using System;
using System.Collections.Generic;
using System.Text;
using MenuManagerLibrary;
using Caliburn.Micro;
using MenuManagerLibrary.Models;

namespace MenuManagerLibrary
{
    public class DataHandler
    {
        public static List<Dish> BindableListToNormalList(BindableCollection<Dish> dishesBindable)
        {
            return new List<Dish>(dishesBindable);
        }

        public static Dish CreateNewDish(string name, string description, double price)
        {
            Dish dish = new Dish(name, description, price);
            return dish;
        }

        public static void UpdateAllDishes(MenuManager menuManager, BindableCollection<Dish> dishesBinded)
        {
            menuManager.AllDishes.Clear();
            menuManager.AllDishes.AddRange(BindableListToNormalList(dishesBinded));
            menuManager.allMenus[0].MenuDishList.Clear();
            menuManager.allMenus[0].MenuDishList.AddRange(BindableListToNormalList(dishesBinded));

        }

        public static void AddDish(MenuManager menuManager, FoodMenu menu, Dish dish)
        {
            if (!menu.MenuDishList.Contains(dish))
            {
                menu.MenuDishList.Add(dish);
            }


            if (!menuManager.AllDishes.Contains(dish))
            {
                menuManager.AllDishes.Add(dish);
            }
        }

        public static List<Allergen> UpdateDishAllergens(MenuManager menuManager, Dish dish)
        {
            List<Allergen> outputList = new List<Allergen>();
            foreach (Allergen allergen in menuManager.allAllergens)
            {
                if (dish.Allergens.Contains(allergen))
                {
                    outputList.Add(allergen);
                }
                else
                {
                    outputList.Add(null);
                }
            }

            return outputList;
        }

        public static List<bool> WhichAllergensDishContains(Dish dish)
        {
            List<bool> outputList = new List<bool>();
            foreach (Allergen allergen in dish.Allergens)
            {
                if(allergen == null)
                {
                    outputList.Add(false);
                }
                else
                {
                    outputList.Add(true);
                }
            }

            return outputList;
        }

        public static void UpdateAllergensAllDishes(MenuManager menuManager)
        {
            foreach (Dish dish in menuManager.AllDishes)
            {
                UpdateDishAllergens(menuManager, dish);
            }
        }

        public static void FillDishesWithDemoData(MenuManager menuManager)
        {

            //menuManager.allMenus.Add(new Menu("A la Carte"));
            //menuManager.allMenus.Add(new Menu("Desserts"));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Haggis", "I dare you", 15));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Vodka", "I dare you", 6.7));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Maggara", "I dare you", 4.7));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Sushi", "I dare you", 9.50));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Nakit ja muusi", "I dare you", 8.0));
            AddDish(menuManager, menuManager.allMenus[0], new Dish("Vodka", "I dare you", 6.7));
        }

        public static void CreatePresetAllergens(MenuManager menuManager)
        {
            menuManager.allAllergens.Add(new Allergen("Lactose"));
            menuManager.allAllergens.Add(new Allergen("Fish"));
            menuManager.allAllergens.Add(new Allergen("Nuts"));
        }

        public static List<AllergenBoolCombination> CombineAllergenAndBool(MenuManager menuManager, List<Allergen> allergens)
        {
            List<AllergenBoolCombination> outputList = new List<AllergenBoolCombination>();

            foreach (Allergen allergen in menuManager.allAllergens)
            {
                AllergenBoolCombination allergenBoolCombination = new AllergenBoolCombination();
                allergenBoolCombination.allergen = allergen;

                if (allergens.Contains(allergen))
                {
                    allergenBoolCombination.hasAllergen = true;
                }
                else
                {
                    allergenBoolCombination.hasAllergen = false;
                }

                outputList.Add(allergenBoolCombination);
            }

            return outputList;
        }

        //public static void SynchronizeAllergenLists(Dish dish, MenuManager menuManager)
        //{
        //    foreach (Allergen allergen in menuManager.allAllergens)
        //    {
        //        if (dish.Allergens.ContainsKey(allergen))
        //        {
        //            dish.Allergens.Add(allergen, true);
        //        }
        //        else
        //        {
        //            dish.Allergens.Add(allergen, false);
        //        }
        //    }
        //}
        
    }
}
