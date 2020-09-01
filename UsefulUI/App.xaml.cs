using UsefulUI.Services;
using Xamarin.Forms;

namespace UsefulUI
{
    public partial class App : Application
    {
        public static int screenHeight, screenWidth;
        public App()
        {
            InitializeComponent();
            Plugin.Iconize.Iconize
                .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
                .With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule());
            //.With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
            //.With(new Plugin.Iconize.Fonts.MaterialModule());

            DependencyService.Register<MenuDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
