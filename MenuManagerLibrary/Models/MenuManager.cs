using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace MenuManagerLibrary
{
    public class MenuManager
    {
		private List<Dish> _allDishes;
		public List<Category> allCategories;
		public List<Menu> allMenus;

		public List<Dish> AllDishes
		{
			get { return _allDishes; }
			set
			{
				_allDishes = value;
			}
		}



		// Constructor for MenuManager

		public MenuManager()
		{
			AllDishes = new List<Dish>();
			this.allMenus = new List<Menu>();
			this.allMenus.Insert(0, new Menu("All Foods", AllDishes));
		}
	}
}
