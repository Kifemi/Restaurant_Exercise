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
                NotifyOfPropertyChange(() => SelectedMenuManager);
            }
        }

        



        // Constructor for DishViewModel

        public DishViewModel(MenuManager menuManager, Menu menu)
        {
            //SelectedMenuManager = menuManager;
            Dishes = new BindableCollection<Dish>(menu.MenuDishList);
            SelectedMenuManager = menuManager;
            NotifyOfPropertyChange(() => this.Dishes);
        }       



        // Methods

        public Dish CreateNewDish(string name, string description, double price)
        {
            Dish dish = new Dish(name, description, price);
            return dish;
        }

        public void AddDishButton()
        {
            if (String.IsNullOrWhiteSpace(this.DishName))
            {
                MessageBox.Show("Invalid name");
            }
            else
            {
                Dish newDish = this.CreateNewDish(this.DishName, this.DishDescription, this.DishPrice);
                this.Dishes.Add(newDish);
                SelectedMenuManager.allMenus[0].MenuDishList = new List<Dish>(this.Dishes);
                NotifyOfPropertyChange(() => Dishes);
            }
            

        }

        public bool CanRemoveDishButton()
        {
            if(this.Dishes.Count > 0)
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
            SelectedMenuManager.allMenus[0].MenuDishList = new List<Dish>(this.Dishes);
            NotifyOfPropertyChange(() => Dishes);
        }

    }
}
