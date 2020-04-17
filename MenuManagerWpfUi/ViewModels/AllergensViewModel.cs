using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using MenuManagerLibrary.Models;

namespace MenuManagerWpfUi.ViewModels
{
    public class AllergensViewModel: Conductor<object>
    {
		private MenuManager _selectedMenuManager;
		private Menu _selectedMenu;
		private Dish _selectedDish;
		private BindableCollection<Allergen> _allergensBinded;

		public Dish SelectedDish
		{
			get { return _selectedDish; }
			set { _selectedDish = value; }
		}

		public Menu SelectedMenu
		{
			get { return _selectedMenu; }
			set { _selectedMenu = value; }
		}

		public MenuManager SelectedMenuManager
		{
			get { return _selectedMenuManager; }
			set { _selectedMenuManager = value; }
		}

		public BindableCollection<Allergen> AllergensBinded
		{
			get { return _allergensBinded; }
			set { _allergensBinded = value; }
		}



		public AllergensViewModel(MenuManager menuManager, Menu menu, Dish dish)
		{
			this.SelectedDish = dish;
			this.SelectedMenu = menu;
			this.SelectedMenuManager = menuManager;
			AllergensBinded = new BindableCollection<Allergen>(menuManager.allAllergens);
		}
	}
}
