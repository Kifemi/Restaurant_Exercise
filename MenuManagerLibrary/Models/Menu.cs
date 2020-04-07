using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace MenuManagerLibrary
{
    public class Menu
    {
        private string _name;
        private List<Category> _categories;
        private string _description;
        private List<Dish> _menuDishList;

        public List<Dish> MenuDishList
        {
            get { return _menuDishList; }
            set { _menuDishList = value; }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
            
        public List<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        public Menu(string name)
        {
            this.Name = name;
            this.MenuDishList = new List<Dish>();
        }

        public void AddDish(Dish dish)
        {
            Categories[Categories.Count - 1].ListOfDishes.Add(dish);
        }

        

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







        //public void AddDishToCategory(Dish dish)
        //{
        //    while (true)
        //    {
        //        if(this.Categories.Count > 0)
        //        {
        //            Console.WriteLine($"To which category {dish.Name} is added? (1-{this.Categories.Count}) ");
        //            int categoryNumber = Convert.ToInt32(Console.ReadLine());
        //            if (categoryNumber < 0 || categoryNumber >= this.Categories.Count)
        //            {
        //                Console.WriteLine($"Invalid feed. Please write a number from 1 to {this.Categories.Count}");
        //                continue;
        //            }
        //            else
        //            {
        //                this.Categories[categoryNumber - 1].ListOfDishes.Add(dish);
        //                break;
        //            }
        //        }

        //        this.Categories[0].ListOfDishes.Add(dish);
        //        break;

        //    }
        //}


        //public void AddCategory()
        //{
        //    Console.WriteLine("Name of the new category: ");
        //    if(Categories.Count == 0)
        //    {
        //        this.Categories.Add(new Category(Console.ReadLine()));
        //    }
        //    else
        //    {
        //        this.Categories.Insert(Categories.Count - 1, new Category(Console.ReadLine()));
        //    }

        //}



        //public void SetPresetCategories()
        //{
        //    Category appetizers = new Category("Appetizers");
        //    this._categories.Add(appetizers);
        //    Category mainCourses = new Category("Main Courses");
        //    this._categories.Add(mainCourses);
        //    Category desserts = new Category("Desserts");
        //    this._categories.Add(desserts);
        //    Category kidsMenu = new Category("Kid's Menu");
        //    this._categories.Add(kidsMenu);
        //    Category drinks = new Category("Drinks");
        //    this._categories.Add(drinks);
        //    Category others = new Category("Others");
        //    this._categories.Add(others);

        //}


        //public void PrintMenu()
        //{
        //    foreach (Category item in this.Categories)
        //    {
        //        Console.WriteLine(item.Name);
        //        if(item.ListOfDishes.Count == 0)
        //        {
        //            Console.WriteLine("---");
        //        }
        //        else
        //        {

        //            foreach (Dish item1 in item.ListOfDishes)
        //            {
        //                Console.WriteLine(item1.Name);
        //            }
        //        }
        //    }
        //}
    }
}
