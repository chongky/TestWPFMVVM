using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

using TestWPFMVVM.Models;

using System.ComponentModel;

namespace TestWPFMVVM.ViewModels
{
    public class ContentTreeViewModel : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        #region Constructors

        public ContentTreeViewModel(List<Content> contents)
        {
            this.contents = new ObservableCollection<ContentViewModel>
                (
                (from c in contents
                 select new ContentViewModel(c)).ToList()
                 );

            foreach (ContentViewModel c in Contents)
                AddContentSelectedChangedHandler(c);

        }

        #endregion


        #region Fields

        private ObservableCollection<ContentViewModel> contents;
        private ContentViewModel selectedContent;
        private ObservableCollection<ContentViewModel> folders;

        #endregion


        #region Properties

        public ObservableCollection<ContentViewModel> Contents
        {
            get { return contents; }
        }

        public ContentViewModel SelectedContent
        {
            get
            {
                if (selectedContent == null)
                {
                    // create a dummy content
                    selectedContent = new ContentViewModel(new Content() { Name = "No item selected." });
                }
                return selectedContent;
            }
            set
            {
                this.selectedContent = value;

                OnPropertyChanged("SelectedContent");
            }
        }

        public ObservableCollection<ContentViewModel> Folders
        {
            get
            {
                if (folders == null)
                {
                    // get folder only into the collection
                    List<ContentViewModel> folderList = new List<ContentViewModel>();
                }

                return folders;
            }
        }

        #endregion


        #region Methods

        public void ContentSelectedChanged(object sender, ContentSelectedEventArgs e)
        {
            //this.SelectedContent = e.Content;
            //this.selectedContent.Name = e.Content.Name;
            //this.selectedContent.ContentType = e.Content.ContentType;

            //this.SelectedContent.Children.Clear();

            //foreach (ContentViewModel child in e.Content.Children)
            //    this.selectedContent.Children.Add(child);
        }

        protected void AddContentSelectedChangedHandler(ContentViewModel c)
        {
            // add handler
            c.SelectedContentChanged += this.ContentSelectedChanged;

            if (c.Children.Count > 0)
                foreach (ContentViewModel child in c.Children)
                    AddContentSelectedChangedHandler(child);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
