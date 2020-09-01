using UsefulUI.ViewModels.Calendar;
using ESIXamarinLib.Models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UsefulUI.Views.Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            this.BindingContext = new CalendarPageViewModel();
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }

        private void SelectedDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (this.monthView.CloseOnSelect)
                    {
                        if (this.BindingContext is CalendarPageViewModel vm)
                        {
                            vm.ShowCalendar = !vm.ShowCalendar;
                        }
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
            }
        }

        protected override void OnAppearing()
        {
            try
            {
                if (this.BindingContext is CalendarPageViewModel vm)
                {
                    vm.InitSelectedDates();
                    this.monthView.SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
                    this.monthView.InitCalendarMonthDisplay(vm.HasEventsOnDate, vm.ResetTitle);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }


        private void Calendar_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is CalendarPageViewModel vm)
            {
                //vm.ShowCalendar = !vm.ShowCalendar;
                this.monthView.SetCalendarDate(DateTime.Today);
                this.monthView.UpdateSelectedDate(DateTime.Today);
            }
        }

        private void Info_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is CalendarPageViewModel vm)
            {
                HelpPage helpPage = new HelpPage("Calendar Help");
                helpPage.BindingContext = vm.HelpList;
                this.Navigation.PushAsync(helpPage);
            }
        }

        private void Mode_Clicked(object sender, EventArgs e)
        {
            if (this.BindingContext is CalendarPageViewModel vm)
            {
                vm.WeekMode = !vm.WeekMode;
            }
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            // get the first item in selected dates and increment it.
            if (this.BindingContext is CalendarPageViewModel vm)
            {
                DateTime? currentSelectedDate = (vm.SelectedDates != null && vm.SelectedDates.Count > 0) ? vm.SelectedDates[0] : (DateTime?)null;
                if (currentSelectedDate.HasValue)
                {
                    DateTime nextDT = currentSelectedDate.Value.AddDays(1);
                    this.monthView.UpdateSelectedDate(nextDT);
                }
            }
        }

        private void PrevButton_Clicked(object sender, EventArgs e)
        {
            // get the first item in selected dates and increment it.
            if (this.BindingContext is CalendarPageViewModel vm)
            {
                DateTime? currentSelectedDate = (vm.SelectedDates != null && vm.SelectedDates.Count > 0) ? vm.SelectedDates[0] : (DateTime?)null;
                if (currentSelectedDate.HasValue)
                {
                    DateTime nextDT = currentSelectedDate.Value.AddDays(-1);
                    this.monthView.UpdateSelectedDate(nextDT);
                }
            }
        }
    }
}