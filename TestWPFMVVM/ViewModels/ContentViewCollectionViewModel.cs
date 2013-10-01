using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;

namespace TestWPFMVVM.ViewModels
{
    public class ContentViewCollectionViewModel : INotifyPropertyChanged
    {

        public ContentViewCollectionViewModel()
        {
            // load content views from file
            FileInfo fi = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string resourceFolder = Path.Combine(fi.Directory.FullName, "Resources");

            string[] resourceFiles = Directory.GetFiles(resourceFolder, "*.xaml");
            
            List<ContentViewViewModel> contentViews1 = new List<ContentViewViewModel>();

            foreach (string resourceFile in resourceFiles)
            {
                fi = new FileInfo(resourceFile);

                contentViews1.Add(new ContentViewViewModel() { Name = fi.Name.Substring(0, fi.Name.Length - 5), Key=fi.Name.Substring(0, fi.Name.Length - 5), ResourceFile = fi.FullName });
            }

            contentViews = new ReadOnlyCollection<ContentViewViewModel>(contentViews1);
        }

        private ReadOnlyCollection<ContentViewViewModel> contentViews;

        public ReadOnlyCollection<ContentViewViewModel> ContentViews
        {
            get { return contentViews; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
