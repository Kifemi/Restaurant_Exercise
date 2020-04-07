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

		public MenuManager()
		{
			this.Dishes = new List<Dish>();
			this.allMenus = new List<Menu>();
		}

		public List<Menu> FillDishesWithDemoData()
		{
			List<Menu> output = new List<Menu>();
			Menu alacarte = new Menu("A la Carte");
			Menu desserts = new Menu("Desserts");
			alacarte.MenuDishList.Add(new Dish("Haggis", "I dare you", 15));
			desserts.MenuDishList.Add(new Dish("Vodka", "I dare you", 6.7));
			desserts.MenuDishList.Add(new Dish("Maggara", "I dare you", 4.7));
			alacarte.MenuDishList.Add(new Dish("Sushi", "I dare you", 9.50));
			alacarte.MenuDishList.Add(new Dish("Nakit ja muusi", "I dare you", 8.0));
			output.Add(alacarte);
			output.Add(desserts);



			return output;
		}
	}
}
