using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;

namespace MenuManagerLibrary
{
    public class Menu
    {
        private string _name;
        private string _description;
        private List<Category> _categories;
        private List<Dish> _menuDishList;

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

        public List<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public List<Dish> MenuDishList
        {
            get { return _menuDishList; }
            set { _menuDishList = value; }
        }

        

        
            
        


        // Constructors for Menu

        public Menu(string name)
        {
            this.Name = name;
            this.MenuDishList = new List<Dish>();
        }

        public Menu(string name, List<Dish> menuDishList)
        {
            this.Name = name;
            this.MenuDishList = menuDishList;
        }

        

        // Methods 

        /// <summary>
        /// Prints all of the dishes from the menu in alphabetical order
        /// </summary>
        /// <param name="list"></param>
        public static void PrintMenuAlphabeticalOrder(List<Dish> list)
        {
            list.Sort(
                delegate (Dish dish1, Dish dish2)
                    {
                            return dish1.Name.CompareTo(dish2.Name);
                    }
            );

            foreach (Dish dish in list)
            {
                Console.WriteLine(dish);
            }
        }


        /// <summary>
        /// Prints all of the dishes in the menu from the cheapest to the most expensive
        /// </summary>
        /// <param name="list"></param>
        public static void PrintMenuPriceOrder(List<Dish> list)
        {
            list.Sort(
                delegate (Dish dish1, Dish dish2)
                    {
                        return dish1.Price.CompareTo(dish2.Price);
                    }
            );

            foreach (Dish dish in list)
            {
                Console.WriteLine(dish);
            }
        }

        /// <summary>
        /// Prints all of the dishes from the menu, one category at the time
        /// </summary>
        /// <param name="menu"></param>
        public void PrintMenuCategoryOrder()
        {
            foreach (Category category in this.Categories)
            {
                PrintMenuAlphabeticalOrder(category.ListOfDishes);
            }
        }

        /// <summary>
        /// Combines all dishes in menu's categories to one list
        /// </summary>
        /// <returns></returns>
        public List<Dish> CombineCategoriesToList()
        {
            List<Dish> fullList = new List<Dish>();

            foreach (Category category in this.Categories)
            {
                foreach (Dish dish in category.ListOfDishes)
                {
                    fullList.Add(dish);
                }
            }

            return fullList;
        }

    }
}
