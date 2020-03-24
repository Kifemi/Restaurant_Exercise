using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary
{
    public class Category
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private List<Dish> dishes;

		public List<Dish> ListOfDishes
		{
			get { return dishes; }
			set { dishes = value; }
		}

		public Category(string name)
		{
			this.Name = name;
			this.ListOfDishes = new List<Dish>();
		}



	}
}
