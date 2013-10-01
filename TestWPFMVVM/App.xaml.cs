using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace TestWPFMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            List<ResourceDictionary> resources = new List<ResourceDictionary>();
            foreach (ViewModels.ContentViewViewModel contentView in ViewCollections.ContentViews)
                resources.Add(new ResourceDictionary() { Source = new Uri(contentView.ResourceFile) });

            MainWindow window = new MainWindow(resources);
           
            window.Show();
        }


        ViewModels.ContentViewCollectionViewModel viewCollections;
        protected ViewModels.ContentViewCollectionViewModel ViewCollections
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
