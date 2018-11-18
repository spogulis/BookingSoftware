using BookingSoftware.View;
using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BookingSoftware.ViewModel
{
    public class BaseViewModel : ValidatableBindableBase
    {
        //public event PropertyChangedEventHandler PropertyChanged;
                
        //protected void OnPropertyChanged(string info)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(info));
        //    }
        //}
    }
}
