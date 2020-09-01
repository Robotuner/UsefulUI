using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESINullableDateTime : ContentView
    {
        /// <summary>
        /// This property is inportant.  
        /// When it is true, it means that the DateTime property from the ViewModel has changed.  When that happens
        /// both the DatePicker and the TimePicker must be updated to reflect the change from the ViewModel.
        /// When it is false, it means that the DateTime property was NOT changed from the ViewModel, but from the control (user interaction).
        /// When the user changes the date, the Bound property must be updated, but we don't want the update to also update the value in the 
        /// Time Picker, hence isInitializing is false.
        /// When the TimePicker control change the time (User interaction) we must update the bound DateTime Property to reflect the 
        /// DatePicker date with the new time.  Updating the Bound DateTime property with the new time, will trigger the DateTime PropertyChanged event 
        /// because it appears to be a change from ViewModel, hence isInitializing will be true and the TimePicker control will be set to the 
        /// Time portion of the control, which the time the use just selected!
        /// </summary>
        //private bool isInitializing = false;
        private DateTime? modelDateTime;

        public bool AllowFutureDate
        {
            get { return GetAllowFutureDate(this); }
            set { SetAllowFutureDate(this, value); }
        }
        #region AllowFutureDate Attached Property
        public static readonly BindableProperty AllowFutureDateProperty = BindableProperty.CreateAttached(
            propertyName: "AllowFutureDate",
            returnType: typeof(bool),
            declaringType: typeof(ESINullableDateTime),
            defaultValue: true,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnAllowFutureDateChanged);

        private static void OnAllowFutureDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESINullableDateTime thisctrl = (ESINullableDateTime)bindable;
            if (thisctrl != null)
            {
                if (newValue != null && oldValue != newValue && thisctrl.modelDateTime != null && thisctrl.dpicker != null)
                {
                    try
                    {
                        if (!(bool)newValue)
                        {
                            DateTime utcNow = DateTime.UtcNow;
                            thisctrl.dpicker.MaximumDate = utcNow;
                        }
                        else
                        {
                            thisctrl.dpicker.MaximumDate = new DateTime(2100, 12, 31);
                        }
                    }
                    catch
                    {
                        // swallow a UI crash here 
                    }
                }
            }
        }
        public static bool GetAllowFutureDate(BindableObject target)
        {
            bool result = (bool)target.GetValue(AllowFutureDateProperty);
            return result;
        }
        public static void SetAllowFutureDate(BindableObject target, bool value)
        {
            target.SetValue(AllowFutureDateProperty, value);
        }
        #endregion

        public string DateDisplay
        {
            get { return GetDateDisplay(this); }
            set { SetDateDisplay(this, value); }
        }
        #region DateLabel Attached Property
        public static readonly BindableProperty DateDisplayProperty = BindableProperty.CreateAttached(
            propertyName: "DateDisplay",
            returnType: typeof(string),
            declaringType: typeof(ESINullableDateTime),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnDateDisplayChanged);

        private static void OnDateDisplayChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESINullableDateTime thisctrl = (ESINullableDateTime)bindable;
            if (thisctrl != null)
            {
                thisctrl.dateLabel.Text = newValue.ToString();
            }
        }
        public static string GetDateDisplay(BindableObject target)
        {
            return target.GetValue(DateDisplayProperty).ToString();
        }
        public static void SetDateDisplay(BindableObject target, string value)
        {
            target.SetValue(DateDisplayProperty, value);
        }
        #endregion

        public string TimeDisplay
        {
            get { return GetTimeDisplay(this); }
            set { SetTimeDisplay(this, value); }
        }
        #region TimeLabel Attached Property
        public static readonly BindableProperty TimeDisplayProperty = BindableProperty.CreateAttached(
            propertyName: "TimeDisplay",
            returnType: typeof(string),
            declaringType: typeof(ESINullableDateTime),
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnTimeDisplayChanged);

        private static void OnTimeDisplayChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESINullableDateTime thisctrl = (ESINullableDateTime)bindable;
            if (thisctrl != null)
            {
                thisctrl.timeLabel.Text = newValue.ToString();
            }
        }
        public static string GetTimeDisplay(BindableObject target)
        {
            return target.GetValue(TimeDisplayProperty).ToString();
        }
        public static void SetTimeDisplay(BindableObject target, string value)
        {
            target.SetValue(TimeDisplayProperty, value);
        }
        #endregion

        public DateTime? ControlDate
        {
            get { return GetControlDate(this); }
            set { SetControlDate(this, value); }
        }
        #region DateTime Attached Property
        public static readonly BindableProperty ControlDateProperty = BindableProperty.CreateAttached(
                        propertyName: "ControlDate",
            returnType: typeof(DateTime?),
            declaringType: typeof(ESINullableDateTime),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: OnControlDateChanged);
        private static void OnControlDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESINullableDateTime thisctrl = (ESINullableDateTime)bindable;
            if (thisctrl != null)
            {
                thisctrl.modelDateTime = (DateTime?)newValue;
                if (thisctrl.dpicker != null)
                {
                    thisctrl.dpicker.Format = thisctrl.DateFormat;
                    if (newValue != null && oldValue != newValue && thisctrl.modelDateTime != null && thisctrl.dpicker != null)
                    {
                        try
                        {
                            thisctrl.timePicker.Time = thisctrl.modelDateTime.Value.TimeOfDay;
                            thisctrl.dpicker.Date = thisctrl.modelDateTime.Value;

                            bool allowFutureDate = GetAllowFutureDate(thisctrl);
                            if (!allowFutureDate)
                            {
                                DateTime utcNow = DateTime.UtcNow;
                                thisctrl.dpicker.MaximumDate = utcNow;
                            }
                            else
                            {
                                thisctrl.dpicker.MaximumDate = new DateTime(2100, 12, 31);
                            }
                        }
                        catch
                        {
                            // swallow a UI crash here 
                        }
                    }
                }
                thisctrl.timePickerDisplay.IsVisible = thisctrl.datePickerDisplay.IsVisible = thisctrl.modelDateTime == null ? true : false;
            }
        }
        public static DateTime? GetControlDate(BindableObject target)
        {
            object result = target.GetValue(ControlDateProperty);
            return (DateTime?)result;
        }
        public static void SetControlDate(BindableObject target, DateTime? value)
        {
            target.SetValue(ControlDateProperty, value);
        }
        #endregion


        public string DateFormat
        {
            get { return GetDateFormat(this); }
            set { SetDateFormat(this, value); }
        }
        #region DateFormat
        public static readonly BindableProperty DateFormatProperty = BindableProperty.CreateAttached(
                propertyName: "DateFormat", returnType: typeof(string), declaringType: typeof(ESINullableDateTime), defaultValue: "dd/MM/yyyy",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDateFormatChanged);

        private static void OnDateFormatChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESINullableDateTime thisctrl = (ESINullableDateTime
                )bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.dpicker.Format = (string)newValue;
            }
        }

        public static string GetDateFormat(BindableObject target)
        {
            object result = target.GetValue(DateFormatProperty);
            return (string)result;
        }

        public static void SetDateFormat(BindableObject target, string value)
        {
            target.SetValue(DateFormatProperty, value);
        }
        #endregion

        public ESINullableDateTime()
        {
            InitializeComponent();
        }

        private void OnDateChanged(object sender, DateChangedEventArgs e)
        {
            int month = e.NewDate.Month;
            int day = e.NewDate.Day;
            int year = e.NewDate.Year;
            int hour = this.GetModelHour();
            int minutes = this.GetModelMinutes();
            this.modelDateTime = new DateTime(year, month, day, hour, minutes, 0);
            this.dpicker.Format = this.DateFormat;
            SetControlDate(this, this.modelDateTime);
        }

        private int GetModelHour()
        {
            if (this.modelDateTime.HasValue)
            {
                return this.modelDateTime.Value.Hour;
            }
            return 0;
        }

        private int GetModelMinutes()
        {
            if (this.modelDateTime.HasValue)
            {
                return this.modelDateTime.Value.Minute;
            }
            return 0;
        }

        private void UpdateTimeControl(object sender)
        {
            if (sender is TimePicker ts)
            {
                DateTime? currdt = this.dpicker.Date;
                if (ts != null && currdt.HasValue && (ts.Time.Hours != currdt.Value.Hour || ts.Time.Minutes != currdt.Value.Minute))
                {
                    if (currdt.HasValue)
                    {
                        int month = currdt.Value.Month;
                        int day = currdt.Value.Day;
                        int year = currdt.Value.Year;
                        int hour = ts.Time.Hours;
                        int minutes = ts.Time.Minutes;
                        DateTime selectedDate = new DateTime(year, month, day, hour, minutes, 0);
                        if (!GetAllowFutureDate(this))
                        {
                            //DateTime utcDateTime = DateTime.UtcNow;
                            //if (utcDateTime.Date == selectedDate.Date)
                            //{
                            //    if (utcDateTime.TimeOfDay < selectedDate.TimeOfDay)
                            //    {
                            //        ts.Time = new TimeSpan(utcDateTime.Hour, utcDateTime.Minute, 0);
                            //        selectedDate = new DateTime(year, month, day, ts.Time.Hours, ts.Time.Minutes, 0);
                            //    }
                            //}
                        }
                        modelDateTime = selectedDate;
                        SetControlDate(this, modelDateTime);
                    }
                }
            }
        }

        private void TimePickerFocused(object sender, EventArgs e)
        {
            this.SetModelDateTime();
        }

        private void DatePickerFocused(object sender, EventArgs e)
        {
            this.SetModelDateTime();
        }

        private void SetModelDateTime()
        {
            if (this.modelDateTime == null)
            {
                this.ControlDate = DateTime.Now;
            }
            this.timePickerDisplay.IsVisible = this.datePickerDisplay.IsVisible = this.modelDateTime == null ? true : false;

        }
        private void TimePickerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is TimePicker && this.dpicker != null)
            {
                UpdateTimeControl(sender);
            }
        }

        private void ClearButtonPressed(object sender, EventArgs e)
        {
            this.modelDateTime = null;
            this.ControlDate = this.modelDateTime;
        }
    }
}