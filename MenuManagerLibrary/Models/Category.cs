using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary
{
    public class Category
    {
		private string name;
		private string _description;
		private List<Dish> listOfDishes;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public List<Dish> ListOfDishes
		{
			get { return listOfDishes; }
			set { listOfDishes = value; }
		}

		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public Category(string name)
		{
			this.Name = name;
			this.ListOfDishes = new List<Dish>();
		}

		


	}
}
