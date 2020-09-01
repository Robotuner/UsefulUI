using UsefulUI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateAndTimePage : ContentPage
    {
        public DateAndTimePage()
        {
            this.BindingContext = new DateAndTimePageViewModel();
            InitializeComponent();
        }

        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is DateAndTimePageViewModel vm)
            {
                HelpPage helpPage = new HelpPage("Date And Time Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }
    }
}