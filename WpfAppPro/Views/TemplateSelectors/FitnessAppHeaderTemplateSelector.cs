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
    public class FitnessAppHeaderTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IFitnessContent)
            {
                return Application.Current.MainWindow.TryFindResource("DefaultHeaderTemplate") as DataTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
