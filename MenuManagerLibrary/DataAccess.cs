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
    }
}