using ESIXamarinLib.FAViewer.Views;
using System;
using System.ComponentModel;
using UsefulUI.Models;
using UsefulUI.ViewModels;
using UsefulUI.Views.Calendar;
using Xamarin.Forms;

namespace UsefulUI.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            switch (item.PageType)
            {
                case PageType.calendarControl:
                    await Navigation.PushAsync(new CalendarPage());
                    break;
                case PageType.fontAwesomeViewer:
                    await Navigation.PushAsync(new FAViewer());
                    break;
                case PageType.controlTester:
                    await Navigation.PushAsync(new ControlTesterPage());
                    break;
                case PageType.search:
                    await Navigation.PushAsync(new SearchPage());
                    break;
                case PageType.dateAndTime:
                    await Navigation.PushAsync(new DateAndTimePage());
                    break;
                case PageType.phoneEntry:
                    await Navigation.PushAsync(new PhoneEntryPage());
                    break;
                case PageType.picker:
                    await Navigation.PushAsync(new PickerPage());
                    break;
                case PageType.entry:
                    await Navigation.PushAsync(new EntryPage());
                    break;
                case PageType.editor:
                    await Navigation.PushAsync(new EditorPage());
                    break;
                case PageType.multiColumnGrid:
                    await Navigation.PushAsync(new MultiColumnGridPage());
                    break;
                case PageType.labelButton:
                    await Navigation.PushAsync(new LabelButton());
                    break;
                case PageType.alphaPicker:
                    await Navigation.PushAsync(new AlphaPickerPage());
                    break;
                default:
                        await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
                    break;
            }
        }

        //async void AddItem_Clicked(object sender, EventArgs e)
        //{
        //    await Task.CompletedTask;
        //    //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}