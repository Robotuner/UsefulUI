using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }
    }
}