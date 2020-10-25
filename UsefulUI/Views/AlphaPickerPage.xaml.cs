using System;
using UsefulUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlphaPickerPage : ContentPage
    {
        public AlphaPickerPage()
        {
            AlphaPageViewModel vm = new AlphaPageViewModel();
            this.BindingContext = vm;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (this.BindingContext is AlphaPageViewModel vm)
            {
                //for (char i = 'A'; i <= 'Z'; i++)
                //{
                //    vm.AlphaList.Add(new SearchItem(i.ToString(), i.ToString(), null));
                //}
                //vm.SelectedFilter = vm.AlphaList.First();
            }
        }
        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is AlphaPageViewModel vm)
            {
                HelpPage helpPage = new HelpPage("Alpha Picker Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }

    }
}