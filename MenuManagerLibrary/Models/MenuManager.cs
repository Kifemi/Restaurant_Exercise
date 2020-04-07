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
			this.allMenus.Insert(0, new Menu("All Foods", this.Dishes));
		}

		

		//public void FillDishesWithDemoData()
		//{

		//	this.allMenus.Add(new Menu("A la Carte"));
		//	this.allMenus.Add(new Menu("Desserts"));
		//	this.allMenus[0].MenuDishList.Add(new Dish("Haggis", "I dare you", 15));
		//	this.allMenus[1].MenuDishList.Add(new Dish("Vodka", "I dare you", 6.7));
		//	this.allMenus[1].MenuDishList.Add(new Dish("Maggara", "I dare you", 4.7));
		//	this.allMenus[0].MenuDishList.Add(new Dish("Sushi", "I dare you", 9.50));
		//	this.allMenus[0].MenuDishList.Add(new Dish("Nakit ja muusi", "I dare you", 8.0));
		//}
	}
}
