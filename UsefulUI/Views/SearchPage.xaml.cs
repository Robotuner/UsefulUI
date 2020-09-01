using UsefulUI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            SearchPageViewModel vm = new SearchPageViewModel();         
            this.BindingContext = vm;
            InitializeComponent();
            this.searchControl.FilterChangeCallback = vm.FilterChanged;
        }

        protected override void OnAppearing()
        {
            if (this.BindingContext is SearchPageViewModel vm)
            {
                vm.OnAppearing();
            }
        }
        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is SearchPageViewModel vm)
            {
                HelpPage helpPage = new HelpPage("Phone Entry Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }
    }
}