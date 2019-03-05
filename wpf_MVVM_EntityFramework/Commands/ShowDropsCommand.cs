using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_MVVM_EntityFramework.ViewModel;

namespace wpf_MVVM_EntityFramework.Commands
{
    public class ShowDropsCommand : ICommand
    {
        //jk
        public DropsMapVM dropsMapVM { get; set; }
        public ShowDropsCommand(DropsMapVM dropsMapVM)
        {
            this.dropsMapVM = dropsMapVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.dropsMapVM.ShowDropsOnMap();
        }
    }
}
