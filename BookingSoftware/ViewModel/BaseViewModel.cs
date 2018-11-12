using BookingSoftware.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BookingSoftware.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public Page _currentView;

        //public Page CurrentView
        //{
        //    get
        //    {
        //        return _currentView;
        //    }
        //    set
        //    {
        //        CurrentView = value;
        //        OnPropertyChanged("CurrentView");
        //    }
        //}

        
        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
