using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

namespace TestWPFMVVM.Models
{
    public class Content
    {

        private string name;
        private List<Content> children = new List<Content>();
        private string contentType;


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        public List<Content> Children
        {
            get { return children; }
        }

        public bool HasChildren
        {
            get { return Children.Count > 0; }
        }
    }
}
