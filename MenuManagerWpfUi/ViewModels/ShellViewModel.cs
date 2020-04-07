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
        

        public ShellViewModel()
        {
            this.menuManager = new MenuManager();
            
           
        }


        public void ShowMenus()
        {
            ActivateItemAsync(new MenuViewModel(menuManager), System.Threading.CancellationToken.None);
        }



    }
}
