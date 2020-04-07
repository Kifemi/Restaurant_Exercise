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

        public BindableCollection<Dish> Dishes { get; set; }        

        public DishViewModel(MenuManager menuManager)
        {
            Dishes = new BindableCollection<Dish>(menuManager.Dishes);
        }

        public DishViewModel(MenuManager menuManager, Menu menu)
        {
            Dishes = new BindableCollection<Dish>(menu.MenuDishList);
        }       

        public Dish SelectedDish
        {
            get { return _selectedDish; }
            set
            {
                _selectedDish = value;
                NotifyOfPropertyChange(() => SelectedDish);
            }
        }

    }
}
