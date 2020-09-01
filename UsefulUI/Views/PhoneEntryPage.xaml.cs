
using UsefulUI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhoneEntryPage : ContentPage
    {
        public PhoneEntryPage()
        {
            PhoneEntryPageViewModel  vm = new PhoneEntryPageViewModel();           
            this.BindingContext = vm;
            InitializeComponent();
            this.phoneControl.FormatPhoneNumber = vm.FormatPhoneNumber;
        }

        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is PhoneEntryPageViewModel vm)
            {
                HelpPage helpPage = new HelpPage("Phone Entry Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }
    }
}