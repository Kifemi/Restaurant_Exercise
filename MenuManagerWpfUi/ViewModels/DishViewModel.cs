using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using MenuManagerLibrary;
using MenuManagerLibrary.Models;
using MenuManagerWpfUi.Views;
using System.Linq;

namespace MenuManagerWpfUi.ViewModels
{
    public class DishViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private Menu _selectedMenu;
        private MenuManager _selecterMenuManager;
        private Allergen _selectedAllergen;
        private BindableCollection<Dish> _dishesBinded;



        private string _dishName;
        public double DishPrice { get; set; }
        public string DishDescription { get; set; }

        public string DishName
        {
            get { return _dishName; }
            set
            {
                _dishName = value;
            }
        }

        public BindableCollection<Dish> DishesBinded
        {
            get 
            {
                return _dishesBinded; 
            }
            set
            {
                _dishesBinded = value;
            }
        }

        public Dish SelectedDish
        {
            get {  return _selectedDish; }
            set
            {
                _selectedDish = value;
            }
        }

        public Menu SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
            }
        }

        public MenuManager SelectedMenuManager
        {
            get { return _selecterMenuManager; }
            set
            {
                _selecterMenuManager = value;
            }
        }

        public Allergen SelectedAllergen
        {
            get { return _selectedAllergen; }
            set 
            { 
                _selectedAllergen = value;
            }
        }



        // Constructor for DishViewModel
        public DishViewModel(MenuManager menuManager, Menu menu)
        {
            SelectedMenuManager = menuManager;
            SelectedMenu = menu;
            DishesBinded = new BindableCollection<Dish>(SelectedMenu.MenuDishList);
        }       



        // Methods

        public void ShowAllergens()
        {
            AllergensViewModel allergensViewModel = new AllergensViewModel(SelectedMenuManager, SelectedMenu, SelectedDish);
            ActivateItemAsync(allergensViewModel, System.Threading.CancellationToken.None);
        }

        public void AddDishButton()
        {
            if (String.IsNullOrWhiteSpace(DishName))
            {
                MessageBox.Show("Invalid name");
                return;
            }

            DishName = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(DishName));

            Dish newDish = DataHandler.CreateNewDish(DishName, DishDescription, DishPrice);
            if (SelectedMenuManager.AllDishes.Contains(newDish))
            {
                MessageBox.Show("The dish is already in the list");
            }
            else
            {
                this.DishesBinded.Add(newDish);
                DataHandler.UpdateAllDishes(SelectedMenuManager, DishesBinded);
            }
            

        }

        public bool CanRemoveDishButton()
        {
            if(this.DishesBinded.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveDishButton()
        {
            SelectedMenu.MenuDishList.Remove(SelectedDish);
            DishesBinded.Remove(SelectedDish);
            DataHandler.UpdateAllDishes(SelectedMenuManager, DishesBinded);
        }
    }
}
