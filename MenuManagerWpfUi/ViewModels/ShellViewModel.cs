using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using System.Linq;

namespace MenuManagerWpfUi.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private MenuManager _menuManager;
        private FoodMenu _selectedMenu;
        private BindableCollection<FoodMenu> _menusBinded;

        public BindableCollection<FoodMenu> MenusBinded
        {
            get { return _menusBinded; }
            set { _menusBinded = value; }
        }

        public MenuManager menuManager
        {
            get { return _menuManager; }
            set { _menuManager = value; }
        }

        public FoodMenu SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
            }
        }

        // Constructor for ShellViewModel
        public ShellViewModel()
        {
            menuManager = new MenuManager();
            DataHandler.FillDishesWithDemoData(menuManager);
            DataHandler.CreatePresetAllergens(menuManager);
            DataHandler.UpdateAllergensAllDishes(menuManager);
            MenusBinded = new BindableCollection<FoodMenu>(menuManager.allMenus);
            menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[0]);
            menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[1]);
            menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[2]);

        }


        // Methods

        public void ShowDishes()
        {
            DishViewModel dishViewModel = new DishViewModel(menuManager, SelectedMenu);
            ActivateItemAsync(dishViewModel, System.Threading.CancellationToken.None);
        }


    }
}
