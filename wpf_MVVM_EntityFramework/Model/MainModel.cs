using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_MVVM_EntityFramework.Model
{
    public class MainModel
    {
        public BL_imp BL { get; set; }
        public MainModel()
        {
            BL = new BL_imp();
        }

    }
}
