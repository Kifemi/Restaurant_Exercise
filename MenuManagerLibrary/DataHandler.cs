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

        //public static Dish CreateNewDish(string name, string description, double price)
        //{
        //    Dish dish = new Dish(name, description, price);
        //    return dish;
        //}

        public static void UpdateAllDishes(MenuManager menuManager, BindableCollection<Dish> dishesBinded)
        {
            menuManager.AllDishes.Clear();
            menuManager.AllDishes.AddRange(BindableListToNormalList(dishesBinded));
            //menuManager.allMenus[0].MenuDishList.Clear();
            //menuManager.allMenus[0].MenuDishList.AddRange(BindableListToNormalList(dishesBinded));

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

        public static void FillDishesWithDemoData(MenuManager menuManager)
        {

            menuManager.allMenus.Add(new FoodMenu("A la Carte"));
            menuManager.allMenus.Add(new FoodMenu("Desserts"));
            AddDish(menuManager, menuManager.allMenus[1], new Dish("Haggis", "I dare you", 15));
            AddDish(menuManager, menuManager.allMenus[1], new Dish("Vodka", "I dare you", 6.7));
            AddDish(menuManager, menuManager.allMenus[1], new Dish("Maggara", "I dare you", 4.7));
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

        public static void UpdateDishAllergens(List<AllergenBoolCombination> combinationList, Dish dish)
        {
            List<Allergen> dishAllergensUpdated = new List<Allergen>();

            foreach (AllergenBoolCombination allergenBool in combinationList)
            {
                if (allergenBool.hasAllergen == true)
                {
                    dishAllergensUpdated.Add(allergenBool.allergen);
                }
            }

            dish.Allergens = dishAllergensUpdated;
        }
       
        
    }
}
