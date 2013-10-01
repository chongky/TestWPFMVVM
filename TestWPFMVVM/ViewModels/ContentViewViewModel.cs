using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace TestWPFMVVM.ViewModels
{
    public class ContentViewViewModel : INotifyPropertyChanged
    {
        private string name;
        private string resourceFile;
        private string key;

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                    name = value;

                OnPropertyChanged("Name");
            }
        }

        public string ResourceFile
        {
            get { return resourceFile; }
            set
            {
                if (resourceFile != value)
                    resourceFile = value;

                OnPropertyChanged("ResourceFile");
            }
        }

        public string Key
        {
            get { return key; }
            set
            {
                if (key != value)
                    key = value;

                OnPropertyChanged("Key");
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
