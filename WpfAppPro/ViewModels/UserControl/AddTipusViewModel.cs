using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppPro.Common.Interfaces;
using WpfAppPro.Common.MVVM;

namespace WpfAppPro.ViewModels.UserControl
{
    public class AddTipusViewModel : ViewModelBase, IAddTipusContent
    {
        public string Header => "Tipus hozza adas";
        public RelayCommand addingtipus { get; set; }
        
        public AddTipusViewModel()
        {
            this.tipus = MainwindowViewModel.DatabaseController.GetTipus();
            this.addingtipus = new RelayCommand(Addingtipusexecute);
        }

        private void Addingtipusexecute()
        {
            MainwindowViewModel.DatabaseController.AddTipus(this.leiras);
            this.tipus = MainwindowViewModel.DatabaseController.GetTipus();
            this.leiras = null;
            MainwindowViewModel.addertek.tipus = this.tipus;
        }

    


        private List<Tipu> _tipus;

        public List<Tipu> tipus
        {
            get { return this._tipus; }
            set
            {
                this._tipus = value;
                this.RaisePropertyChanged();
            }
        }

        private string _leiras;
        public string leiras
        {
            get
            {
                return this._leiras;
            }
            set
            {
                this._leiras = value;
                this.RaisePropertyChanged();
            }

        }
    }
}
