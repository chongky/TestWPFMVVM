using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Collections.ObjectModel;

using TestWPFMVVM.Models;

namespace TestWPFMVVM.ViewModels
{
    public class ContentViewModel : INotifyPropertyChanged
    {
        // delegate for event
        public delegate void SelectedContentChangedHandler(object sender, ContentSelectedEventArgs e);
        // event handler
        public event SelectedContentChangedHandler SelectedContentChanged;


        private bool isExpanded;
        private bool isSelected;
        private ContentViewModel parent;
        private ReadOnlyCollection<ContentViewModel> children;
        private ReadOnlyCollection<AttributeViewModel> attributes;

        private Content content;


        protected void OnSelectedContentChanged(ContentSelectedEventArgs e)
        {
            if (SelectedContentChanged != null)
                SelectedContentChanged(this, e);
        }

        public ContentViewModel(Content content)
            : this(content, null)
        {

        }

        private ContentViewModel(Content content, ContentViewModel parent)
        {
            this.content = content;
            this.parent = parent;

            // load children
            children = new ReadOnlyCollection<ContentViewModel>(
                (from c in content.Children
                 select new ContentViewModel(c, this)).ToList()
                );

            // load attributes
            List<AttributeViewModel> attrList = new List<AttributeViewModel>();

            attrList.Add(new AttributeViewModel() { Name = "Name", Value = this.Name });
            attrList.Add(new AttributeViewModel() { Name = "Content Type", Value = this.ContentType });

            attributes = new ReadOnlyCollection<AttributeViewModel>(attrList);
        }

        public string Name
        {
            get { return content.Name; }
            set {
                content.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string ContentType
        {
            get { return content.ContentType; }
            set {
                content.ContentType = value;
                OnPropertyChanged("ContentType");
            }
        }

        public bool HasChildren
        {
            get { return Children.Count > 0; }
        }

        public bool HasParent
        {
            get { return Parent != null; }
        }

        public int ChildrenCount
        {
            get { return Children.Count; }            
        }

        public ContentViewModel Parent
        {
            get { return parent; }
        }

        public ReadOnlyCollection<ContentViewModel> Children
        {
            get { return children; }
        }

        public ReadOnlyCollection<AttributeViewModel> Attributes
        {
            get {                 
                return attributes;       
            }
        }

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                if (isExpanded != value)
                {
                    isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                if (isExpanded && parent != null)
                    parent.IsExpanded = true;
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                    this.OnSelectedContentChanged(new ContentSelectedEventArgs(this));
                }
            }
        }

        

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

    }
}
