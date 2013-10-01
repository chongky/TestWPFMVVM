using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestWPFMVVM.ViewModels;

namespace TestWPFMVVM
{
    public class ContentSelectedEventArgs
    {
        ContentViewModel content;

        public ContentSelectedEventArgs()
        {
        }

        public ContentSelectedEventArgs(ContentViewModel content)
        {
            this.content = content;
        }

        public ContentViewModel Content
        {
            get { return content; }
        }
    }
}
