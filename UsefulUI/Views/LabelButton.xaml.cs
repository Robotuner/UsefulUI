using UsefulUI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelButton : ContentPage
    {
        public LabelButton()
        {
            InitializeComponent();
        }

        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is LabelButtonViewModel vm)
            {
                HelpPage helpPage = new HelpPage("Label Button Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }
    }
}