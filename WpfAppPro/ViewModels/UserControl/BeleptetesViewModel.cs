using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppPro.Common.Interfaces;
using WpfAppPro.Common.MVVM;

namespace WpfAppPro.ViewModels.UserControl
{
    public class BeleptetesViewModel : ViewModelBase, IBeleptetes
    {
        public string Header => "Beleptetes";
        public RelayCommand belepescommand { get;set; }


        public BeleptetesViewModel()
        {
            this.users = MainwindowViewModel.DatabaseController.getUsers();
            this._berletek = new List<Berlet>();
            this.belepescommand = new RelayCommand(belepesexecute, canexecutebelepes);
        }

        private void belepesexecute()
        {
            MainwindowViewModel.DatabaseController.belepes(this.selectedberlet);
            this.selectedberlet = null;
            this.berletek = MainwindowViewModel.DatabaseController.getUserBerletek(this.selecteduser);
        }

        private bool canexecutebelepes()
        {
            if (this.selectedberlet != null && this.selectedberlet.Aktiv == true)
            {
                return true;
            }
            return false;
        }

        private Berlet _selectedberlet;
        public Berlet selectedberlet
        {
            get
            {
                return this._selectedberlet;
            }
            set
            {
                this._selectedberlet = value;
                this.RaisePropertyChanged();
            }
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
                this.berletek = MainwindowViewModel.DatabaseController.getUserBerletek(this.selecteduser);
                this.RaisePropertyChanged();
            }
        }

        private List<Berlet> _berletek;

        public List<Berlet> berletek
        {
            get
            {
                return this._berletek;
            }
            set
            {
                this._berletek = value;
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
    }
}
