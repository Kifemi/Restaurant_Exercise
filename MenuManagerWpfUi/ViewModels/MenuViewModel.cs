using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using System.Windows;

namespace MenuManagerWpfUi.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private Category _selectedCategory;
        private FoodMenu _selectedMenu;
        private MenuManager _selecterMenuManager;
        private BindableCollection<Category> _categoriesBinded;
        private BindableCollection<Dish> _allDishesBinded;
        private BindableCollection<Dish> _menuDishesBinded;

        public BindableCollection<Dish> AllDishesBinded
        {
            get { return _allDishesBinded; }
            set { _allDishesBinded = value; }
        }

        public BindableCollection<Dish> MenuDishesBinded
        {
            get { return _menuDishesBinded; }
            set { _menuDishesBinded = value; }
        }

        public BindableCollection<Category> CategoriesBinded
        {
            get { return _categoriesBinded; }
            set { _categoriesBinded = value; }
        }

        public Dish SelectedDish
        {
            get { return _selectedDish; }
            set { _selectedDish = value; }
        }

        public FoodMenu SelectedMenu
        {
            get { return _selectedMenu; }
            set { _selectedMenu = value; }
        }

        public MenuManager SelectedMenuManager
        {
            get { return _selecterMenuManager; }
            set{ _selecterMenuManager = value; }
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set 
            { 
                if(value == null)
                {
                    return;
                }

                //Add if(category is menu.categories[0] then foreach category add dishes to list)
                _selectedCategory = value;
                MenuDishesBinded.Clear();
                MenuDishesBinded = new BindableCollection<Dish>(value.ListOfDishes);
                NotifyOfPropertyChange(() => MenuDishesBinded);
            }
        }



        // Constructor for DishViewModel
        public MenuViewModel(MenuManager menuManager, FoodMenu menu)
        {
            SelectedMenuManager = menuManager;
            SelectedMenu = menu;
            AllDishesBinded = new BindableCollection<Dish>(SelectedMenuManager.AllDishes);
            MenuDishesBinded = new BindableCollection<Dish>(SelectedMenu.Categories[0].ListOfDishes);
            CategoriesBinded = new BindableCollection<Category>(SelectedMenu.Categories);
            SelectedCategory = SelectedMenu.Categories[0];
        }
        

        // Buttons

        public void AddDishToCategory()
        {
            if(SelectedCategory == null)
            {
                MessageBox.Show("Please, select a category");
                return;
            } 
            
            if (SelectedCategory.ListOfDishes.Contains(SelectedDish))
            {
                MessageBox.Show("The dish is already in the list");
                return;
            }

            if (SelectedMenu.Categories[0].ListOfDishes.Contains(SelectedDish) == false)
            {
                SelectedMenu.Categories[0].ListOfDishes.Add(SelectedDish);
            }

            SelectedCategory.ListOfDishes.Add(SelectedDish);
            MenuDishesBinded.Clear();
            MenuDishesBinded = new BindableCollection<Dish>(SelectedCategory.ListOfDishes);
            NotifyOfPropertyChange(() => MenuDishesBinded);

        }

        public void RemoveDishFromCategory()
        {
            if(SelectedCategory == SelectedMenu.Categories[0])
            {
                foreach (Category category in SelectedMenu.Categories)
                {
                    category.ListOfDishes.Remove(SelectedDish);  
                }

                MenuDishesBinded.Clear();
                MenuDishesBinded = new BindableCollection<Dish>(SelectedCategory.ListOfDishes);
                NotifyOfPropertyChange(() => MenuDishesBinded);
                return;
            }

            if (SelectedCategory.ListOfDishes.Contains(SelectedDish))
            {
                SelectedCategory.ListOfDishes.Remove(SelectedDish);
                MenuDishesBinded.Clear();
                MenuDishesBinded = new BindableCollection<Dish>(SelectedCategory.ListOfDishes);
                NotifyOfPropertyChange(() => MenuDishesBinded);
                return;
            }

            MessageBox.Show("The dish is not in the list");
        }

        public void AddCategory()
        {

        }

        public void RemoveCategory()
        {
            if(SelectedCategory == null)
            {
                return;
            }

            if(SelectedCategory == SelectedMenu.Categories[0])
            {
                MessageBox.Show("Can't remove this category");
                return;
            }

            SelectedMenu.Categories.Remove(SelectedCategory);
            CategoriesBinded.Clear();
            CategoriesBinded = new BindableCollection<Category>(SelectedMenu.Categories);
            NotifyOfPropertyChange(() => CategoriesBinded);
            SelectedCategory = SelectedMenu.Categories[0];
            NotifyOfPropertyChange(() => SelectedCategory);
        }
    }
}

