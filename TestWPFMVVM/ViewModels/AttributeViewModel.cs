using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace TestWPFMVVM.ViewModels
{
    public class AttributeViewModel : INotifyPropertyChanged
    {
        private string name;
        private object val;

        public string Name
        {
            get { return name; }
            set{
                if (name != value)
                    name = value;

                OnPropertyChanged("Name");
            }
        }

        public object Value
        {
            get { return val; }
            set
            {
                if (val == null || !val.Equals(value))
                    val = value;

                OnPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
