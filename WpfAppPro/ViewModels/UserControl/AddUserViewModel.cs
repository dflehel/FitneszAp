using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppPro.Common.Interfaces;
using WpfAppPro.Common.MVVM;

namespace WpfAppPro.ViewModels.UserControl
{
    public class AddUserViewModel : ViewModelBase, IAddClientContent
    {
        private static SortByViewModel instance;
        public AddUserViewModel(SortByViewModel s)
        {
            instance = s;
            this.PictureChooseCommand = new RelayCommand(this.PictureChooseExecute);
            this.AddClientCommand = new RelayCommand(this.AddClientExecute, this.AddClientCanExecute);
        }

        private bool AddClientCanExecute()
        {
            if (Last_Name != null && First_name != null && Kod != null)
            {
                return true;
            }
            return false;
        }

        private void AddClientExecute()
        {
            if (Img == null)
            {
                MainwindowViewModel.DatabaseController.AddUser(First_name,Last_Name, Kod);
            }
            else
            {
                MainwindowViewModel.DatabaseController.AddUser(First_name,Last_Name, Kod, Img);
            }
            clearFields();
            instance.refreshList();
        }

        private void PictureChooseExecute()
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".png";
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                Img = File.ReadAllBytes(dialog.FileName);
            }
        }

        private byte[] img;

        public byte[] Img
        {
            get { return img; }
            set
            {
                img = value;
                this.RaisePropertyChanged();
            }
        }

        private string last_name;

        public string Last_Name
        {
            get { return last_name; }
            set { last_name = value; this.RaisePropertyChanged(); }
        }

        private string first_name;

        public string First_name
        {
            get { return first_name; }
            set { first_name = value; this.RaisePropertyChanged(); }
        }

        private string kod;

        public string Kod
        {
            get { return kod; }
            set { kod = value; this.RaisePropertyChanged(); }
        }


        public RelayCommand AddClientCommand { get; set; }

        public RelayCommand PictureChooseCommand { get; set; }

        public string Header => "Add Client";

        private void clearFields()
        {
            Last_Name = null;
            First_name = null;
            Kod = null;
            Img = null;
        }
    }
}
