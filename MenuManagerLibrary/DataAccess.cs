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
                //List<Dish> newDishes = new List<Dish>();

                //newDishes.Add(new Dish(dishName, dishDescription, dishPrice));

                connection.Execute("dbo.spDish_Insert @Name, @Description, @Price", dish);
            }
        }

        public void deleteDish(Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                //int DishId = dish.DishId;
                //connection.Execute("dbo.spDish_Delete @DishId", dish);
                connection.Execute("DELETE FROM dbo.Dish WHERE DishId = @DishId", dish);
            }
        }

        public void editDish(Dish dish)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute("UPDATE dbo.Dish SET Name = @Name, Description = @Description, Price = @Price WHERE DishId = @DishId", dish);
            }
        }

        // KÄYTÄ QUERYÄ EIKÄ EXECUTEA
        public bool dishExists(Dish dish)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                //var exists = connection.Execute("dbo.spDish_Exists @Name", dish);
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

        public void insertDishAllergenCombo(Dish dish, Allergen allergen)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("MenuManagerDB")))
            {
                connection.Execute($"INSERT INTO dbo.AllergenBoolCombo VALUES ({dish.DishId}, {allergen.AllergenId})");
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