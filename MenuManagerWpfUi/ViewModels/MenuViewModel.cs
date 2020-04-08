using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using MenuManagerWpfUi.ViewModels;

namespace MenuManagerWpfUi.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {
        private Menu _selectedMenu;
        private MenuManager _selectedMenuManager;
        public BindableCollection<Menu> menus { get; set; }      

        public MenuManager SelectedMenuManager
        {
            get { return _selectedMenuManager; }
            set
            {
                _selectedMenuManager = value;
                NotifyOfPropertyChange(() => SelectedMenuManager);
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




        // Constructor for MenuViewModel

        public MenuViewModel(MenuManager menuManager)
        {
            menus = new BindableCollection<Menu>(menuManager.allMenus);
            this.SelectedMenuManager = menuManager;
            this.SelectedMenu = menuManager.allMenus[0];
        }




        // Methods

        public void ShowDishes()
        {
            ActivateItemAsync(new DishViewModel(this.SelectedMenuManager, this.SelectedMenu), System.Threading.CancellationToken.None);
        }
    }
}
