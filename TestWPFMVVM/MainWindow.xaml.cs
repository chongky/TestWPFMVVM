using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using TestWPFMVVM.Repository;
using TestWPFMVVM.ViewModels;

namespace TestWPFMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // generate contents for testing
            ContentRepository rep = new ContentRepository();
            ContentTreeViewModel viewModel = new ContentTreeViewModel(rep.Select());
            ContentViewCollectionViewModel col = new ContentViewCollectionViewModel();


            this.tvExplorer.DataContext = viewModel;
            this.cboView.DataContext = col;

            //this.listView1.DataContext = viewModel.Contents[0];
            this.DataContext = viewModel.Contents[0].Children;


            //this.lstContents.DataContext = viewModel.Contents[0];
            //this.pnlSelected.DataContext = viewModel.SelectedContent;

        }

        public MainWindow(List<ResourceDictionary> resources)
            : this()
        {
            foreach (ResourceDictionary res in resources)
                this.Resources.MergedDictionaries.Add(res);

            ApplyContentViewTemplate("list");
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            ApplyContentViewTemplate("list");
        }

        private void btnTile_Click(object sender, RoutedEventArgs e)
        {
            ApplyContentViewTemplate("tile");
        }

        protected void ApplyContentViewTemplate(string templateName)
        {
            DataTemplate template = (DataTemplate)this.TryFindResource(templateName);

            if (template != null)
                lstContents.ItemTemplate = template;
        }

        private void cboView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTemplate template = (DataTemplate)this.TryFindResource(cboView.SelectedValue.ToString());

            if (template != null)
                lstContents.ItemTemplate = template;

            
        }

        private void cboView_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            
        }

    }
}
