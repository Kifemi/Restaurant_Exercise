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
        public BindableCollection<Dish> Dishes { get; set; }

        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public double DishPrice { get; set; }
        

        public Dish SelectedDish
        {
            get { return _selectedDish; }
            set
            {
                _selectedDish = value;
                NotifyOfPropertyChange(() => SelectedDish);
            }
        }

        public Menu SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
                NotifyOfPropertyChange(() => SelectedMenu);
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
            Dishes = new BindableCollection<Dish>(menu.MenuDishList);
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
                DataHandler.SynchronizeLists(SelectedMenuManager.allMenus[0].MenuDishList, this.Dishes);
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
            DataHandler.SynchronizeLists(SelectedMenuManager.allMenus[0].MenuDishList, this.Dishes);
        }

    }
}
