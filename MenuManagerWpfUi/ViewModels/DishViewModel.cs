//using System;
//using System.Collections.Generic;
//using System.Text;
using System.Windows;
using Caliburn.Micro;
using MenuManagerLibrary;
//using MenuManagerLibrary.Models;
//using MenuManagerWpfUi.Views;
//using System.Windows.Controls;

namespace MenuManagerWpfUi.ViewModels
{
    public class DishViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private FoodMenu _selectedMenu;
        private MenuManager _selecterMenuManager;
        private BindableCollection<Dish> _dishesBinded;
        public AllergensViewModel allergensViewModel { get; set; }



        private string _dishName;
        public decimal DishPrice { get; set; }
        public string DishDescription { get; set; }

        public string DishName
        {
            get { return _dishName; }
            set
            {
                _dishName = value;
                NotifyOfPropertyChange(() => DishName);
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
                NotifyOfPropertyChange(() => DishesBinded);
            }
        }

        public Dish SelectedDish
        {
            get {  return _selectedDish; }
            set
            {
                _selectedDish = value;
                if(value == null)
                {
                    return;
                }
                else
                {
                    ShowAllergens();
                }
                
            }
        }

        public FoodMenu SelectedMenu
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



        // Constructor for DishViewModel
        public DishViewModel(MenuManager menuManager)
        {
            SelectedMenuManager = menuManager;
            //SelectedMenu = menu;
            DataAccess da = new DataAccess();
            //DishesBinded = new BindableCollection<Dish>(menuManager.AllDishes);
            DishesBinded = new BindableCollection<Dish>(da.GetDishes());
        }       



        // Buttons

        public void ShowAllergens()
        {
            allergensViewModel = new AllergensViewModel(this.SelectedMenuManager, this.SelectedMenu, this.SelectedDish);
            ActivateItemAsync(allergensViewModel, System.Threading.CancellationToken.None);
        }

        public void AddDishButton()
        {
            if (Utilities.CheckNameValidity(DishName) == false)
            {
                MessageBox.Show("Invalid name");
                return;
            }
            DataAccess da = new DataAccess();
            
            DishName = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(DishName));
            Dish newDish = new Dish(this.DishName, this.DishDescription, this.DishPrice);
            
            if (da.dishExists(newDish))
            {
                MessageBox.Show("The dish is already in the list");
                return;
            }

            da.insertDish(newDish);

            this.DishName = "";
            this.DishDescription = "";
            this.DishPrice = 0;

            DishesBinded = new BindableCollection<Dish>(da.GetDishes());
        }


        public void RemoveDishButton()
        {
            DataAccess da = new DataAccess();
            da.deleteDish(SelectedDish);

            DishesBinded = new BindableCollection<Dish>(da.GetDishes());
        }

        public void EditDish()
        {
            DataAccess da = new DataAccess();

            if (Utilities.CheckNameValidity(DishName) == false)
            {
                MessageBox.Show("Invalid name");
                return;
            }

            DishName = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(DishName));
            Dish newDish = new Dish(this.DishName, this.DishDescription, this.DishPrice);
            newDish.DishId = SelectedDish.DishId;
            da.editDish(newDish);

            
            this.DishDescription = "";
            this.DishPrice = 0;
            this.DishName = "";

            DishesBinded = new BindableCollection<Dish>(da.GetDishes());
        }
    }
}
