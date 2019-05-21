using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppPro.Common.Interfaces;
using WpfAppPro.Common.MVVM;

namespace WpfAppPro.ViewModels.UserControl
{
    public class AddBerletViewModel : ViewModelBase, IAddBerletContent
    {
        public string Header => "Berlet vasarlas";
        public RelayCommand slectingcommand { get; set; }
        public RelayCommand addcommand { get; set; }

        public AddBerletViewModel()
        {
            this.users = MainwindowViewModel.DatabaseController.getUsers();
            this.tipus = MainwindowViewModel.DatabaseController.GetTipus();
            this.slectingcommand = new RelayCommand(executeselec, canecexute);
            this.addcommand = new RelayCommand(executeadd, canexecuteadd);

        }

        private User _selecteduser;

        public User selecteduser
        {
            get
            {
                return this._selecteduser;
            }
            set
            {
                this._selecteduser = value;
                this.RaisePropertyChanged();
            }
        }

        private Tipu _selectedtipus;

        public Tipu selectedtipus
        {
            get
            {
                return this._selectedtipus;
            }
            set
            {
                this._selectedtipus = value;
                this.RaisePropertyChanged();
            }
        }


        private bool canexecuteadd()
        {
            if(this.selecteduser !=null && this.selectedtipus != null && this.hanyalkalom != null)
            {
                return true;
            }
            return false;
        }

        private void executeadd()
        {
            if (this._daysselected)
            {
                Berlet b = new Berlet();
                b.Idotartam = Int32.Parse(this.hanyalkalom);
                b.Napok = new byte[7];
                int szamlalo = 0;
                foreach (bool nap in this._napok)
                {
                    if (nap)
                    {
                        b.Napok[szamlalo] = 1;
                    }
                    else
                    {
                        b.Napok[szamlalo] = 0;
                    }
                    szamlalo = szamlalo + 1;
                }
                b.Belepesek_szama = 0;
                b.Aktiv = true;
                if (this.kezdet != null)
                {
                    b.Kezdeti_ora = Int32.Parse(this.kezdet);
                }
                if (this.veg != null)
                {
                    b.Veg_ora = Int32.Parse(this.veg);
                }
                Vasarolt v = new Vasarolt();
                v.Berlet = b;
                v.User = this.selecteduser;
                Ertek e = MainwindowViewModel.DatabaseController.getErtekByTipus(this.selectedtipus);
                this.ar = e.Ar.ToString();
                v.Ertek1 = e;
                MainwindowViewModel.DatabaseController.addBerlet(b);
                MainwindowViewModel.DatabaseController.addVasarlas(v);
                MessageBox.Show("Sikeres Vasarlas");
            }
            else
            {
                Berlet b = new Berlet();
                b.Idotartam = Int32.Parse(this.hanyalkalom);
                b.Napok = new byte[7];
                int szamlalo = 0;
                b.Belepesek_szama = 0;
                b.Aktiv = true;
                if (this.kezdet != null)
                {
                    b.Kezdeti_ora = Int32.Parse(this.kezdet);
                }
                if (this.veg != null)
                {
                    b.Veg_ora = Int32.Parse(this.veg);
                }
                Vasarolt v = new Vasarolt();
                v.Berlet = b;
                v.User = this.selecteduser;
                Ertek e = MainwindowViewModel.DatabaseController.getErtekByTipus(this.selectedtipus);
                this.ar = e.Ar.ToString();
                v.Ertek1 = e;
                MainwindowViewModel.DatabaseController.addBerlet(b);
                MainwindowViewModel.DatabaseController.addVasarlas(v);
                MessageBox.Show("Sikeres Vasarlas");
            }
        }

        private string _hanyalkalom;

        public string hanyalkalom
        {
            get
            {
               return this._hanyalkalom;
            }
            set
            {
                this._hanyalkalom = value;
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

        private void executeselec()
        {
            
        }

        private bool canecexute()
        {
            return this.daysselected;
        }

        private bool _daysselected;

        public bool daysselected
        {
            get
            {
                return this._daysselected;
            }
            set
            {
                this._daysselected = value;
                this.RaisePropertyChanged();
            }
        }


        private List<User> _users;

        public List<User> users
        {
            get
            {
                return this._users;
            }
            set
            {
                this._users = value;
                this.RaisePropertyChanged();
            }
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

        private string _kezdet;

        public string kezdet
        {
            get
            {
                return this._kezdet;
            }
            set
            {
                this._kezdet = value;
                this.RaisePropertyChanged();
            }

        }

        private string _veg;
        
        public string veg
        {
            get
            {
                return this._veg;
            }
            set
            {
                this._veg = value;
                this.RaisePropertyChanged();
            }
        }

        private bool[]  _napok = new bool[7];

        public bool hetfo
        {
            get
            {
                return this._napok[0];
            }
            set
            {
                this._napok[0] = value;
                this.RaisePropertyChanged();
            }
        }

        public bool kedd
        {
            get
            {
                return this._napok[1];
            }
            set
            {
                this._napok[1] = value;
                this.RaisePropertyChanged();
            }
        }

        public bool szerda
        {
            get
            {
                return this._napok[2];
            }
            set
            {
                this._napok[2] = value;
                this.RaisePropertyChanged();
            }
        }

        public bool csut
        {
            get
            {
                return this._napok[3];
            }
            set
            {
                this._napok[3] = value;
                this.RaisePropertyChanged();
            }
        }

        public bool pentek
        {
            get
            {
                return this._napok[4];
            }
            set
            {
                this._napok[4] = value;
                this.RaisePropertyChanged();
            }
        }

        public bool szombat
        {
            get
            {
                return this._napok[5];
            }
            set
            {
                this._napok[5] = value;
                this.RaisePropertyChanged();
            }
        }

        public bool vasarnap
        {
            get
            {
                return this._napok[6];
            }
            set
            {
                this._napok[6] = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
