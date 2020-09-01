using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarResources : ResourceDictionary
    {
        public CalendarResources()
        {

        }

        public void SetResourceColor(string key, Color color)
        {
            this[key] = color;
        }
    }
}