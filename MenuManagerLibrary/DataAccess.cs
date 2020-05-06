using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using MenuManagerLibrary.Models;

namespace MenuManagerLibrary
{
    public class DataAccess
    {
        public List<Dish> GetDishes()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                var output = connection.Query<Dish>("SELECT * FROM Dish").ToList();
                return output;
            }
        }

        public List<FoodMenu> GetMenus()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                var output = connection.Query<FoodMenu>("SELECT * FROM FoodMenu").ToList();
                return output;
            }
        }

        public List<Allergen> GetAllergens()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                var output = connection.Query<Allergen>("SELECT * FROM Allergen").ToList();
                return output;
            }
        }

        public List<Category> GetCategories()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                var output = connection.Query<Category>("SELECT * FROM Category").ToList();
                return output;
            }
        }



        public void insertDish(Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute("dbo.spDish_Insert @Name, @Description, @Price", dish);
            }
        }

        public void insertMenu(FoodMenu menu)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute("dbo.spFoodMenu_Insert @Name", menu);
            }
        }

        public void insertCategory(Category category)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute("dbo.spCategory_Insert @Name", category);
            }
        }

        public void deleteDish(Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute("dbo.spDish_DeleteAllergenDishCombo @DishId", dish);
                connection.Execute("dbo.spDish_Delete @DishId", dish);
            }
        }

        public void deleteMenu(FoodMenu menu)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute("dbo.spFoodMenu_Delete @FoodMenuId", menu);
            }
        }

        public void editDish(Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute("dbo.spDish_Edit @Name, @Description, @Price, @DishId", dish);
            }
        }

        public bool dishExists(Dish dish)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                var dishes = connection.Query<Dish>("SELECT * FROM dbo.Dish WHERE Name = @Name", dish).ToList();
                if (dishes.Count == 0)
                {
                    return false;
                }
                else 
                {
                    return true;
                }
            }
        }

        public bool menuExists(FoodMenu menu)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                var menus = connection.Query<FoodMenu>("SELECT * FROM dbo.FoodMenu WHERE Name = @Name", menu).ToList();
                if (menus.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool categoryExists(Category category)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                var categories = connection.Query<Category>("SELECT * FROM dbo.Category WHERE Name = @Name", category).ToList();
                if (categories.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void dishDeleteAllergens(Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute("dbo.spDish_DeleteAllergens @DishId", dish);
            }
        }

        public void insertDishAllergenCombo(Dish dish, Allergen allergen)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute($"INSERT INTO dbo.DishAllergenCombo VALUES ({dish.DishId}, {allergen.AllergenId})");
            }
        }

        public void insertMenuCategory(FoodMenu foodMenu, Category category)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute($"INSERT INTO dbo.MenuCategories VALUES ({foodMenu.FoodMenuId}, {category.CategoryId})");
            }
        }

        public List<Allergen> GetAllergensBasedOnDishId(Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                List<Allergen> output = new List<Allergen>();

                var allergensIds = connection.Query<int>("SELECT AllergenId FROM dbo.DishAllergenCombo WHERE DishId = @DishId", dish).ToList();

                foreach (int id in allergensIds)
                {
                    output.AddRange(connection.Query<Allergen>($"SELECT * FROM dbo.Allergen WHERE AllergenId = {id}").ToList());
                }

                return output;
            }
        }

        public List<Category> GetCategoriesBasedOnMenuId(FoodMenu menu)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                List<Category> output = new List<Category>();

                var categoryIds = connection.Query<int>("SELECT CategoryId FROM MenuCategories WHERE FoodMenuId = @FoodMenuId", menu).ToList();

                foreach (int id in categoryIds)
                {
                    output.AddRange(connection.Query<Category>($"SELECT * FROM dbo.Category WHERE CategoryId = {id}").ToList());
                }
                return output;
            }
        }

        public List<Dish> GetDishesBasedOnCategoryId(Category category)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                List<Dish> output = new List<Dish>();

                var DishIds = connection.Query<int>("SELECT DishId FROM DishesInCategory WHERE CategoryId = @CategoryId", category).ToList();

                foreach (int id in DishIds)
                {
                    output.AddRange(connection.Query<Dish>($"SELECT * FROM dbo.Dish WHERE DishId = {id}").ToList());
                }
                return output;
            }
        }

        public void AddDishToCategory(Category category, Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute($"INSERT INTO dbo.DishesInCategory VALUES ({category.CategoryId}, {dish.DishId})");
            }
        }

        public void RemoveDishFromCategory(Category category, Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute($"DELETE FROM dbo.DishesInCategory WHERE (CategoryId = {category.CategoryId} AND DishId = {dish.DishId})");
            }
        }
    }
}