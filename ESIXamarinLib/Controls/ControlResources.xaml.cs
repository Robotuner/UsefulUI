using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlResources : ResourceDictionary
    {
        public ControlResources()
        {

        }

        public void SetResourceColor(string key, Color color)
        {
            this[key] = color;
        }
    }
}