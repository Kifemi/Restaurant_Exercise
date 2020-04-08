using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using MenuManagerWpfUi.ViewModels;

namespace MenuManagerWpfUi.ViewModels
{
    public class DishViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private Menu _selectedMenu;
        private MenuManager _selecterMenuManager;
        public BindableCollection<Dish> Dishes { get; set; }

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
            SelectedMenuManager = menuManager;
            Dishes = new BindableCollection<Dish>(menu.MenuDishList);         
        }       



        // Methods

        

    }
}
