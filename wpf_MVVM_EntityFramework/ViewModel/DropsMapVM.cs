using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_MVVM_EntityFramework.Commands;

namespace wpf_MVVM_EntityFramework.ViewModel
{
    public class DropsMapVM
    {
       

        public ShowDropsCommand ShowDropsCommand { get; set; }
        public DropsMapVM()
        {
            this.ShowDropsCommand = new ShowDropsCommand(this);
        }
        public void ShowDropsOnMap()
        {
           Debug.WriteLine("Hello");
          
        }
    }
}

