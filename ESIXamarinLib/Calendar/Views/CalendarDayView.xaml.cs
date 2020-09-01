namespace ESIXamarinLib.Calendar.Views
{
    using ESIXamarinLib.Calendar.Models;
    using System;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarDayView : ContentView
    {
        public string Name { get; set; }
        public bool HideNonMonthDates { get; set; }

        public DateTime? CalendarDate
        {
            get { return GetCalendarDate(this); }
            set { SetCalendarDate(this, value); }
        }
        #region CalendarDate
        public static readonly BindableProperty CalendarDateProperty = BindableProperty.CreateAttached(
                propertyName: "CalendarDate", returnType: typeof(DateTime), declaringType: typeof(CalendarDayView), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCalendarDateChanged);

        private static void OnCalendarDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView thisctrl = (CalendarDayView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                DateTime? result = (DateTime?)newValue;
                thisctrl.calendarDay.Text = result.HasValue ? result.Value.Day.ToString() : null;
                ResetGridDateDisplay(thisctrl, result, thisctrl.CurrentMonth);
            }
        }

        public static DateTime? GetCalendarDate(BindableObject target)
        {
            object result = target.GetValue(CalendarDateProperty);
            return (DateTime?)result;
        }

        public static void SetCalendarDate(BindableObject target, DateTime? value)
        {
            target.SetValue(CalendarDateProperty, value);
        }
        #endregion

        public Color CalendarDateColor
        {
            get { return GetCalendarDateColor(this); }
            set { SetCalendarDateColor(this, value); }
        }
        #region CalendarDateColor
        public static readonly BindableProperty CalendarDateColorProperty = BindableProperty.CreateAttached(
                propertyName: "CalendarDateColor", returnType: typeof(Color), declaringType: typeof(CalendarDayView), defaultValue: Color.Black,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCalendarDateColorChanged);

        private static void OnCalendarDateColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView thisctrl = (CalendarDayView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                    thisctrl.calendarDay.TextColor = (Color)newValue;
            }
        }

        public static Color GetCalendarDateColor(BindableObject target)
        {
            object result = target.GetValue(CalendarDateColorProperty);
            return (Color)result;
        }

        public static void SetCalendarDateColor(BindableObject target, Color value)
        {
            target.SetValue(CalendarDateColorProperty, value);
        }
        #endregion

        public LayoutOptions HorizLayout
        {
            get { return GetHorizLayout(this); }
            set { SetHorizLayout(this, value); }
        }
        #region HorizLayout
        public static readonly BindableProperty HorizLayoutProperty = BindableProperty.CreateAttached(
                propertyName: "HorizLayout", returnType: typeof(LayoutOptions), declaringType: typeof(CalendarDayView), defaultValue: LayoutOptions.Center,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnHorizLayoutChanged);

        private static void OnHorizLayoutChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView thisctrl = (CalendarDayView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.calendarDay.HorizontalOptions = (LayoutOptions)newValue;
            }
        }

        public static LayoutOptions GetHorizLayout(BindableObject target)
        {
            object result = target.GetValue(HorizLayoutProperty);
            return (LayoutOptions)result;
        }

        public static void SetHorizLayout(BindableObject target, LayoutOptions value)
        {
            target.SetValue(HorizLayoutProperty, value);
        }
        #endregion

        public LayoutOptions VertLayout
        {
            get { return GetVertLayout(this); }
            set { SetVertLayout(this, value); }
        }
        #region VertLayout
        public static readonly BindableProperty VertLayoutProperty = BindableProperty.CreateAttached(
                propertyName: "VertLayout", returnType: typeof(LayoutOptions), declaringType: typeof(CalendarDayView), defaultValue: LayoutOptions.Center,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnVertLayoutChanged);

        private static void OnVertLayoutChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView thisctrl = (CalendarDayView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.calendarDay.VerticalOptions = (LayoutOptions)newValue;
            }
        }

        public static LayoutOptions GetVertLayout(BindableObject target)
        {
            object result = target.GetValue(VertLayoutProperty);
            return (LayoutOptions)result;
        }

        public static void SetVertLayout(BindableObject target, LayoutOptions value)
        {
            target.SetValue(VertLayoutProperty, value);
        }
        #endregion

        public ObservableCollection<ICalendarEvent> Events
        {
            get { return GetEvents(this); }
            set { SetEvents(this, value); }
        }
        #region Events
        public static readonly BindableProperty EventsProperty = BindableProperty.CreateAttached(
                propertyName: "Events", returnType: typeof(ObservableCollection<ICalendarEvent>), declaringType: typeof(CalendarDayView), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnEventsChanged);

        private static void OnEventsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView thisctrl = (CalendarDayView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                ObservableCollection<ICalendarEvent> lst = (ObservableCollection<ICalendarEvent>)newValue;
                BindableLayout.SetItemsSource(thisctrl.flexLayout, lst);
            }
        }

        public static ObservableCollection<ICalendarEvent> GetEvents(BindableObject target)
        {
            object result = target.GetValue(EventsProperty);
            return (ObservableCollection<ICalendarEvent>)result;
        }

        public static void SetEvents(BindableObject target, ObservableCollection<ICalendarEvent> value)
        {
            target.SetValue(EventsProperty, value);
        }
        #endregion

        public bool IsSelected
        {
            get { return GetIsSelected(this); }
            set { SetIsSelected(this, value); }
        }
        #region IsSelected
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.CreateAttached(
                propertyName: "IsSelected", returnType: typeof(bool), declaringType: typeof(CalendarDayView), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIsSelectedChanged);

        private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView thisctrl = (CalendarDayView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.dayToday.BackgroundColor = (bool)newValue ? thisctrl.SelectedDateBackgroundColor : Color.Transparent;
            }
        }

        public static bool GetIsSelected(BindableObject target)
        {
            object result = target.GetValue(IsSelectedProperty);
            return (bool)result;
        }

        public static void SetIsSelected(BindableObject target, bool value)
        {
            target.SetValue(IsSelectedProperty, value);
        }
        #endregion

        public int CurrentMonth
        {
            get { return GetCurrentMonth(this); }
            set 
            {
                SetCurrentMonth(this, value); 
            }
        }
        #region CurrentMonth
        public static readonly BindableProperty CurrentMonthProperty = BindableProperty.CreateAttached(
                propertyName: "CurrentMonth", returnType: typeof(int), declaringType: typeof(CalendarDayView), defaultValue: 0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCurrentMonthChanged);

        private static void OnCurrentMonthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView thisctrl = (CalendarDayView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                ResetGridDateDisplay(thisctrl, thisctrl.CalendarDate, (int)newValue);
            }
        }

        public static int GetCurrentMonth(BindableObject target)
        {
            object result = target.GetValue(CurrentMonthProperty);
            return (int)result;
        }

        public static void SetCurrentMonth(BindableObject target, int value)
        {
            target.SetValue(CurrentMonthProperty, value);
        }
        #endregion

        public Thickness CalendarDayPadding
        {
            get { return GetCalendarDayPadding(this); }
            set { SetCalendarDayPadding(this, value); }
        }
        #region CalendarDayPadding
        public static readonly BindableProperty CalendarDayPaddingProperty = BindableProperty.CreateAttached(
                propertyName: "CalendarDayPadding", returnType: typeof(Thickness), declaringType: typeof(CalendarDayView), defaultValue: new Thickness(),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCalendarDayPaddingChanged);

        private static void OnCalendarDayPaddingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarDayView thisctrl = (CalendarDayView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.calendarDay.Padding = (Thickness)newValue;
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
        public Action<CalendarDayView> SelectedChanged { get; set; }
        public Action<DateTime> UpdateSelectedDate { get; set; }

        public CalendarDayView()
        {
            InitializeComponent();
            this.dayToday.BackgroundColor = IsSelected ? this.SelectedDateBackgroundColor : Color.Transparent;
        }

        private static void ResetGridDateDisplay(CalendarDayView thisctrl, DateTime? dt, int monthNdx)
        {
            if (dt.HasValue)
            {
                thisctrl.calendarDay.TextColor = thisctrl.DefaultColor;
                thisctrl.calendarDay.BackgroundColor = Color.Transparent;
                thisctrl.BackgroundColor = Color.Transparent;
                if (dt.Value.Date == DateTime.Today)
                {
                    thisctrl.calendarDay.TextColor = thisctrl.TodayColor;
                    thisctrl.calendarDay.BackgroundColor = thisctrl.TodayBackgroundColor;
                }
                else
                {
                    if (thisctrl.CalendarDate.Value.DayOfWeek == DayOfWeek.Saturday)
                    {
                        thisctrl.calendarDay.TextColor = thisctrl.SaturdayColor;
                        thisctrl.calendarDay.BackgroundColor = thisctrl.SaturdayBackgroundColor;
                    } else if (thisctrl.CalendarDate.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        thisctrl.calendarDay.TextColor = thisctrl.SundayColor;
                        thisctrl.calendarDay.BackgroundColor = thisctrl.SundayBackgroundColor;
                    }
                    else
                    {
                        thisctrl.calendarDay.TextColor = thisctrl.DefaultColor;
                        thisctrl.calendarDay.BackgroundColor = Color.Transparent;
                    }
                    
                    thisctrl.Opacity = 1.0;
                }

                if (thisctrl.CalendarDate.HasValue)
                {
                    thisctrl.calendarDay.Opacity = 1.0;
                    thisctrl.flexLayout.Opacity = 1.0;
                    if (!thisctrl.CurrrentDateIsInCurrentMonth(monthNdx + 1))
                    {
                        thisctrl.BackgroundColor = thisctrl.NotCurrentMonthBackgroundColor;
                        thisctrl.Opacity = thisctrl.NotInCurrentMonthOpacity;
                        if (dt.Value.Date != DateTime.Today)
                        {
                            thisctrl.calendarDay.TextColor = thisctrl.NotCurrentMonthTextColor;
                        }
                        if (thisctrl.HideNonMonthDates)
                        {
                            thisctrl.calendarDay.Opacity = 0.0;
                            thisctrl.flexLayout.Opacity = 0.0;
                        }
                    }
                    else
                    {
                        //switch (dt.Value.DayOfWeek)
                        //{
                            //case DayOfWeek.Sunday:
                            //    if (dt.Value.Date != DateTime.Today)
                            //    {
                            //        thisctrl.BackgroundColor = thisctrl.SundayBackgroundColor;
                            //        thisctrl.Opacity = thisctrl.SundayBackgroundOpacity;
                            //    }
                            //    else
                            //    {
                            //        //thisctrl.BackgroundColor = thisctrl.TodayBackgroundColor;
                            //        //thisctrl.Opacity = 0.5;
                            //    }
                            //    break;
                            //case DayOfWeek.Saturday:
                            //    if (dt.Value.Date != DateTime.Today)
                            //    {
                            //        thisctrl.BackgroundColor = thisctrl.SaturdayBackgroundColor;
                            //        thisctrl.Opacity = thisctrl.SaturdayBackgroundOpacity;
                            //    }
                            //    else
                            //    {
                            //        //thisctrl.BackgroundColor = thisctrl.TodayBackgroundColor;
                            //        //thisctrl.Opacity = 0.5;
                            //    }
                            //    break;
                            //default:
                                thisctrl.BackgroundColor = Color.Transparent;
                                thisctrl.Opacity = 1.0;
                                //break;
                        //}
                    }
                }
                else
                {
                    thisctrl.BackgroundColor = thisctrl.NotCurrentMonthBackgroundColor;
                }
            }
            else
            {
                thisctrl.calendarDay.TextColor = thisctrl.DefaultColor;
            }
        }

        private void dayGrid_Tapped(object sender, EventArgs e)
        {
            if (this.HideNonMonthDates && this.CalendarDate.HasValue)
            {
                if (!CurrrentDateIsInCurrentMonth(this.CurrentMonth))
                {
                    return;
                }
            }
            if (!CurrrentDateIsInCurrentMonth(this.CurrentMonth))
            {
                this.UpdateSelectedDate?.Invoke(this.CalendarDate.Value);
            }
            else
            {
                this.IsSelected = !this.IsSelected;
                this.SelectedChanged?.Invoke(this);
            }
        }

        private bool CurrrentDateIsInCurrentMonth(int currentMonth)
        {
            if (this.CalendarDate.HasValue)
            {
                return (this.CalendarDate.Value.Month == (this.CurrentMonth + 1)) ? true : false;
            }
            return false;
        }
    }
}