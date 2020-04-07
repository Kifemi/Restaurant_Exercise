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
        



        // Constructor for ShellViewModel

        public ShellViewModel()
        {
            this.menuManager = new MenuManager();
            DataHandler.FillDishesWithDemoData(this.menuManager);
           
        }





        // Methods

        public void ShowMenus()
        {
            ActivateItemAsync(new MenuViewModel(this.menuManager), System.Threading.CancellationToken.None);
        }


        

    }
}
