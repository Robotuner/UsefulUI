using UsefulUI.Models;
using ESIXamarinLib.Calendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UsefulUI.ViewModels.Calendar
{
    public class CalendarPageViewModel : HelpPageViewModel
    {
        private Dictionary<int, string> MonthsDictionary = CalendarUtil.GetMonthsDictionary();

        private IIteratorItem selectedMonth;
        public IIteratorItem SelectedMonth
        {
            get { return selectedMonth; }
            set { SetProperty(ref selectedMonth, value); this.ResetTitle(); }
        }

        private IIteratorItem selectedYear;
        public IIteratorItem SelectedYear
        {
            get { return selectedYear; }
            set { SetProperty(ref selectedYear, value); this.ResetTitle(); }
        }

        private ObservableCollection<DateTime> selectedDates;
        public ObservableCollection<DateTime> SelectedDates
        {
            get { return selectedDates; }
            set { SetProperty(ref selectedDates, value);  }
        }

        private bool showCalendar;
        public bool ShowCalendar
        {
            get { return showCalendar; }
            set
            {
                if (showCalendar != value)
                {
                    showCalendar = value;
                    OnPropertyChanged("ShowCalendar");
                }
            }
        }

        private bool closeOnSelect;
        public bool CloseOnSelect
        {
            get { return closeOnSelect; }
            set
            {
                if (closeOnSelect != value)
                {
                    closeOnSelect = value;
                    OnPropertyChanged("CloseOnSelect");                    
                }
            }
        }

        private bool weekMode;
        public bool WeekMode
        {
            get { return weekMode; }
            set 
            { 
                SetProperty(ref weekMode, value); this.ResetTitle();                
            }
        }

        private string testText;
        public string TestText
        {
            get { return testText; }
            set
            {
                if (testText != value)
                {
                    testText = value;
                    OnPropertyChanged("TestText");
                }
            }
        }

        public CalendarPageViewModel()
        {
            this.TestText = "Hope this works";
            DateTime currentDate = DateTime.Today;
            this.SelectedMonth = (IteratorItem)new IteratorItem() { Id = currentDate.Month - 1, Name = MonthsDictionary[currentDate.Month - 1] }; 
            this.SelectedYear = (IteratorItem)new IteratorItem() { Id = currentDate.Year, Name = currentDate.Year.ToString() };
            this.ShowCalendar = true;

            this.SetHelp(Resource.CalendarHelp);
        }

        private void SelectedDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            switch(e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (DateTime dt in  this.SelectedDates)
                    {
                        string dateIs = dt.ToString();
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
            }
        }

        public ObservableCollection<ICalendarEvent> HasEventsOnDate(DateTime? date)
        {
            if (date == null)
                return null;

            string ffamily = Device.RuntimePlatform == Device.iOS ? "FontAwesome5Free-Solid" :  "FontAwesome5Solid.otf#Regular";
            FontSizeConverter fsc = new FontSizeConverter();
            //double fsize = (double)fsc.ConvertFromInvariantString("Micro");
            double fsize = 6;

            List<ICalendarEvent> allEvents = new List<ICalendarEvent>()
            {  
                new CalendarEvent() { Symbol=FontAwesome.Stop, FontFamily= ffamily, Color = Xamarin.Forms.Color.Aqua, FontSize=fsize},
                new CalendarEvent() { Symbol=FontAwesome.Stop, FontFamily= ffamily, Color = Xamarin.Forms.Color.Bisque, FontSize=fsize },
                new CalendarEvent() { Symbol=FontAwesome.Stop, FontFamily= ffamily, Color = Xamarin.Forms.Color.Brown, FontSize=fsize },
                new CalendarEvent() { Symbol=FontAwesome.Stop, FontFamily= ffamily, Color = Xamarin.Forms.Color.Teal, FontSize=fsize },
                new CalendarEvent() { Symbol=FontAwesome.Stop, FontFamily= ffamily, Color = Xamarin.Forms.Color.Salmon, FontSize=fsize },
                new CalendarEvent() { Symbol=FontAwesome.Stop, FontFamily= ffamily, Color = Xamarin.Forms.Color.SeaGreen, FontSize=fsize },
                new CalendarEvent() { Symbol=FontAwesome.Stop, FontFamily= ffamily, Color = Xamarin.Forms.Color.Fuchsia, FontSize=fsize }
            };

            Random random = new Random();
            int num = random.Next(0, allEvents.Count);
            ObservableCollection<ICalendarEvent> events = new ObservableCollection<ICalendarEvent>();
            int maxEventsPerDay = 4;
            int eventsToDisplay = num > maxEventsPerDay ? maxEventsPerDay : num;
            ICalendarEvent currentEvent = null;
            for (int n=0; n< eventsToDisplay; n++)
            {
                int ndx = random.Next(0, allEvents.Count);
                currentEvent = allEvents[ndx];
                events.Add(currentEvent);
            }
            return events;
        }

        public void ResetTitle()
        {
            if (SelectedMonth != null && SelectedYear != null)
            {
                this.Title = string.Format("{0} {1}", this.MonthsDictionary[SelectedMonth.Id], SelectedYear.Id);
            }
            else
            {
                this.Title = "Calendar";
            }
        }

        public void InitSelectedDates()
        {
            this.ResetTitle();
            if (SelectedDates != null)
            {
                SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
            }
            SelectedDates = new ObservableCollection<DateTime>();
            SelectedDates.CollectionChanged += SelectedDates_CollectionChanged;
        }
    }
}
