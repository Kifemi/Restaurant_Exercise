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

        public static void UpdateAllDishes(MenuManager menuManager, BindableCollection<Dish> dishesBinded)
        {
            menuManager.AllDishes.Clear();
            menuManager.AllDishes.AddRange(new List<Dish>(dishesBinded));
        }

        public static void UpdateAllCategories(FoodMenu menu, BindableCollection<Category> categoriesBinded)
        {
            menu.Categories.Clear();
            menu.Categories.AddRange(new List<Category>(categoriesBinded));
        }

        public static BindableCollection<Dish> UpdateBindableCollectionDish(List<Dish> list)
        {
            BindableCollection<Dish> output = new BindableCollection<Dish>(list);
            return output;
        }

        //public static BindableCollection<Category> UpdateBindableCollectionCategory(List<Category> list)
        //{
        //    BindableCollection<Category> output = new BindableCollection<Category>(list);
        //    return output;
        //}

        public static List<Dish> UpdateMenuDishList(FoodMenu menu)
        {
            List<Dish> output = new List<Dish>();

            foreach (Category category in menu.Categories)
            {
                foreach (Dish dish in category.ListOfDishes)
                {
                    if(output.Contains(dish) == false)
                    {
                        output.Add(dish);
                    }
                }
            }

            return output;
        }

        public static void AddDish(MenuManager menuManager, FoodMenu menu, Dish dish)
        {
            if (menu.Categories[0].ListOfDishes.Contains(dish) == false)
            {
                menu.Categories[0].ListOfDishes.Add(dish);
            }


            if (menuManager.AllDishes.Contains(dish) == false)
            {
                menuManager.AllDishes.Add(dish);
            }
        }

        public static List<AllergenBoolCombination> CombineAllergenAndBool(Dish dish)
        {
            DataAccess da = new DataAccess();
            List<AllergenBoolCombination> outputList = new List<AllergenBoolCombination>();
            List<Allergen> dishAllergens = da.GetAllergensBasedOnDishId(dish);

            foreach (Allergen allergen in da.GetAllergens())
            {
                AllergenBoolCombination allergenBoolCombination = new AllergenBoolCombination();
                allergenBoolCombination.allergen = allergen;

                if (dishAllergens.Contains(allergen))
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
            DataAccess da = new DataAccess();

            foreach (AllergenBoolCombination allergenBool in combinationList)
            {
                if(allergenBool.hasAllergen == true)
                {
                    da.insertDishAllergenCombo(dish, allergenBool.allergen);
                }
            }
        }
       
            
        
    }
}
