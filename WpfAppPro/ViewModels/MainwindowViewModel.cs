using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppPro.Common.Interfaces;
using WpfAppPro.Common.MVVM;
using WpfAppPro.Logic;
using WpfAppPro.ViewModels.UserControl;

namespace WpfAppPro.ViewModels
{
    public class MainwindowViewModel : ViewModelBase
    {
        public static DatabaseController DatabaseController;
        public static AddErtekViewModel addertek;
        public MainwindowViewModel()
        {
            DatabaseController = new DatabaseController();
            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);
            this.Contents = new ObservableCollection<IFitnessContent>();
            SortByViewModel sortByViewModel = new SortByViewModel();
            this.Contents.Add(sortByViewModel);
            this.SelectedContent = sortByViewModel;
            AddUserViewModel addUserViewModel = new AddUserViewModel(sortByViewModel);
            this.Contents.Add(addUserViewModel);
            AddTipusViewModel addTipus = new AddTipusViewModel();
            this.Contents.Add(addTipus);
            addertek = new AddErtekViewModel();
            this.Contents.Add(addertek);
            AddBerletViewModel addberlet = new AddBerletViewModel();
            this.Contents.Add(addberlet);
            BeleptetesViewModel beleptetes = new BeleptetesViewModel();
            this.Contents.Add(beleptetes);
            BerletListViewModel berletlist = new BerletListViewModel();
            this.Contents.Add(berletlist);
            Instance = this;

        }

        public static MainwindowViewModel Instance { get; private set; }

        private ObservableCollection<IFitnessContent> contents;

        public ObservableCollection<IFitnessContent> Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        private IFitnessContent selectedContent;

        public IFitnessContent SelectedContent
        {
            get { return selectedContent; }
            set
            {
                selectedContent = value;
                this.RaisePropertyChanged();
            }
        }

        private void CloseCommandExecute()
        {
            ViewService.CloseDialog(this);
        }

        public RelayCommand CloseCommand { get; set; }
    }
}
