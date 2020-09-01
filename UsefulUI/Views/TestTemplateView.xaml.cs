using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestTemplateView : ContentView
    {
        public TestTemplateView()
        {
            InitializeComponent();
        }
    }
}