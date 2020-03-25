using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary
{
    public class Menu
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Category> categories;
            
        public List<Category> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        /// <summary>
        /// Constructor for the menu
        /// </summary>
        /// <param name="name"></param>
        public Menu(string name)
        {
            this.Name = name;
            this.Categories = new List<Category>();
        }

        /// <summary>
        /// Adds dish to the last category
        /// </summary>
        /// <param name="dish"></param>
        public void AddDish(Dish dish)
        {
            Categories[Categories.Count - 1].ListOfDishes.Add(dish);
        }

        /// <summary>
        /// Asks and adds the food to specifies category
        /// </summary>
        /// <param name="dish"></param>
        public void AddDishToCategory(Dish dish)
        {
            while (true)
            {
                if(this.Categories.Count > 0)
                {
                    Console.WriteLine($"To which category {dish.Name} is added? (1-{this.Categories.Count}) ");
                    int categoryNumber = Convert.ToInt32(Console.ReadLine());
                    if (categoryNumber < 0 || categoryNumber >= this.Categories.Count)
                    {
                        Console.WriteLine($"Invalid feed. Please write a number from 1 to {this.Categories.Count}");
                        continue;
                    }
                    else
                    {
                        this.Categories[categoryNumber - 1].ListOfDishes.Add(dish);
                        break;
                    }
                }

                this.Categories[0].ListOfDishes.Add(dish);
                break;
                    
            }
        }

        /// <summary>
        /// Asks user to write name for the category and creates new category
        /// </summary>
        public void AddCategory()
        {
            Console.WriteLine("Name of the new category: ");
            if(Categories.Count == 0)
            {
                this.Categories.Add(new Category(Console.ReadLine()));
            }
            else
            {
                this.Categories.Insert(Categories.Count - 1, new Category(Console.ReadLine()));
            }
            
        }


        /// <summary>
        /// Creates preset catogories, mainly for testing purposes
        /// </summary>
        public void SetPresetCategories()
        {
            Category appetizers = new Category("Appetizers");
            this.categories.Add(appetizers);
            Category mainCourses = new Category("Main Courses");
            this.categories.Add(mainCourses);
            Category desserts = new Category("Desserts");
            this.categories.Add(desserts);
            Category kidsMenu = new Category("Kid's Menu");
            this.categories.Add(kidsMenu);
            Category drinks = new Category("Drinks");
            this.categories.Add(drinks);
            Category others = new Category("Others");
            this.categories.Add(others);

        }

        /// <summary>
        /// For testing
        /// </summary>
        public void PrintMenu()
        {
            foreach (Category item in this.Categories)
            {
                Console.WriteLine(item.Name);
                if(item.ListOfDishes.Count == 0)
                {
                    Console.WriteLine("---");
                }
                else
                {
                    
                    foreach (Dish item1 in item.ListOfDishes)
                    {
                        Console.WriteLine(item1.Name);
                    }
                }
            }
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
    }
}
