using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppPro.Common.Interfaces;
using WpfAppPro.Common.MVVM;

namespace WpfAppPro.ViewModels.UserControl
{
    public class SortByViewModel : ViewModelBase, ISortByContent
    {
        public SortByViewModel()
        {
            refreshList();
            this.DeleteCommand = new RelayCommand(this.DeleteCommandExecute, this.DeleteCommandCanExecute);
            this.AddCommand = new RelayCommand(this.AddCommandExecute);
            this.UpdateCommand = new RelayCommand(this.UpdateCommandExecute, this.DeleteCommandCanExecute);
        }

        private void AddCommandExecute()
        {
            MainwindowViewModel.Instance.SelectedContent = MainwindowViewModel.Instance.Contents[1];
        }

        private void UpdateCommandExecute()
        {
            UpdateUserViewModel up = new UpdateUserViewModel(SelectedItem);
            MainwindowViewModel.Instance.Contents.Add(up);
            MainwindowViewModel.Instance.SelectedContent = up;
        }

        private bool DeleteCommandCanExecute()
        {
            if (SelectedItem != null)
            {
                return true;
            }
            return false;
        }

        private void DeleteCommandExecute()
        {
            MainwindowViewModel.DatabaseController.deleteUser(SelectedItem);
            refreshList();
        }

        private List<User> users;

        public List<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                this.RaisePropertyChanged();
            }
        }

        private User selectedItem;

        public User SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; this.RaisePropertyChanged(); }
        }


        public void refreshList()
        {
            Users = MainwindowViewModel.DatabaseController.getUsers();
        }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ExportClientsCommand { get; set; }

        public string Header => "Kliensek";
    }
}
