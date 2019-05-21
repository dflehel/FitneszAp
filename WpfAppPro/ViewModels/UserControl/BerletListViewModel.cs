using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppPro.Common.Interfaces;
using WpfAppPro.Common.MVVM;

namespace WpfAppPro.ViewModels.UserControl
{
    public class BerletListViewModel : ViewModelBase, IBerletListContent
    {
        public BerletListViewModel()
        {
            this.Berletek = MainwindowViewModel.DatabaseController.getBerletek();
        }

        private List<Berlet> berletek;

        public List<Berlet> Berletek
        {
            get { return berletek; }
            set
            {
                berletek = value; this.RaisePropertyChanged();
            }
        }


        public string Header => "Berletek";
    }
}
