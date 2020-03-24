using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary
{
    class Menu
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
            this.Categories.Add(new Category("Others"));
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
                if(Categories.Count > 0)
                {
                    Console.WriteLine($"To which category the food is added? (1-{Categories.Count}) ");
                    int categoryNumber = Convert.ToInt32(Console.ReadLine());
                    if (categoryNumber < 0 || categoryNumber >= Categories.Count)
                    {
                        Console.WriteLine($"Invalid feed. Please write a number from 1 to {Categories.Count}");
                        continue;
                    }
                    else
                    {
                        Categories[categoryNumber - 1].ListOfDishes.Add(dish);
                        break;
                    }
                }

                Categories[0].ListOfDishes.Add(dish);
                break;
                    
            }
        }

        /// <summary>
        /// Creates preset catogories, mainly for testing purposes
        /// </summary>
        public void InitializeCategories()
        {
            Category appetizers = new Category();
            categories.Add(appetizers);
            Category mainCourses = new Category();
            categories.Add(mainCourses);
            Category desserts = new Category();
            categories.Add(desserts);
            Category kidsMenu = new Category();
            categories.Add(kidsMenu);
            Category drinks = new Category();
            categories.Add(drinks);
            Category others = new Category();
            categories.Add(others);

        }
    }
}
