using System;
using System.Collections.Generic;
//using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;
using System.Windows;
using System.Linq;
using System.Windows.Documents;

namespace MenuManagerWpfUi.ViewModels
{
    public class MenuViewModel : Conductor<object>
    {
        private Dish _selectedDish;
        private Category _selectedCategory;
        private FoodMenu _selectedMenu;
        private MenuManager _selecterMenuManager;
        public string CategoryName { get; set; }
        private BindableCollection<Category> _categoriesBinded;
        private BindableCollection<Dish> _allDishesBinded;
        private BindableCollection<Dish> _menuDishesBinded;

        public BindableCollection<Dish> AllDishesBinded
        {
            get { return _allDishesBinded; }
            set 
            { 
                _allDishesBinded = value; 
            }
        }

        public BindableCollection<Dish> MenuDishesBinded
        {
            get { return _menuDishesBinded; }
            set 
            {
                _menuDishesBinded = value;
                NotifyOfPropertyChange(() => MenuDishesBinded);
            }
        }

        public BindableCollection<Category> CategoriesBinded
        {
            get { return _categoriesBinded; }
            set
            {
                _categoriesBinded = value;
                NotifyOfPropertyChange(() => CategoriesBinded);
            }
        }

        public Dish SelectedDish
        {
            get 
            {
                return _selectedDish; 
            }
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
                _selectedCategory = value;
                DataAccess da = new DataAccess();
                UpdateMenuDishesBinded(SelectedCategory, da);

                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }



        // Constructor for DishViewModel
        public MenuViewModel(MenuManager menuManager, FoodMenu menu)
        {
            DataAccess da = new DataAccess();
            SelectedMenuManager = menuManager;
            SelectedMenu = menu;
            CategoriesBinded = new BindableCollection<Category>(da.GetCategoriesBasedOnMenuId(SelectedMenu));
            AllDishesBinded = new BindableCollection<Dish>(da.GetDishes());
            MenuDishesBinded = new BindableCollection<Dish>();
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

            if(SelectedCategory != SelectedMenu.Categories[0])
            {
                SelectedCategory.ListOfDishes.Add(SelectedDish);
            }

            MenuDishesBinded = DataHandler.UpdateBindableCollectionDish(SelectedCategory.ListOfDishes);

        }

        public void RemoveDishFromCategory()
        {
            Dish SelectedDishCopy = SelectedDish;

            if(SelectedCategory == SelectedMenu.Categories[0])
            {
                foreach (Category category in SelectedMenu.Categories)
                {
                    category.ListOfDishes.Remove(SelectedDish);  
                }

                MenuDishesBinded = DataHandler.UpdateBindableCollectionDish(SelectedCategory.ListOfDishes);
                SelectedDish = SelectedDishCopy;
                return;
            }

            if (SelectedCategory.ListOfDishes.Contains(SelectedDish))
            {
                SelectedCategory.ListOfDishes.Remove(SelectedDish);
                NotifyOfPropertyChange((() => AllDishesBinded));
                MenuDishesBinded = DataHandler.UpdateBindableCollectionDish(SelectedCategory.ListOfDishes);
                SelectedDish = SelectedDishCopy;
                return;
            }


            MessageBox.Show("The dish is not in the list");
        }

        public void AddCategory()
        {
            if (Utilities.CheckNameValidity(CategoryName) == false)
            {
                MessageBox.Show("Invalid name");
                return;
            }
            DataAccess da = new DataAccess();

            CategoryName = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(CategoryName));
            Category newCategory = new Category(CategoryName);

            if (da.categoryExists(newCategory))
            {
                MessageBox.Show("Category is already in the list");
                return;
            }

            da.insertCategory(newCategory);
            // Update the newCategoryID
            da.insertMenuCategory(SelectedMenu, newCategory);

            this.CategoryName = "";

            CategoriesBinded = new BindableCollection<Category>(da.GetCategoriesBasedOnMenuId(SelectedMenu));

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

            CategoriesBinded.Remove(SelectedCategory);
            DataHandler.UpdateAllCategories(SelectedMenu, CategoriesBinded);
            SelectedCategory = SelectedMenu.Categories[0];
        }

        public void EditCategory()
        {
            if (Utilities.CheckNameValidity(CategoryName) == false)
            {
                MessageBox.Show("Invalid name");
                return;
            }

            foreach (Category category in SelectedMenu.Categories)
            {
                if (category.Name == CategoryName)
                {
                    MessageBox.Show("The category already exists");
                    return;
                }
            }

            if(SelectedCategory == SelectedMenu.Categories[0])
            {
                MessageBox.Show("Can't edit this category");
                return;
            }

            SelectedCategory.Name = Utilities.UpperCaseFirstLetter(Utilities.TrimLowerCaseString(CategoryName));
            CategoriesBinded.Clear();
            CategoriesBinded = new BindableCollection<Category>(SelectedMenu.Categories);
        }

        public void UpdateCategoryView(FoodMenu menu, DataAccess da)
        {
            CategoriesBinded = new BindableCollection<Category>(da.GetCategoriesBasedOnMenuId(menu));
        }

        public void UpdateMenuDishesBinded(Category category, DataAccess da)
        {
            MenuDishesBinded = new BindableCollection<Dish>(da.GetDishesBasedOnCategoryId(category));
        }
        
    }
}

