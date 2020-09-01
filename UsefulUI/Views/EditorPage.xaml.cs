using UsefulUI.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditorPage : ContentPage
    {
        public EditorPage()
        {
            this.BindingContext = new EditorPageViewModel();
            InitializeComponent();
        }

        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is EditorPageViewModel vm)
            {
                HelpPage helpPage = new HelpPage("Editor Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }
    }
}