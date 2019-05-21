using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppPro.Common.Interfaces;
using WpfAppPro.Common.MVVM;

namespace WpfAppPro.ViewModels.UserControl
{
    public class AddErtekViewModel : ViewModelBase, IAddErtekcontent
    {
        public string Header => "Ertek adas";
        public RelayCommand addingertekcommand { get; set; }
        public AddErtekViewModel()
        {
            this.tipus = MainwindowViewModel.DatabaseController.GetTipus();
            this.erteks = MainwindowViewModel.DatabaseController.GetErteks();
            this.addingertekcommand = new RelayCommand(addingertekexecute);
            this.mikortol = System.DateTime.Now;
            this.meddig = System.DateTime.Now;
        }

        private void addingertekexecute()
        {
            MainwindowViewModel.DatabaseController.AddErtek(this.mikortol, this.meddig, this.ar, this.tipu);
            this.erteks = MainwindowViewModel.DatabaseController.GetErteks();
        }

        private List<Tipu> _tipus;

        public List<Tipu> tipus
        {
            get
            {
                return this._tipus;
            }
            set
            {
                this._tipus = value;
                this.RaisePropertyChanged();
            }
        }

        private System.DateTime _mikortol;

        public System.DateTime mikortol
        {
            get
            {
                return this._mikortol;
            }
            set
            {
                this._mikortol = value;
                this.RaisePropertyChanged();
            }
        }

        private System.DateTime _meddig;

        public System.DateTime meddig
        {
            get
            {
                return this._meddig;
            }
            set
            {
                this._meddig = value;
                this.RaisePropertyChanged();
            }
        }

        private string _ar;

        public string ar
        {
            get
            {
                return this._ar;
            }
            set
            {
                this._ar = value;
                this.RaisePropertyChanged();
            }
        }

        private List<Ertek> _erteks;

        public List<Ertek> erteks
        {
            get
            {
                return this._erteks;
            }
            set
            {
                this._erteks = value;
                this.RaisePropertyChanged();
            }
        }

        private Tipu _tipu;

        public Tipu tipu
        {
            get
            {
                return this._tipu;
            }
            set
            {
                this._tipu = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
