using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfAppPro.Common.Interfaces;

namespace WpfAppPro.Views.TemplateSelectors
{
    public class FitnessAppContentTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ISortByContent)
            {
                return Application.Current.MainWindow.TryFindResource("SortByViewModelTemplate") as DataTemplate;
            }
            if (item is IAddClientContent)
            {
                return Application.Current.MainWindow.TryFindResource("AddUserViewModelTemplate") as DataTemplate;
            }
            if (item is IAddTipusContent)
            {
                return Application.Current.MainWindow.TryFindResource("AddTipusTemplate") as DataTemplate;
            }
            if (item is IAddErtekcontent)
            {
                return Application.Current.MainWindow.TryFindResource("AddErtekTemplate") as DataTemplate;
            }
            if (item is IAddBerletContent)
            {
                return Application.Current.MainWindow.TryFindResource("AddBerletTamplate") as DataTemplate;
            }
            if (item is IUpdateClientContent)
            {
                return Application.Current.MainWindow.TryFindResource("UpdateUserViewModelTemplate") as DataTemplate;
            }
            if(item is IBeleptetes)
            {
                return Application.Current.MainWindow.TryFindResource("Beleptetestemplate") as DataTemplate;
            }
            if (item is IBerletListContent)
            {
                return Application.Current.MainWindow.TryFindResource("BerletListViewModelTemplate") as DataTemplate;
            }

         
            return base.SelectTemplate(item, container);
        }
    }
}
