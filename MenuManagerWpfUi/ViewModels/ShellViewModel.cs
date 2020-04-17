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
        private Menu _selectedMenu;
        private BindableCollection<Menu> _menusBinded;

        public BindableCollection<Menu> MenusBinded
        {
            get { return _menusBinded; }
            set { _menusBinded = value; }
        }

        public MenuManager menuManager
        {
            get { return _menuManager; }
            set { _menuManager = value; }
        }

        public Menu SelectedMenu
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
            menuManager.AllDishes[0].Allergens[menuManager.allAllergens[0]] = true;
            MenusBinded = new BindableCollection<Menu>(menuManager.allMenus);

        }


        // Methods

        public void ShowDishes()
        {
            DishViewModel dishViewModel = new DishViewModel(menuManager, SelectedMenu);
            ActivateItemAsync(dishViewModel, System.Threading.CancellationToken.None);
        }


    }
}
