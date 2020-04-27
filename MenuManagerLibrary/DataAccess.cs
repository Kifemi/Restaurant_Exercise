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
    }
}
