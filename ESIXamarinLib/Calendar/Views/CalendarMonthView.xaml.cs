namespace ESIXamarinLib.Calendar.Views
{
    using ESIXamarinLib.Calendar.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarMonthView : ContentView
    {
        private bool hasInitialized = false;
        private string CellNameTemplate = "monthPos{0}";
        
        // Number of rows in grid, includes first row for month/year selector
        // includes second row for day of week
        private int GridRows = 8;

        // just the number of rows that display CalendarDayViews
        private int MonthDateRows = 6;

        private Dictionary<System.DayOfWeek, string> DayOfWeekLookup = CalendarUtil.GetDayOfWeekDictionary();

        private List<System.DayOfWeek> WeekHeader { get; set; }

        private List<DateTime> MonthGridDates { get; set; }

        /// <summary>
        /// Callback to get the events at each date
        /// </summary>
        public Func<DateTime?,ObservableCollection<ICalendarEvent>> HasEventsOnDate { get; set; }

        /// <summary>
        /// Callback to update the current selected calendar date
        /// </summary>
        public Action RefreshTitle { get; set; }

        /// <summary>
        /// Date to initialize the calendar.  Defaults to current day
        /// </summary>
        public DateTime StartingDate
        {
            get { return GetStartingDate(this); }
            set { SetStartingDate(this, value); }
        }
        #region StartingDate
        public static readonly BindableProperty StartingDateProperty = BindableProperty.CreateAttached(
                propertyName: "StartingDate", returnType: typeof(DateTime), declaringType: typeof(CalendarMonthView), defaultValue: DateTime.Today,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnStartingDateChanged);

        private static void OnStartingDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                DateTime dt = (DateTime)newValue;
                thisctrl.weekIterator.SelectedItem = thisctrl.GetDateForStartOfWeek(dt);
            }
        }

        public static DateTime GetStartingDate(BindableObject target)
        {
            object result = target.GetValue(StartingDateProperty);
            return (DateTime)result;
        }

        public static void SetStartingDate(BindableObject target, DateTime value)
        {
            target.SetValue(StartingDateProperty, value);
        }
        #endregion

        /// <summary>
        /// bool to toggle between week view and month view
        /// </summary>
        public bool IsWeekFormat
        {
            get { return GetIsWeekFormat(this); }
            set { SetIsWeekFormat(this, value); }
        }
        #region IsWeekFormat
        public static readonly BindableProperty IsWeekFormatProperty = BindableProperty.CreateAttached(
                propertyName: "IsWeekFormat", returnType: typeof(bool), declaringType: typeof(CalendarMonthView), defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIsWeekFormatChanged);

        private static void OnIsWeekFormatChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SwitchBetweenMonthAndWeekView((bool)newValue);
            }
        }

        public static bool GetIsWeekFormat(BindableObject target)
        {
            object result = target.GetValue(IsWeekFormatProperty);
            return (bool)result;
        }

        public static void SetIsWeekFormat(BindableObject target, bool value)
        {
            target.SetValue(IsWeekFormatProperty, value);
        }
        #endregion

        /// <summary>
        /// Selected Date.  This is the date that is clicked in either the week or month view
        /// </summary>
        public ObservableCollection<DateTime> SelectedDates
        {
            get { return GetSelectedDates(this); }
            set { SetSelectedDates(this, value); }
        }
        #region SelectedDates
        public static readonly BindableProperty SelectedDatesProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedDates", returnType: typeof(ObservableCollection<DateTime>), declaringType: typeof(CalendarMonthView), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedDatesChanged);

        private static void OnSelectedDatesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (oldValue != null)
                {
                    thisctrl.SelectedDates.CollectionChanged -= thisctrl.SelectedDates_CollectionChanged;                    
                }
                else
                {
                    thisctrl.SelectedDates = (ObservableCollection<DateTime>)newValue;
                    thisctrl.SelectedDates.CollectionChanged += thisctrl.SelectedDates_CollectionChanged;
                }

            }
        }

        public static ObservableCollection<DateTime> GetSelectedDates(BindableObject target)
        {
            object result = target.GetValue(SelectedDatesProperty);
            return (ObservableCollection<DateTime>)result;
        }

        public static void SetSelectedDates(BindableObject target, ObservableCollection<DateTime> value)
        {
            target.SetValue(SelectedDatesProperty, value);
        }
        #endregion

        /// <summary>
        /// Gets the selected month from the month control
        /// </summary>
        public IIteratorItem SelectedMonthIterator
        {
            get { return GetSelectedMonthIterator(this); }
            set { SetSelectedMonthIterator(this, value); }
        }
        #region SelectedMonthIterator
        public static readonly BindableProperty SelectedMonthIteratorProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedMonthIterator", returnType: typeof(IIteratorItem), declaringType: typeof(CalendarMonthView), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedMonthIteratorChanged);

        private static void OnSelectedMonthIteratorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthIterator.SelectedItem = (IteratorItem)newValue;
                thisctrl.monthIterator.FontSize = thisctrl.MonthSelectorFontSize;                
            }
        }

        public static IIteratorItem GetSelectedMonthIterator(BindableObject target)
        {
            object result = target.GetValue(SelectedMonthIteratorProperty);
            return (IIteratorItem)result;
        }

        public static void SetSelectedMonthIterator(BindableObject target, IIteratorItem value)
        {
            target.SetValue(SelectedMonthIteratorProperty, value);
        }
        #endregion

        /// <summary>
        /// Gets the selected year from the year control
        /// </summary>
        public IIteratorItem SelectedYearIterator
        {
            get { return GetSelectedYearIterator(this); }
            set { SetSelectedYearIterator(this, value); }
        }
        #region SelectedYearIterator
        public static readonly BindableProperty SelectedYearIteratorProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedYearIterator", returnType: typeof(IIteratorItem), declaringType: typeof(CalendarMonthView), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedYearIteratorChanged);

        private static void OnSelectedYearIteratorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.yearIterator.SelectedItem = newValue as IIteratorItem;
                thisctrl.yearIterator.FontSize = thisctrl.MonthSelectorFontSize;
            }
        }

        public static IIteratorItem GetSelectedYearIterator(BindableObject target)
        {
            object result = target.GetValue(SelectedYearIteratorProperty);
            return (IIteratorItem)result;
        }

        public static void SetSelectedYearIterator(BindableObject target, IIteratorItem value)
        {
            target.SetValue(SelectedYearIteratorProperty, value);
        }
        #endregion

        /// <summary>
        /// bool that will enable multi-select.  Only works for month view
        /// </summary>
        public bool MultiSelect
        {
            get { return GetMultiSelect(this); }
            set { SetMultiSelect(this, value); }
        }
        #region MultiSelect
        public static readonly BindableProperty MultiSelectProperty = BindableProperty.CreateAttached(
                propertyName: "MultiSelect", returnType: typeof(bool), declaringType: typeof(CalendarMonthView), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnMultiSelectChanged);

        private static void OnMultiSelectChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.MultiSelect.Text = newValue != null ? (bool)newValue : bool.Empty;
            }
        }

        public static bool GetMultiSelect(BindableObject target)
        {
            object result = target.GetValue(MultiSelectProperty);
            return (bool)result;
        }

        public static void SetMultiSelect(BindableObject target, bool value)
        {
            target.SetValue(MultiSelectProperty, value);
        }
        #endregion

        /// <summary>
        /// Indicates the starting day of the week for the week and month view.
        /// The default is Monday
        /// </summary>
        public DayOfWeek StartOfWeek
        {
            get { return GetStartOfWeek(this); }
            set { SetStartOfWeek(this, value); }
        }
        #region StartOfWeek
        public static readonly BindableProperty StartOfWeekProperty = BindableProperty.CreateAttached(
                propertyName: "StartOfWeek", returnType: typeof(DayOfWeek), declaringType: typeof(CalendarMonthView), defaultValue: DayOfWeek.Monday,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnStartOfWeekChanged);

        private static void OnStartOfWeekChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.WeekHeader = CalendarUtil.InitWeekHeader((DayOfWeek)newValue);
            }
        }

        public static DayOfWeek GetStartOfWeek(BindableObject target)
        {
            object result = target.GetValue(StartOfWeekProperty);
            return (DayOfWeek)result;
        }

        public static void SetStartOfWeek(BindableObject target, DayOfWeek value)
        {
            target.SetValue(StartOfWeekProperty, value);
        }
        #endregion

        /// <summary>
        /// bool that will collapse/hide the control when a new date is selected.
        /// </summary>
        public bool CloseOnSelect
        {
            get { return GetCloseOnSelect(this); }
            set { SetCloseOnSelect(this, value); }
        }
        #region CloseOnSelect
        public static readonly BindableProperty CloseOnSelectProperty = BindableProperty.CreateAttached(
                propertyName: "CloseOnSelect", returnType: typeof(bool), declaringType: typeof(CalendarMonthView), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCloseOnSelectChanged);

        private static void OnCloseOnSelectChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
            }
        }

        public static bool GetCloseOnSelect(BindableObject target)
        {
            object result = target.GetValue(CloseOnSelectProperty);
            return (bool)result;
        }

        public static void SetCloseOnSelect(BindableObject target, bool value)
        {
            target.SetValue(CloseOnSelectProperty, value);
        }
        #endregion

        /// <summary>
        /// Hides non-month dates - makes them not visible.
        /// </summary>
        public bool HideNonMonthDates
        {
            get { return GetHideNonMonthDates(this); }
            set { SetHideNonMonthDates(this, value); }
        }
        #region HideNonMonthDates
        public static readonly BindableProperty HideNonMonthDatesProperty = BindableProperty.CreateAttached(
                propertyName: "HideNonMonthDates", returnType: typeof(bool), declaringType: typeof(CalendarMonthView), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnHideNonMonthDatesChanged);

        private static void OnHideNonMonthDatesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.HideNonMonthDates = (bool)newValue;
            }
        }

        public static bool GetHideNonMonthDates(BindableObject target)
        {
            object result = target.GetValue(HideNonMonthDatesProperty);
            return (bool)result;
        }

        public static void SetHideNonMonthDates(BindableObject target, bool value)
        {
            target.SetValue(HideNonMonthDatesProperty, value);
        }
        #endregion

        public bool SwipeEnabled
        {
            get { return GetswipeEnabled(this); }
            set { SetswipeEnabled(this, value); }
        }
        #region swipeEnabled
        public static readonly BindableProperty swipeEnabledProperty = BindableProperty.CreateAttached(
                propertyName: "swipeEnabled", returnType: typeof(bool), declaringType: typeof(CalendarMonthView), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnswipeEnabledChanged);

        private static void OnswipeEnabledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.swipeEnabled = (bool)newValue;
            }
        }

        public static bool GetswipeEnabled(BindableObject target)
        {
            object result = target.GetValue(swipeEnabledProperty);
            return (bool)result;
        }

        public static void SetswipeEnabled(BindableObject target, bool value)
        {
            target.SetValue(swipeEnabledProperty, value);
        }
        #endregion


        public Thickness CalendarDayPadding
        {
            get { return GetCalendarDayPadding(this); }
            set { SetCalendarDayPadding(this, value); }
        }
        #region CalendarDayPadding
        public static readonly BindableProperty CalendarDayPaddingProperty = BindableProperty.CreateAttached(
                propertyName: "CalendarDayPadding", returnType: typeof(Thickness), declaringType: typeof(CalendarMonthView), defaultValue: new Thickness(),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCalendarDayPaddingChanged);

        private static void OnCalendarDayPaddingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.CalendarDayPadding = (Thickness)newValue;
            }
        }

        public static Thickness GetCalendarDayPadding(BindableObject target)
        {
            object result = target.GetValue(CalendarDayPaddingProperty);
            return (Thickness)result;
        }

        public static void SetCalendarDayPadding(BindableObject target, Thickness value)
        {
            target.SetValue(CalendarDayPaddingProperty, value);
        }
        #endregion


        public bool WeekViewOnSelect
        {
            get { return GetWeekViewOnSelect(this); }
            set { SetWeekViewOnSelect(this, value); }
        }
        #region WeekViewOnSelect
        public static readonly BindableProperty WeekViewOnSelectProperty = BindableProperty.CreateAttached(
                propertyName: "WeekViewOnSelect", returnType: typeof(bool), declaringType: typeof(CalendarMonthView), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekViewOnSelectChanged);

        private static void OnWeekViewOnSelectChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.WeekViewOnSelect = (bool)newValue;
            }
        }

        public static bool GetWeekViewOnSelect(BindableObject target)
        {
            object result = target.GetValue(WeekViewOnSelectProperty);
            return (bool)result;
        }

        public static void SetWeekViewOnSelect(BindableObject target, bool value)
        {
            target.SetValue(WeekViewOnSelectProperty, value);
        }
        #endregion

        public CalendarMonthView()
        {
            this.WeekHeader = CalendarUtil.InitWeekHeader(this.StartOfWeek);
            InitializeComponent();            
            this.monthIterator.PropertyChanged += MonthIterator_PropertyChanged;
            this.yearIterator.PropertyChanged += YearIterator_PropertyChanged;            
        }

        /// <summary>
        /// This initialized to Calendar by providing callbacks to retrieve events and refresh the page title.
        /// </summary>
        /// <param name="hasEventsOnDate">Func<DateTime?, ObservableCollection<ICalendarEvent>></param>
        /// <param name="refreshTitle">Action</param>
        /// <param name="startDate">Used to determine what month and year to display</param>
        public void InitCalendarMonthDisplay(Func<DateTime?, ObservableCollection<ICalendarEvent>> hasEventsOnDate, Action refreshTitle, DateTime? startDate = null)
        {
            this.monthIterator.FontSize = this.MonthSelectorFontSize;
            this.yearIterator.FontSize = this.YearSelectorFontSize;
            this.weekIterator.FontSize = this.WeekSelectorFontSize;
            this.HasEventsOnDate = hasEventsOnDate;
            this.RefreshTitle = refreshTitle;
            if (this.SelectedDates == null || this.SelectedDates.Count == 0)
            {
                this.NextStartOfWeek = this.GetDateForStartOfWeek(startDate.HasValue ? startDate.Value : DateTime.Today);
            }
            this.InitCalendarGrid();
            this.InitializeMonth();
        }

        /// <summary>
        /// Re-Initialzes the control to a new Calendar date.
        /// </summary>
        /// <param name="startDate"></param>
        public void SetCalendarDate(DateTime startDate)
        {
            if (this.SelectedDates == null || this.SelectedDates.Count == 0)
            {
                this.NextStartOfWeek = this.GetDateForStartOfWeek(startDate);
            }
            Dictionary<int, string> MonthsDictionary = CalendarUtil.GetMonthsDictionary();
            this.SelectedMonth = (IteratorItem)new IteratorItem() { Id = startDate.Month - 1, Name = MonthsDictionary[startDate.Month - 1] };
            this.SelectedYear = (IteratorItem)new IteratorItem() { Id = startDate.Year, Name = startDate.Year.ToString() };
            if (this.IsWeekFormat)
            {
                this.RefreshWeek();
            }
            else
            {
                this.RefreshMonth();
            }
        }
        
        /// <summary>
        /// Updates the SelectedDates.  Used to control calendar based an event.
        /// </summary>
        /// <param name="selectedDate">DateTime</param>
        public void UpdateSelectedDate(DateTime selectedDate)
        {
            if (MultiSelect) return;
            if (this.SelectedDates != null && this.SelectedDates.Count > 0)
            {
                this.SelectedDates.RemoveAt(0);
            }
            this.SelectedDates.Add(selectedDate);
            if (this.WeekViewOnSelect)
            {
                this.IsWeekFormat = this.WeekViewOnSelect;
            }
        }

        /// <summary>
        /// This allows the host page to change the selected dates and have those dates appear as selected on the calendar
        /// </summary>
        private void SelectedDates_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (this.MultiSelect)
                return;

            CalendarDayView cdv = null;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    DateTime item = (DateTime)e.NewItems[0];
                    cdv = this.GetByDate((DateTime)e.NewItems[0]);
                    if (cdv != null)
                    {
                        // this has to be a monthview!
                        if (!DateIsInCurrentMonth(cdv.CalendarDate.Value))
                        {
                            this.SetCalendarDate(item);  
                            cdv = this.GetByDate(item);
                        }                      
                    }
                    else
                    {
                        this.ClearAllMonthDateAndGridRows();
                        this.NextStartOfWeek = GetDateForStartOfWeek(item);
                        // gets the dates for each grid cell
                        this.InitCalendarGrid();
                        //// inserts it into the grid
                        InitialzeOnlyMonthPartOfGrid();

                        cdv = this.GetByDate(item);
                    }
                    cdv.IsSelected = true;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    var item1 = e.OldItems[0];
                    cdv = this.GetByDate((DateTime)e.OldItems[0]);
                    if (cdv != null) cdv.IsSelected = false;
                    break;
            }
        }

        /// <summary>
        /// Allows navigation of both week and month view by swiping.  For month view, horizontal swipe navigates month,
        /// Vertical swipes navigate years
        /// </summary>
        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            if (!this.SwipeEnabled)
                return;

            if (this.IsWeekFormat)
            {
                DayOfWeek dow = DayOfWeek.Wednesday;
                if (this.SelectedDates != null && this.SelectedDates.Count > 0)
                {
                    dow = this.SelectedDates[0].DayOfWeek;
                }
                else
                {
                    if (this.SelectedDates == null)
                    {
                        this.SelectedDates = new ObservableCollection<DateTime>();
                    }
                }
                DateTime dayAtDate = this.MonthGridDates[0].Date;
                IteratorItem dateAtStartOfWeek = GetDateForStartOfWeek(dayAtDate);
                switch (e.Direction)
                {
                    case SwipeDirection.Left:
                        this.weekIterator.SelectedItem = GetNextWeekItem(true, dateAtStartOfWeek);
                        this.RefreshMonth();
                        break;
                    case SwipeDirection.Right:
                        this.weekIterator.SelectedItem = GetNextWeekItem(false, dateAtStartOfWeek);
                        break;
                    case SwipeDirection.Up:                        
                        break;
                    case SwipeDirection.Down: 
                        break;
                }
                this.RefreshWeek();
                // now clear SelectedDates;
                this.SelectedDates.Clear();
                IIteratorItem itm = this.NextStartOfWeek;
                int cnt = dow - this.StartOfWeek;
                if (cnt < 0) cnt = 7 - cnt;
                DateTime nextSelectedDate = this.MonthGridDates[0].Date.AddDays(cnt);
                CalendarDayView theSelectedDate = this.GetByPosition(cnt);
                this.SelectedDates.Add(nextSelectedDate);
                theSelectedDate.IsSelected = true;
            }
            else
            {
                switch (e.Direction)
                {
                    case SwipeDirection.Left:
                        this.monthIterator.SelectedItem = GetNextMonthItem(false, this.monthIterator.SelectedItem);
                        break;
                    case SwipeDirection.Right:
                        this.monthIterator.SelectedItem = GetNextMonthItem(true, this.monthIterator.SelectedItem);
                        break;
                    case SwipeDirection.Up:
                        this.yearIterator.SelectedItem = GetNextYearItem(true, this.yearIterator.SelectedItem);
                        break;
                    case SwipeDirection.Down:
                        this.yearIterator.SelectedItem = GetNextYearItem(false, this.yearIterator.SelectedItem);
                    break;
                }
                this.RefreshMonth();
            }

        }

        /// <summary>
        /// Removes the Grid rows and their CalendarDayViews from the control.
        /// </summary>
        private void ClearAllMonthDateAndGridRows()
        {
            int prevMonthDateRows = 0;
            if (this.IsWeekFormat)
            {
                // means switching from month to week view
                this.GridRows = 3;
                this.MonthDateRows = 1;  
                prevMonthDateRows = 6;
                // we need to delete 6 rows;
                if (this.monthGrid.RowDefinitions.Count == 8)
                {
                    this.RemoveChildrenFromPreviousGrid(prevMonthDateRows);
                    this.RemovePreviousMonthDateRows(prevMonthDateRows);
                }
                else if (this.monthGrid.RowDefinitions.Count == 3)
                {
                    this.RemoveChildrenFromPreviousGrid(this.MonthDateRows);
                    this.RemovePreviousMonthDateRows(this.MonthDateRows);
                }
                
            }
            else
            {
                // means switching from week to month view
                this.GridRows = 8;
                this.MonthDateRows = 6;    
                prevMonthDateRows = 1;
                // we need to delete 1 rows;
                if (this.monthGrid.RowDefinitions.Count == 3)
                {
                    this.RemoveChildrenFromPreviousGrid(prevMonthDateRows);
                    this.RemovePreviousMonthDateRows(prevMonthDateRows);
                }
                else if (this.monthGrid.RowDefinitions.Count == 8)
                {
                    this.RemoveChildrenFromPreviousGrid(this.MonthDateRows);
                    this.RemovePreviousMonthDateRows(this.MonthDateRows);
                }
            }            
            // the number of rows in the grid
            int rows = this.monthGrid.RowDefinitions.Count;
            if (rows == 2)
            {
                // this will add 6 rows
                for(int n = 0; n < this.MonthDateRows; n++)
                {                   
                    this.monthGrid.RowDefinitions.Add(new RowDefinition() { Height = this.GridDim });
                }
            }
        }

        /// <summary>
        /// Removed the monthGrid rows from the bottom
        /// </summary>
        private void RemovePreviousMonthDateRows(int prevMonthDateRows)
        {
            for (int row = 0; row < prevMonthDateRows; row++)
            {
                // remove rows from the bottom;
                var lastRow = this.monthGrid.RowDefinitions.Last();
                this.monthGrid.RowDefinitions.Remove(lastRow);
                lastRow = null;
            }
        }

        /// <summary>
        /// Removes the CalendarDayViews that are matched to grid cells from the bottom of month grid.
        /// </summary>
        private void RemoveChildrenFromPreviousGrid(int prevMonthDateRows)
        {
            // first remove all the children from previous grid
            int dayNdx = (7 * prevMonthDateRows) - 1;
            CalendarDayView calendarDayView = null;
            // first remove children in the rows
            int rowcnt = 0;
            for (int row = prevMonthDateRows; row > 0; row--)
            {
                int colcnt = 0;
                for (int col = 7; col > 0; col--)
                {
                    calendarDayView = this.GetByPosition(dayNdx--);
                    if (calendarDayView != null)
                    {
                        if (this.monthGrid.Children.Remove(calendarDayView as View))
                        {
                            calendarDayView = null;
                        }
                    }
                    colcnt++;
                }
                rowcnt++;
            }
        }

        /// <summary>
        /// This is the year selector
        /// </summary>
        private void YearIterator_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
            {     
                this.SelectedYearIterator = this.yearIterator.SelectedItem;
            }
        }

        /// <summary>
        /// This is the month selector
        /// </summary>
        private void MonthIterator_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
            {
                this.SelectedMonthIterator = this.monthIterator.SelectedItem;
            }
        }

        /// <summary>
        /// This is the month that is currently selected by the month selector
        /// </summary>
        private IIteratorItem SelectedMonth
        {
            get { return this.monthIterator.SelectedItem; }
            set { this.monthIterator.SelectedItem = value; }
        }

        /// <summary>
        /// This is the year that is currently selected by the year selector
        /// </summary>
        private IIteratorItem SelectedYear
        {
            get { return this.yearIterator.SelectedItem; }
            set { this.yearIterator.SelectedItem = value; }
        }

        /// <summary>
        /// Creates the Grid containing month/year iterators
        /// Day of week header
        /// Month grid cells
        /// </summary>
        private void InitializeMonth()
        {
            this.monthIterator.GetNextItem = this.GetNextMonthItem;
            this.yearIterator.GetNextItem = this.GetNextYearItem;
            this.weekIterator.GetNextItem = this.GetNextWeekItem;
            this.monthIterator.RefreshDisplay = this.RefreshMonth;
            this.yearIterator.RefreshDisplay = this.RefreshMonth;
            this.weekIterator.RefreshDisplay = this.RefreshWeek;
             
            int dayPos = 0;
            for(int row = 1; row < this.GridRows; row++)
            {
                if (row == 1)
                {
                    for (int col = 0; col < 7; col++)
                    {
                        this.InitializeHeader(row, col);
                    }
                }
                else
                {
                    for (int col = 0; col < 7; col++)
                    {
                        this.InitializeDay(SelectedMonth.Id, row, col, dayPos++);
                    }
                }
            }
            this.hasInitialized = true;
        }

        /// <summary>
        /// This adds the CalendarDayViews to the month part of the month grid
        /// </summary>
        private void InitialzeOnlyMonthPartOfGrid()
        {
            int dayPos = 0;
            for (int row = 2; row < this.GridRows; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    this.InitializeDay(SelectedMonth.Id, row, col, dayPos++);
                }
            }
        }

        /// <summary>
        /// Refreshes the week with new dates based on the monthGrid (which should be the right size)
        /// </summary>
        private void RefreshWeek()
        {
            //if (!MultiSelect)
            //{
            //    this.SelectedDates?.Clear();
            //}
            this.RefreshTitle?.Invoke();
            this.InitCalendarGrid();
            this.RefreshMonth();
        }

        /// <summary>
        /// Refreshes the month with new dates based on monthGrid
        /// </summary>
        private void RefreshMonth()
        {
            this.RefreshTitle?.Invoke();
            this.InitCalendarGrid();
            int dayPos = 0;
            if (this.monthGrid != null && this.monthGrid.Children != null)
            {
                for (int row = 2; row < GridRows; row++)
                {
                    for (int col = 0; col < 7; col++)
                    {
                        CalendarDayView day = this.GetByPosition(dayPos);
                        if (day != null)
                        {
                            day.CurrentMonth = this.SelectedMonth.Id;
                            if (DateTime.Today == this.MonthGridDates[dayPos])
                            {

                            }
                            day.CalendarDate = this.MonthGridDates[dayPos]; 
                            day.IsSelected = false;
                        }
                        dayPos++;
                    }
                }
            }
        }

        /// <summary>
        /// Finds the CalendarDayView based on the date
        /// </summary>
        private CalendarDayView GetByDate(DateTime dt)
        {
            if (this.monthGrid != null && this.monthGrid.Children != null)
            {
                foreach(View view in this.monthGrid.Children)
                {
                    if (view is CalendarDayView cdv && cdv.CalendarDate == dt)
                    {
                        return cdv;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the CalendarDayView based on position from starting date of monthGrid.
        /// </summary>
        private CalendarDayView GetByPosition(int dayPos)
        {
            string matchName = string.Format(this.CellNameTemplate, dayPos);
            foreach (View child in this.monthGrid.Children)
            {
                if (child is CalendarDayView day)
                {
                    if (day.Name == matchName)
                    {
                        return day;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Populated day of week header
        /// </summary>
        private void InitializeHeader(int row, int col)
        {
            DayGridHeader dgh = new DayGridHeader();
            dgh.DayOfWeekFontSize = this.DayOfWeekFontSize;
            dgh.DayOfWeekFontAttribute = this.DayOfWeekFontAttribute;
            dgh.DayOfWeek = this.GetDayOfWeek(col);
            System.DayOfWeek dow = this.WeekHeader[col];
            if (dow == DayOfWeek.Saturday)
            {
                dgh.WeekHeaderTextColor = this.SaturdayColor;
            }
            else if (dow == DayOfWeek.Sunday)
            {
                dgh.WeekHeaderTextColor = this.SundayColor;
            }
            else
            {
                dgh.WeekHeaderTextColor = this.WeekHeaderTextColor; 
            }
           
            dgh.BackgroundColor = this.WeekViewHeaderBackground;
            this.monthGrid.Children.Add(dgh, col, row);
        }

        /// <summary>
        /// Attaches the date to a grid cell location
        /// Month is the current month that is being displayed
        /// </summary>
        private void InitializeDay(int currentMonth, int row, int col, int dayPos)
        {
            CalendarDayView day = new CalendarDayView();
            day.CurrentMonth = currentMonth;
            day.CalendarDayFontSize = this.CalendarDayFontSize;
            day.SundayColor = this.SundayColor;
            day.SundayBackgroundColor = this.SundayBackgroundColor;
            day.SaturdayColor = this.SaturdayColor;
            day.SaturdayBackgroundColor = this.SaturdayBackgroundColor;
            day.SaturdayBackgroundOpacity = this.SaturdayBackgroundOpacity;
            day.NotCurrentMonthTextColor = this.NotCurrentMonthTextColor;
            day.NotCurrentMonthBackgroundColor = this.NotCurrentMonthBackgroundColor;
            day.SundayBackgroundOpacity = this.SundayBackgroundOpacity;

            day.DefaultColor = this.DefaultColor;
            day.TodayColor = this.TodayColor;
            day.TodayBackgroundColor = this.TodayBackgroundColor;
            day.SelectedDateBackgroundColor = this.SelectedDateBackgroundColor;
            day.GridDim = this.GridDim;
            day.Name = string.Format(this.CellNameTemplate, dayPos);

            day.HideNonMonthDates = this.HideNonMonthDates;  
            day.Events = this.HasEventsOnDate == null ? null : this.HasEventsOnDate?.Invoke(day.CalendarDate);
            day.SelectedChanged = this.SelectionChanged;
            day.UpdateSelectedDate = this.UpdateSelectedDate;
            day.CalendarDayPadding = this.CalendarDayPadding;
            // set this last!!!
            day.CalendarDate = this.MonthGridDates[dayPos];
            this.monthGrid.Children.Add(day, col, row);   
        }

        /// <summary>
        /// This deals with user clicking on a Day
        /// </summary>
        /// <param name="selectedDayView"></param>
        private void SelectionChanged(CalendarDayView selectedDayView)
        {
            if (this.MultiSelect)
            {
                this.MultiSelection(selectedDayView);
            }
            else
            {
                this.SingleSelect(selectedDayView);
                if (this.WeekViewOnSelect)
                {
                    if (!this.IsWeekFormat)
                    {
                        this.IsWeekFormat = true;
                    }
                }
            }
        }

        private void MultiSelection(CalendarDayView selectedDayView)
        {
            // in multiselect we just need to find the day in the grid
            if (selectedDayView.IsSelected)
            {
                if (!this.SelectedDates.Any(n => n == selectedDayView.CalendarDate.Value))
                {
                    // add it to the list;
                    this.SelectedDates.Add(selectedDayView.CalendarDate.Value);
                }
            }
            else
            {
                var found = this.SelectedDates.SingleOrDefault(n => n == selectedDayView.CalendarDate.Value);
                if (found != null)
                {
                    this.SelectedDates.Remove(found);
                }
            }
        }

        private void SingleSelect(CalendarDayView selectedDayView)
        {
            if (this.SelectedDates != null)
            {
                this.SelectedDates.Clear();                
            }
            if (selectedDayView.IsSelected)
            {
                // single selection
                if (selectedDayView != null)
                    this.SelectedDates.Add(selectedDayView.CalendarDate.Value);
                // set all the other grid view to IsSelected = false;
                foreach (var child in this.monthGrid.Children.Where(n => n != selectedDayView))
                {
                    if (child is CalendarDayView cdv)
                    {
                        cdv.IsSelected = false;
                    }
                }
            }
            else
            {
                // we need to just find the day in the grid and unselect it.
                foreach (var child in this.monthGrid.Children.Where(n => n == selectedDayView))
                {
                    // get rid of the circle indicator
                    if (child is CalendarDayView cdv)
                    {
                        cdv.IsSelected = false;
                    }                    
                }
            }
        }

        private IIteratorItem NextStartOfWeek = null;

        private IIteratorItem GetNextWeekItem(bool getNext, IIteratorItem previousItem)
        {
            // first get the date of the week
            DateTime newStart = getNext ? MonthGridDates[0].AddDays(7) : MonthGridDates[0].AddDays(-7);
            NextStartOfWeek = this.GetDateForStartOfWeek(newStart);
            return NextStartOfWeek;
        }
        
        private DateTime GetNextWeekItem(DateTime previousItem)
        {
            NextStartOfWeek = this.GetDateForStartOfWeek(previousItem);
            return NextStartOfWeek.NextStartingDT.Value;
        }

        private IteratorItem GetDateForStartOfWeek(DateTime dt)
        {
            DateTime newDt = this.DateOfStartOfWeek(dt);
            int year = newDt.Year;
            this.SelectedYear = new IteratorItem() { Id = year, Name = year.ToString() };
            this.SelectedMonth = CalendarUtil.MonthList[newDt.Month - 1];
            string month = CalendarUtil.MonthList[newDt.Month - 1].Name;
            string name = string.Format("Week of {0} {1} {2}", month, newDt.Day, year);
            return new IteratorItem() { Id = dt.Month - 1, Name = name, NextStartingDT = newDt };
        }

        /// <summary>
        /// Given a date figure out the date of the start of week.
        /// </summary>
        private DateTime DateOfStartOfWeek(DateTime dt)
        {
            DayOfWeek dow = dt.DayOfWeek;
            int diff = this.StartOfWeek - dow;
            if (diff > 0)
            {
                diff -= 7;
            }
            return dt.AddDays(diff);
        }

        private IIteratorItem GetNextMonthItem(bool getNext, IIteratorItem previousItem)
        {
            if (getNext)
            {
                if (previousItem == null || previousItem.Id == 11)
                {       
                    int year = this.SelectedYear.Id + 1;
                    this.SelectedYear = new IteratorItem() { Id = year, Name = year.ToString() };                    
                    this.SelectedMonth = CalendarUtil.MonthList[0];
                    return CalendarUtil.MonthList[0];
                }
                return CalendarUtil.MonthList[previousItem.Id + 1];
            }
            else
            {
                if (previousItem == null || previousItem.Id == 0)
                {
                    int year = this.SelectedYear.Id - 1;
                    this.SelectedYear = new IteratorItem() { Id = year, Name = year.ToString() };
                    this.SelectedMonth = CalendarUtil.MonthList[11];
                    return CalendarUtil.MonthList[11];
                }
                return CalendarUtil.MonthList[previousItem.Id - 1];
            }
        }

        private IIteratorItem GetNextYearItem(bool getNext,IIteratorItem previousItem)
        {
            if (previousItem == null)
            {
                int currentYear = DateTime.Today.Year;
                this.SelectedYear = new IteratorItem() { Id = currentYear, Name = currentYear.ToString() };
                return this.SelectedYear;
            }

            if (getNext)
            {
                int nextYear = previousItem.Id + 1;
                this.SelectedYear = new IteratorItem() { Id = nextYear, Name = nextYear.ToString() };
            }
            else
            {
                int prevYear = previousItem.Id - 1;
                this.SelectedYear = new IteratorItem() { Id = prevYear, Name = prevYear.ToString() };
            }
            return this.SelectedYear;
        }

        /// <summary>
        /// Populates the monthGrid with the dates for each Grid cell
        /// </summary>
        private void InitCalendarGrid()
        {
            DateTime? gridDate;
            if (!this.IsWeekFormat)
            {
                if (this.SelectedMonth == null || this.SelectedYear == null)
                    return;

                // first day of the month;
                gridDate = new DateTime(this.SelectedYear.Id, this.SelectedMonth.Id + 1, 1);
                System.DayOfWeek dayOfWeek = gridDate.Value.DayOfWeek;
                if (dayOfWeek != this.StartOfWeek)
                {
                    // get the day at the end of the previous month
                    int diff = this.StartOfWeek - dayOfWeek;
                    // first grid date for the month before.
                    gridDate = diff < 0 ? gridDate.Value.AddDays(diff) : gridDate.Value.AddDays(diff - 7);
                }
            }
            else
            {
                if (this.NextStartOfWeek == null)
                {
                    if (DateTime.Today.DayOfWeek != this.StartOfWeek)
                    {
                        int diff = this.StartOfWeek - DateTime.Today.DayOfWeek;
                        gridDate = diff < 0 ? DateTime.Today.AddDays(diff) : DateTime.Today.AddDays(diff - 7);
                        this.NextStartOfWeek = this.GetDateForStartOfWeek(gridDate.Value);
                    }
                }
                gridDate = this.NextStartOfWeek.NextStartingDT.Value;
            }

            //this.MonthGridDates = new List<DateTime>();
            // the grid size is 7 columns by 6 rows
            bool addDate = this.MonthGridDates == null;
            if (addDate)
            {
                this.MonthGridDates = new List<DateTime>();
            }
            int max = this.MonthGridDates == null ? 42 : this.MonthGridDates.Count;
            int pos = 0;
            int maxrows = MonthDateRows;
            int maxcols = 7;
            int totaldates = maxrows * maxcols;
            for (int n = 0; n < totaldates; n++)
            {
                if (addDate)
                {
                    this.MonthGridDates.Add(gridDate.Value.AddDays(n));
                }
                else
                {
                    if (pos < max)
                    {
                    
                        this.MonthGridDates[pos++] = gridDate.Value.AddDays(n);
                    }
                }

            }        
        }

        private string GetDayOfWeek(int col)
        {
            if (col < 7)
            {
                System.DayOfWeek dow = this.WeekHeader[col];
                var ans = this.DayOfWeekLookup[dow];
                return ans;
            }
            return "Error";
        }

        private bool DateIsInCurrentMonth(DateTime dte)
        {
             return (dte.Month == (this.SelectedMonthIterator.Id + 1)) ? true : false;
        }

        private bool DateIsInCurrentWeek(DateTime dte)
        {
            DateTime beginDte = this.MonthGridDates[0];
            DateTime endDte = this.MonthGridDates[6];
            return dte >= beginDte && dte <= endDte;
        }

        /// <summary>
        /// Used to determine what week to move to when switching from month mode.
        /// </summary>
        /// <returns></returns>
        private DateTime? GetTargetDate()
        {
            if (this.SelectedDates == null || this.SelectedDates.Count == 0)
            {
                return new DateTime(this.SelectedYear.Id, this.SelectedMonth.Id + 1, 1, 0, 0, 0);
            }

            if (this.MultiSelect) return this.SelectedDates.Last();

            return this.SelectedDates.First();
        }

        /// <summary>
        /// After the monthGrid has changed, restore the selected dates.
        /// </summary>
        private void RestoreSelectedDates()
        {
            foreach(View child in this.monthGrid?.Children)
            {
                if (child is CalendarDayView cdv)
                {
                    if (this.SelectedDates.Any(n => n == cdv.CalendarDate))
                    {
                        cdv.IsSelected = true;
                    }
                }
            }
        }

        private void SwitchBetweenMonthAndWeekView(bool isWeekView)
        {
            // we need to decide what week to display.
            // if single select use the first date, if multiple select use the last date. 
            this.ClearAllMonthDateAndGridRows();
            this.monthIterator.ShowControl = !isWeekView;
            this.yearIterator.ShowControl = !isWeekView;
            if (!isWeekView)
            {
                this.monthIterator.BackgroundColor = Color.Transparent;
                this.yearIterator.BackgroundColor = Color.Transparent;
                this.weekIterator.Opacity = 0.0;
                this.weekIterator.InputTransparent = true;
            }
            else
            {
                this.weekIterator.Opacity = 1.0;
                this.weekIterator.InputTransparent = false;
            }
            this.weekIterator.ShowControl = isWeekView;
            this.weekIterator.IsEnabled = isWeekView;
            if (this.hasInitialized)
            {
                DateTime? targetDate = this.GetTargetDate();
                if (targetDate.HasValue)
                {
                    this.NextStartOfWeek = this.GetDateForStartOfWeek(targetDate.Value);
                    this.weekIterator.SelectedItem = this.NextStartOfWeek;
                }
                // gets the dates for each grid celles 
                this.InitCalendarGrid();
                // inserts it into the grid
                this.InitialzeOnlyMonthPartOfGrid();
            }
            // we need to restore the selected dates.
            this.RestoreSelectedDates();
        }
    }
}