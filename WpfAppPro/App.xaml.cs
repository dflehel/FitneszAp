using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppPro.Common.MVVM;
using WpfAppPro.ViewModels;

namespace WpfAppPro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Initialize();
            this.InitializeData();
            this.OpenMainWindow();
        }
        private void Initialize()
        {
            ViewService.RegisterView(typeof(MainwindowViewModel), typeof(MainWindow));
        }
        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainwindowViewModel mainWindowViewModel = new MainwindowViewModel();

            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainWindow);
            ViewService.ShowDialog(mainWindowViewModel);
        }
        private void InitializeData()
        {
            try

            {
                //      DBInitializer dbinit = new DBInitializer();
                //      dbinit.InitializeDatabase(new TMCatalogDB());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
