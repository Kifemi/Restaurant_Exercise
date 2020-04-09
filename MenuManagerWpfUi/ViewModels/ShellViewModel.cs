using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;

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
            MenusBinded = new BindableCollection<Menu>(menuManager.allMenus);

        }


        // Methods

        public void ShowDishes()
        {
            ActivateItemAsync(new DishViewModel(menuManager, SelectedMenu), System.Threading.CancellationToken.None);
        }


    }
}
