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

        public void AddCategory()
        {
            Console.WriteLine("Name of the new category: ");
            this.categories.Add(new Category(Console.ReadLine()));
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
    }
}
