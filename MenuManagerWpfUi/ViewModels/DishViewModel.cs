using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using MenuManagerLibrary;
using MenuManagerWpfUi.Views;

namespace MenuManagerWpfUi.ViewModels
{
    public class DishViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private Menu _selectedMenu;
        private MenuManager _selecterMenuManager;
        private BindableCollection<Dish> _dishes;
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public double DishPrice { get; set; }

        public BindableCollection<Dish> Dishes
        {
            get 
            {
                return _dishes; 
            }
            set
            {
                _dishes = value;
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

        



        // Constructor for DishViewModel

        public DishViewModel(MenuManager menuManager, Menu menu)
        {
            SelectedMenuManager = menuManager;
            this.Dishes = new BindableCollection<Dish>(menu.MenuDishList);
        }       



        // Methods

        public void AddDishButton()
        {
            if (String.IsNullOrWhiteSpace(this.DishName))
            {
                MessageBox.Show("Invalid name");
            }
            else
            {
                this.Dishes.Add(DataHandler.CreateNewDish(this.DishName, this.DishDescription, this.DishPrice));
                SelectedMenuManager.allMenus[0].MenuDishList = DataHandler.SynchronizeLists(this.Dishes);
            }
            

        }

        public bool CanRemoveDishButton()
        {
            if(this.Dishes.Count > 1)
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
            this.Dishes.Remove(SelectedDish);
            SelectedMenuManager.allMenus[0].MenuDishList = DataHandler.SynchronizeLists(this.Dishes);
        }

    }
}
