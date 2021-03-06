﻿using System;
using System.Collections.Generic;
using MenuManagerLibrary.Models;
//using System.Text;

namespace MenuManagerLibrary
{
    public class Category
    {
		private int _categoryId;
		private string name;
		private int _menuId;
		private List<Dish> listOfDishes;

		public int CategoryId
		{
			get { return _categoryId; }
			set { _categoryId = value; }
		}

		public int MenuId
		{
			get { return _menuId; }
			set { _menuId= value; }
		}

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


		// Constructors

		public Category(string name)
		{
			this.Name = name;
		}

		public Category(int CategoryId, string name)
		{
			this.CategoryId = CategoryId;
			this.Name = name;
			//this.ListOfDishes = new List<Dish>();
		}

		// Overrides

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (!(obj is Category))
			{
				return false;
			}

			if (this.Name == ((Category)obj).Name)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
