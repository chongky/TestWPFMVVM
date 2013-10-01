using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using TestWPFMVVM.ViewModels;

// testing

namespace TestWPFMVVM
{
    public static class AppSettings
    {
        public static List<ResourceDictionary> GetResources(string name)
        {
            List<ResourceDictionary> resources = null;

            switch (name)
            {
                case "contentView":
                    resources = new List<ResourceDictionary>();
                    foreach (ViewModels.ContentViewViewModel contentView in ViewCollections.ContentViews)
                        resources.Add(new ResourceDictionary() { Source = new Uri(contentView.ResourceFile) });

                    break;

                default:
                    break;
            }

            return resources;
        }



        private static ViewModels.ContentViewCollectionViewModel viewCollections;
        private static ViewModels.ContentViewCollectionViewModel ViewCollections
        {
            get
            {
                if (viewCollections == null)
                    viewCollections = new ViewModels.ContentViewCollectionViewModel();

                return viewCollections;
            }
        }
    }
}
