using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using System.Windows;

namespace MenuManagerWpfUi.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private FoodMenu _selectedMenu;
        private MenuManager _selecterMenuManager;
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
            get { return _selectedDish; }
            set
            {
                _selectedDish = value;
                //ShowAllergens();
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
        public MenuViewModel(MenuManager menuManager, FoodMenu menu)
        {
            SelectedMenuManager = menuManager;
            SelectedMenu = menu;
            DishesBinded = new BindableCollection<Dish>(SelectedMenu.MenuDishList);
        }



        // Buttons

        //public void ShowAllergens()
        //{
        //    AllergensViewModel allergensViewModel = new AllergensViewModel(this.SelectedMenuManager, this.SelectedMenu, this.SelectedDish);
        //    ActivateItemAsync(allergensViewModel, System.Threading.CancellationToken.None);
        //}

        //public void AddDishButton()
        //{
        //    if (!Utilities.CheckNameValidity(DishName))
        //    {
        //        MessageBox.Show("Invalid name");
        //        return;
        //    }

        //    DishName = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(DishName));
        //    Dish newDish = new Dish(DishName, DishDescription, DishPrice);

        //    if (SelectedMenuManager.AllDishes.Contains(newDish))
        //    {
        //        MessageBox.Show("The dish is already in the list");
        //    }
        //    else
        //    {
        //        this.DishesBinded.Add(newDish);
        //        DataHandler.UpdateAllDishes(SelectedMenuManager, DishesBinded);
        //    }


        //}

        //public bool CanRemoveDishButton()
        //{
        //    if (this.DishesBinded.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public void RemoveDishButton()
        //{
        //    SelectedMenu.MenuDishList.Remove(SelectedDish);
        //    DishesBinded.Remove(SelectedDish);
        //    DataHandler.UpdateAllDishes(SelectedMenuManager, DishesBinded);
        //}
    }
}

