using System;
using System.Collections.Generic;
using System.Text;
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

        



        // Constructors for DishViewModel      

        //public DishViewModel(MenuManager menuManager)
        //{
        //    Dishes = new BindableCollection<Dish>(menuManager.Dishes);
        //}

        public DishViewModel(MenuManager menuManager, Menu menu)
        {
            //SelectedMenuManager = menuManager;
            Dishes = new BindableCollection<Dish>(menu.MenuDishList);
            SelectedMenuManager = menuManager;
        }       



        // Methods

        public Dish CreateNewDish(string name, string description, double price)
        {
            Dish dish = new Dish(name, description, price);
            return dish;
        }

        public void AddDishButton()
        {
            Dish newDish = this.CreateNewDish(this.DishName, this.DishDescription, this.DishPrice);
            DataHandler.AddDish(this.SelectedMenuManager, this.SelectedMenu, newDish);
            
        }

        public void RemoveDishButton()
        {
            SelectedMenuManager.Dishes.Remove(SelectedDish);
        }

    }
}
