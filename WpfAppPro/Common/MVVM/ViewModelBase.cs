using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppPro.Common.MVVM
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class ViewModelBase: INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="name">The name.</param>
        public void RaisePropertyChanged([CallerMemberName]string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
