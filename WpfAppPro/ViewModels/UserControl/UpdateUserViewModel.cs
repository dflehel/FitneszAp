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
    public class UpdateUserViewModel : ViewModelBase, IUpdateClientContent
    {
        private User user;
        public UpdateUserViewModel(User u)
        {
            this.user = u;
            this.PictureChooseCommand = new RelayCommand(this.PictureChooseExecute);
            this.UpdateClientCommand = new RelayCommand(this.UpdateClientExecute, this.UpdateClientCanExecute);
            this.Last_Name = user.Last_Name;
            this.First_name = user.First_Name;
            this.Img = user.Picture;
        }

        private bool UpdateClientCanExecute()
        {
            if (Last_Name != null && First_name != null)
            {
                return true;
            }
            return false;
        }

        private void UpdateClientExecute()
        {
            user.Last_Name = Last_Name;
            user.First_Name = First_name;
            user.Picture = Img;
            MainwindowViewModel.DatabaseController.updateUser(user);
            MainwindowViewModel.Instance.Contents.Remove(this);
            MainwindowViewModel.Instance.SelectedContent = MainwindowViewModel.Instance.Contents[0];
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


        public string Header => "Update Client";

        public RelayCommand PictureChooseCommand { get; set; }
        public RelayCommand UpdateClientCommand { get; set; }
    }
}
