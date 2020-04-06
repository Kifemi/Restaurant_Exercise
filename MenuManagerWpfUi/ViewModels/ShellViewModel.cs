using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;

namespace MenuManagerWpfUi.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        private BindableCollection<Dish> _dishes;
        private Dish _selectedDish;

        public ShellViewModel()
        {
            Dishes = new BindableCollection<Dish>();
            Dishes.Add(new Dish("Haggis", "I dare you", 15));
            Dishes.Add(new Dish("Vodka", "I dare you", 6.7));
            Dishes.Add(new Dish("Maggara", "I dare you", 4.7));
            Dishes.Add(new Dish("Sushi", "I dare you", 9.50));
            Dishes.Add(new Dish("Nakit ja muusi", "I dare you", 8.0));
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
        
        public BindableCollection<Dish> Dishes
        {
            get { return _dishes; }
            set { _dishes = value; }
        }

        
            


    }
}
