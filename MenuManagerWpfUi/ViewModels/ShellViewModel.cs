using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;

namespace MenuManagerWpfUi.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private MenuManager menuManager;
        private Menu _selectedMenu;
        public BindableCollection<Menu> menus { get; set; }

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
            this.menuManager = new MenuManager();
            DataHandler.FillDishesWithDemoData(this.menuManager);
            menus = new BindableCollection<Menu>(this.menuManager.allMenus);

        }





        // Methods

        public void ShowDishes()
        {
            ActivateItemAsync(new DishViewModel(this.menuManager, this.SelectedMenu), System.Threading.CancellationToken.None);
        }


    }
}
