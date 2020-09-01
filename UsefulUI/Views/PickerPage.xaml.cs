using UsefulUI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        public PickerPage()
        {
            this.BindingContext = new PickerPageViewModel();
            InitializeComponent();
        }

        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is PickerPageViewModel vm)
            {
                HelpPage helpPage = new HelpPage("Picker Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }
    }
}