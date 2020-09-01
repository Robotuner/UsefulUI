using UsefulUI.ViewModels;
using UsefulUI.Views.MultiColumnGrid;
using ESIXamarinLib.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiColumnGridPage : ContentPage
    {
        public MultiColumnGridPage()
        {
            this.BindingContext = new MultiColumnGridViewModel();
            InitializeComponent();
        }

        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is MultiColumnGridViewModel vm)
            {
                HelpPage helpPage = new HelpPage("MultiFilter Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }


        protected override void OnAppearing()
        {
            if (this.BindingContext is MultiColumnGridViewModel vm)
            {
                this.MFilterGrid.ViewSelector = this.ViewSelector;
                this.MFilterGrid.InitGrid();
            }
        }


        private void AddButton_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is MultiColumnGridViewModel vm)
            {
                int index = RandomLib.random.Next(0, vm.FilterList.Count);
                SearchItem si = vm.NewSearchItem(String.Format("Filter {0}", vm.fcount + 1));      
                vm.FilterList.Insert(index, si);
            }
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is MultiColumnGridViewModel vm)
            {
                int index = RandomLib.random.Next(0, vm.FilterList.Count);
                vm.FilterList.RemoveAt(index);
            }
        }

        private bool demoDataTemplateSelector = false;
        private View ViewSelector(ISearchItem item)
        {
            if (demoDataTemplateSelector)
            {
                // this is an example of using a dataTemplate selector
                int id = int.Parse(item.ID);
                string dataTemplateKey = id % 2 == 0 ? "TemplateA" : "TemplateB";
                if (id % 3 == 0) dataTemplateKey = "TemplateC";
                DataTemplate dt = this.Resources[dataTemplateKey] as DataTemplate;
                if (dt != null)
                {
                    return dt.CreateContent() as View;
                }
                return null;
            }
            else
            {
                // this is an example of using a single template for all grid cells
                return new MGCheckBoxFilter();
            }

        }
    }
}