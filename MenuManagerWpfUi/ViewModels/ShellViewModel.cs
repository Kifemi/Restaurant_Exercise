using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using MenuManagerLibrary;

namespace MenuManagerWpfUi.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private MenuManager _menuManager;
        private FoodMenu _selectedMenu;
        private BindableCollection<FoodMenu> _menusBinded;
        private string _menuName;

        public string MenuName
        {
            get { return _menuName; }
            set 
            { 
                _menuName = value;
                NotifyOfPropertyChange(() => MenuName);
            }
        }


        public BindableCollection<FoodMenu> MenusBinded
        {
            get { return _menusBinded; }
            set
            { 
                _menusBinded = value;
                NotifyOfPropertyChange(() => MenusBinded);
            }
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
                if(value == null)
                {
                    return;
                }
                else
                {
                    ShowMenu();
                }
            }
        }

        // Constructor for ShellViewModel
        public ShellViewModel()
        {
            DataAccess da = new DataAccess();
            menuManager = new MenuManager();
            //DataHandler.FillDishesWithDemoData(menuManager);
            //DataHandler.CreatePresetAllergens(menuManager);
            MenusBinded = new BindableCollection<FoodMenu>(da.GetMenus());
            //MenusBinded = new BindableCollection<FoodMenu>(menuManager.allMenus);
            //menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[0]);
            //menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[1]);
            //menuManager.AllDishes[0].Allergens.Add(menuManager.allAllergens[2]);

        }


        // Buttons

        public void ShowMenu()
        {
            MenuViewModel menuViewModel = new MenuViewModel(menuManager, SelectedMenu);
            ActivateItemAsync(menuViewModel, System.Threading.CancellationToken.None);
        }

        public void ShowDishes()
        {
            SelectedMenu = null;
            ActivateItemAsync(new DishViewModel(menuManager), System.Threading.CancellationToken.None);
        }

        public void AddMenuButton()
        {
            if (Utilities.CheckNameValidity(MenuName) == false)
            {
                MessageBox.Show("Invalid name");
                return;
            }
            DataAccess da = new DataAccess();

            MenuName = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(MenuName));
            FoodMenu newMenu = new FoodMenu(MenuName);

            if (da.menuExists(newMenu))
            {
                MessageBox.Show("Menu is already in the list");
                return;
            }

            da.insertMenu(newMenu);

            this.MenuName = "";

            MenusBinded = new BindableCollection<FoodMenu>(da.GetMenus());
        }

        public void RemoveMenuButton()
        {
            DataAccess da = new DataAccess();
            da.deleteMenu(SelectedMenu);

            MenusBinded = new BindableCollection<FoodMenu>(da.GetMenus());
        }
    }
}
