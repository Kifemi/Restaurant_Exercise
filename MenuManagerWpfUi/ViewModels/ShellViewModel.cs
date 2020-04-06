using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using MenuManagerLibrary;

namespace MenuManagerWpfUi.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        

        public void ShowMenu()
        {
            ActivateItemAsync(new DishViewModel(), System.Threading.CancellationToken.None);
        }
            


    }
}
