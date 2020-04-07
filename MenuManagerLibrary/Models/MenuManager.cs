using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;

namespace MenuManagerLibrary
{
    public class MenuManager
    {
		private List<Dish> _dishes;
		public List<Category> allCategories;
		public List<Menu> allMenus;

		public List<Dish> Dishes
		{
			get { return _dishes; }
			set { _dishes = value; }
		}



		// Constructor for MenuManager

		public MenuManager()
		{
			this.Dishes = new List<Dish>();
			this.allMenus = new List<Menu>();
			this.allMenus.Insert(0, new Menu("All Foods", this.Dishes));
		}
	}
}
