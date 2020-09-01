
using ESIXamarinLib.FAViewer.ViewModels;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.FAViewer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FAViewer : ContentPage
    {
        public FAViewer()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (this.BindingContext is FAViewerViewModel vm)
            {
                vm.SelectedFont = vm.FontList.FirstOrDefault();
            }
        }

         async void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (this.BindingContext is FAViewerViewModel vm)
            {
                await vm.RefreshFilter((sender as Entry).Text);
            }
        }
    }
}