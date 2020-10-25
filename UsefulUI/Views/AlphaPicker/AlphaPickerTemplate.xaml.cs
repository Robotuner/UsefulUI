
using ESIXamarinLib.Controls.ViewModels;
using ESIXamarinLib.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views.AlphaPicker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlphaPickerTemplate : ContentView
    {
        public AlphaPickerTemplate()
        {
            InitializeComponent();
        }

        //private void SearchableList_Tapped(object sender, TappedEventArgs e)
        //{
        //    if ((sender is StackLayout))
        //    {
        //        if (e.Parameter is ISearchItem item)
        //        {
        //            string result = item.Name;
        //        }
        //    }
        //}
    }
}