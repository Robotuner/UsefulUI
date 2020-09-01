using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESIDateAndTime : ContentView
    {
        private DateTime modelDateTime = DateTime.Now;
        public DateTime? SelectedDateTime
        {
            get { return GetSelectedDateTime(this); }
            set { SetSelectedDateTime(this, value); }
        }
        #region SelectedDateTime
        public static readonly BindableProperty SelectedDateTimeProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedDateTime", returnType: typeof(DateTime?), declaringType: typeof(ESIDateAndTime), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedDateTimeChanged);

        private static void OnSelectedDateTimeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl == null)
                return;

            if (newValue != null)
            {
                if (oldValue != newValue &&  thisctrl.dateComponent != null)
                {
                    try
                    {
                        if (thisctrl.modelDateTime != null)
                        {
                            thisctrl.timeComponent.Time = thisctrl.modelDateTime.TimeOfDay;
                            thisctrl.dateComponent.Date = thisctrl.modelDateTime.Date;
                            thisctrl.dateComponent.MaximumDate = thisctrl.AllowFutureDate ? new DateTime(2100, 12, 31) : DateTime.Now;
                            thisctrl.SelectedDateChanged();
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
            thisctrl.CanEdit = false;
            thisctrl.SelectedDateChanged();
        }

        public static DateTime? GetSelectedDateTime(BindableObject target)
        {
            object result = target.GetValue(SelectedDateTimeProperty);
            return (DateTime?)result;
        }

        public static void SetSelectedDateTime(BindableObject target, DateTime? value)
        {
            target.SetValue(SelectedDateTimeProperty, value);
        }
        #endregion

        public string DateTitle
        {
            get { return GetDateTitle(this); }
            set { SetDateTitle(this, value); }
        }
        #region DateTitle
        public static readonly BindableProperty DateTitleProperty = BindableProperty.CreateAttached(
                propertyName: "DateTitle", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDateTitleChanged);

        private static void OnDateTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.dateTitle.Text = newValue.ToString();
            }
        }

        public static string GetDateTitle(BindableObject target)
        {
            object result = target.GetValue(DateTitleProperty);
            return (string)result;
        }

        public static void SetDateTitle(BindableObject target, string value)
        {
            target.SetValue(DateTitleProperty, value);
        }
        #endregion

        public string TimeTitle
        {
            get { return GetTimeTitle(this); }
            set { SetTimeTitle(this, value); }
        }
        #region TimeTitle
        public static readonly BindableProperty TimeTitleProperty = BindableProperty.CreateAttached(
                propertyName: "TimeTitle", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnTimeTitleChanged);

        private static void OnTimeTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.timeTitle.Text = (string)newValue;
            }
        }

        public static string GetTimeTitle(BindableObject target)
        {
            object result = target.GetValue(TimeTitleProperty);
            return (string)result;
        }

        public static void SetTimeTitle(BindableObject target, string value)
        {
            target.SetValue(TimeTitleProperty, value);
        }
        #endregion

        public string ReadOnlyTitle
        {
            get { return GetReadOnlyTitle(this); }
            set { SetReadOnlyTitle(this, value); }
        }
        #region ReadOnlyTitle
        public static readonly BindableProperty ReadOnlyTitleProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyTitle", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyTitleChanged);

        private static void OnReadOnlyTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.readOnlyTitle.Text = (string)newValue;
            }
        }

        public static string GetReadOnlyTitle(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyTitleProperty);
            return (string)result;
        }

        public static void SetReadOnlyTitle(BindableObject target, string value)
        {
            target.SetValue(ReadOnlyTitleProperty, value);
        }
        #endregion

        public string ReadOnlyDateTimeDisplay
        {
            get { return GetReadOnlyDateTimeDisplay(this); }
            set { SetReadOnlyDateTimeDisplay(this, value); }
        }
        #region ReadOnlyDateTimeDisplay
        public static readonly BindableProperty ReadOnlyDateTimeDisplayProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyDateTimeDisplay", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyDateTimeDisplayChanged);

        private static void OnReadOnlyDateTimeDisplayChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyDateTimeDisplay = (string)newValue;
            }
        }

        public static string GetReadOnlyDateTimeDisplay(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyDateTimeDisplayProperty);
            return (string)result;
        }

        public static void SetReadOnlyDateTimeDisplay(BindableObject target, string value)
        {
            target.SetValue(ReadOnlyDateTimeDisplayProperty, value);
        }
        #endregion

        public string ReadOnlyDateTimeFormat
        {
            get { return GetReadOnlyDateTimeFormat(this); }
            set { SetReadOnlyDateTimeFormat(this, value); }
        }
        #region ReadOnlyDateTimeFormat
        public static readonly BindableProperty ReadOnlyDateTimeFormatProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyDateTimeFormat", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyDateTimeFormatChanged);

        private static void OnReadOnlyDateTimeFormatChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (thisctrl.SelectedDateTime.HasValue)
                {
                    thisctrl.readOnlyDateTime.Text = thisctrl.SelectedDateTime.Value.ToString((string)newValue);
                    thisctrl.readOnlyDateTime.TextColor = thisctrl.ReadOnlyDateTimeTextColor;
                }
                else
                {
                    thisctrl.readOnlyDateTime.Text = thisctrl.ReadOnlyDateTimePlaceHolder;
                    thisctrl.readOnlyDateTime.TextColor = thisctrl.ReadOnlyDateTimePlaceholderColor;
                }
            }
        }

        public static string GetReadOnlyDateTimeFormat(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyDateTimeFormatProperty);
            return (string)result;
        }

        public static void SetReadOnlyDateTimeFormat(BindableObject target, string value)
        {
            target.SetValue(ReadOnlyDateTimeFormatProperty, value);
        }
        #endregion

        public string ReadOnlyDateTimePlaceHolder
        {
            get { return GetReadOnlyDateTimePlaceHolder(this); }
            set { SetReadOnlyDateTimePlaceHolder(this, value); }
        }
        #region ReadOnlyDateTimePlaceHolder
        public static readonly BindableProperty ReadOnlyDateTimePlaceHolderProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyDateTimePlaceHolder", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: "Tap to set date and time",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyDateTimePlaceHolderChanged);

        private static void OnReadOnlyDateTimePlaceHolderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyDateTimePlaceHolder = (string)newValue;
            }
        }

        public static string GetReadOnlyDateTimePlaceHolder(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyDateTimePlaceHolderProperty);
            return (string)result;
        }

        public static void SetReadOnlyDateTimePlaceHolder(BindableObject target, string value)
        {
            target.SetValue(ReadOnlyDateTimePlaceHolderProperty, value);
        }
        #endregion

        public Color ReadOnlyDateTimePlaceholderColor
        {
            get { return GetReadOnlyDateTimePlaceholderColor(this); }
            set { SetReadOnlyDateTimePlaceholderColor(this, value); }
        }
        #region ReadOnlyDateTimePlaceholderColor
        public static readonly BindableProperty ReadOnlyDateTimePlaceholderColorProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyDateTimePlaceholderColor", returnType: typeof(Color), declaringType: typeof(ESIDateAndTime), defaultValue: Color.LightGray,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyDateTimePlaceholderColorChanged);

        private static void OnReadOnlyDateTimePlaceholderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyDateTimePlaceholderColor = (Color)newValue;
            }
        }

        public static Color GetReadOnlyDateTimePlaceholderColor(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyDateTimePlaceholderColorProperty);
            return (Color)result;
        }

        public static void SetReadOnlyDateTimePlaceholderColor(BindableObject target, Color value)
        {
            target.SetValue(ReadOnlyDateTimePlaceholderColorProperty, value);
        }
        #endregion

        public Color ReadOnlyDateTimeTextColor
        {
            get { return GetReadOnlyDateTimeTextColor(this); }
            set { SetReadOnlyDateTimeTextColor(this, value); }
        }
        #region ReadOnlyDateTimeTextColor
        public static readonly BindableProperty ReadOnlyDateTimeTextColorProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyDateTimeTextColor", returnType: typeof(Color), declaringType: typeof(ESIDateAndTime), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyDateTimeTextColorChanged);

        private static void OnReadOnlyDateTimeTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyDateTimeTextColor = (Color)newValue;
            }
        }

        public static Color GetReadOnlyDateTimeTextColor(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyDateTimeTextColorProperty);
            return (Color)result;
        }

        public static void SetReadOnlyDateTimeTextColor(BindableObject target, Color value)
        {
            target.SetValue(ReadOnlyDateTimeTextColorProperty, value);
        }
        #endregion

        public bool CanEdit
        {
            get { return GetCanEdit(this); }
            set { SetCanEdit(this, value); }
        }
        #region CanEdit
        public static readonly BindableProperty CanEditProperty = BindableProperty.CreateAttached(
                propertyName: "CanEdit", returnType: typeof(bool), declaringType: typeof(ESIDateAndTime), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCanEditChanged);

        private static void OnCanEditChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SetVisibility((bool)newValue);
            }
        }

        public static bool GetCanEdit(BindableObject target)
        {
            object result = target.GetValue(CanEditProperty);
            return (bool)result;
        }

        public static void SetCanEdit(BindableObject target, bool value)
        {
            target.SetValue(CanEditProperty, value);
        }
        #endregion

        public string DateFormat
        {
            get { return GetDateFormat(this); }
            set { SetDateFormat(this, value); }
        }
        #region DateFormat
        public static readonly BindableProperty DateFormatProperty = BindableProperty.CreateAttached(
                propertyName: "DateFormat", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDateFormatChanged);

        private static void OnDateFormatChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.DateFormat = (string)newValue;
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

        public bool AllowFutureDate
        {
            get { return GetAllowFutureDate(this); }
            set { SetAllowFutureDate(this, value); }
        }
        #region AllowFutureDate
        public static readonly BindableProperty AllowFutureDateProperty = BindableProperty.CreateAttached(
                propertyName: "AllowFutureDate", returnType: typeof(bool), declaringType: typeof(ESIDateAndTime), defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnAllowFutureDateChanged);

        private static void OnAllowFutureDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.AllowFutureDate = (bool)newValue;
            }
        }

        public static bool GetAllowFutureDate(BindableObject target)
        {
            object result = target.GetValue(AllowFutureDateProperty);
            return (bool)result;
        }

        public static void SetAllowFutureDate(BindableObject target, bool value)
        {
            target.SetValue(AllowFutureDateProperty, value);
        }
        #endregion

        public string TimeFormat
        {
            get { return GetTimeFormat(this); }
            set { SetTimeFormat(this, value); }
        }
        #region TimeFormat
        public static readonly BindableProperty TimeFormatProperty = BindableProperty.CreateAttached(
                propertyName: "TimeFormat", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: "t",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnTimeFormatChanged);

        private static void OnTimeFormatChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.timeComponent.Format = (string)newValue;
            }
        }

        public static string GetTimeFormat(BindableObject target)
        {
            object result = target.GetValue(TimeFormatProperty);
            return (string)result;
        }

        public static void SetTimeFormat(BindableObject target, string value)
        {
            target.SetValue(TimeFormatProperty, value);
        }
        #endregion

        public Thickness DateAndTimeMargin
        {
            get { return GetDateAndTimeMargin(this); }
            set { SetDateAndTimeMargin(this, value); }
        }
        #region DateAndTimeMargin
        public static readonly BindableProperty DateAndTimeMarginProperty = BindableProperty.CreateAttached(
                propertyName: "DateAndTimeMargin", returnType: typeof(Thickness), declaringType: typeof(ESIDateAndTime), defaultValue: new Thickness(0),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDateAndTimeMarginChanged);

        private static void OnDateAndTimeMarginChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.dateComponent.Margin = (Thickness)newValue;
                thisctrl.readOnlyDateTime.Margin = (Thickness)newValue;
            }
        }

        public static Thickness GetDateAndTimeMargin(BindableObject target)
        {
            object result = target.GetValue(DateAndTimeMarginProperty);
            return (Thickness)result;
        }

        public static void SetDateAndTimeMargin(BindableObject target, Thickness value)
        {
            target.SetValue(DateAndTimeMarginProperty, value);
        }
        #endregion


        public bool ShowRequiredFlag
        {
            get { return GetShowRequiredFlag(this); }
            set { SetShowRequiredFlag(this, value); }
        }
        #region ShowRequiredFlag
        public static readonly BindableProperty ShowRequiredFlagProperty = BindableProperty.CreateAttached(
                propertyName: "ShowRequiredFlag", returnType: typeof(bool), declaringType: typeof(ESIDateAndTime), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnShowRequiredFlagChanged);

        private static void OnShowRequiredFlagChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.required.IsVisible = (bool)newValue;
                if ((bool)newValue)
                {
                    if (!thisctrl.SelectedDateTime.HasValue)
                    {
                        thisctrl.required.Text = thisctrl.RequiredMessage;
                    }
                    else
                    {
                        thisctrl.required.Text = null;
                    }
                }
                else
                {
                    thisctrl.required.Text = null;
                }
            }
        }

        public static bool GetShowRequiredFlag(BindableObject target)
        {
            object result = target.GetValue(ShowRequiredFlagProperty);
            return (bool)result;
        }

        public static void SetShowRequiredFlag(BindableObject target, bool value)
        {
            target.SetValue(ShowRequiredFlagProperty, value);
        }
        #endregion

        public string RequiredMessage
        {
            get { return GetRequiredMessage(this); }
            set { SetRequiredMessage(this, value); }
        }
        #region RequiredMessage
        public static readonly BindableProperty RequiredMessageProperty = BindableProperty.CreateAttached(
                propertyName: "RequiredMessage", returnType: typeof(string), declaringType: typeof(ESIDateAndTime), defaultValue: "Required",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnRequiredMessageChanged);

        private static void OnRequiredMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIDateAndTime thisctrl = (ESIDateAndTime)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.RequiredMessage = (string)newValue;
            }
        }

        public static string GetRequiredMessage(BindableObject target)
        {
            object result = target.GetValue(RequiredMessageProperty);
            return (string)result;
        }

        public static void SetRequiredMessage(BindableObject target, string value)
        {
            target.SetValue(RequiredMessageProperty, value);
        }
        #endregion
        public ESIDateAndTime()
        {
            this.CanEdit = false;
            InitializeComponent();
            this.SetVisibility(this.CanEdit);
        }

        private void timeComponent_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is TimePicker ts && e.PropertyName == "Time")
            {
                DateTime? currdt = this.dateComponent.Date;
                if (ts!=null && currdt.HasValue && (ts.Time.Hours  != currdt.Value.Hour || ts.Time.Minutes != currdt.Value.Minute))
                {
                    int month = currdt.Value.Month;
                    int day = currdt.Value.Day;
                    int year = currdt.Value.Year;
                    int hour = ts.Time.Hours;
                    int minutes = ts.Time.Minutes;
                    DateTime selectedDate = new DateTime(year, month, day, hour, minutes, 0);
                    if (!this.AllowFutureDate)
                    {

                    }
                    this.modelDateTime = selectedDate;
                    this.SelectedDateTime = modelDateTime;
                }
            }
        }

        private void dateComponent_DateSelected(object sender, DateChangedEventArgs e)
        {
            int month = e.NewDate.Month;
            int day = e.NewDate.Day;
            int year = e.NewDate.Year;
            int hour = this.modelDateTime.Hour;
            int minutes = this.modelDateTime.Minute;
            this.SelectedDateTime = new DateTime(year, month, day, hour, minutes, 0);            
        }

        private void SetVisibility(bool canEdit)
        {
            this.dateTitle.IsVisible = canEdit;
            this.timeTitle.IsVisible = canEdit;
            this.readOnlyTitle.IsVisible = !canEdit;
            this.dateComponent.IsVisible = canEdit;
            this.timeComponent.IsVisible = canEdit;
            this.clearComponent.IsVisible = canEdit;
            this.readOnlyDateTime.IsVisible = !canEdit;
            this.SelectedDateChanged();
        }

        private void SelectedDateChanged()
        {
            if (this.SelectedDateTime.HasValue)
            {
                this.readOnlyDateTime.Text = this.SelectedDateTime.Value.ToString(this.ReadOnlyDateTimeFormat);
                this.readOnlyDateTime.TextColor = this.ReadOnlyDateTimeTextColor;
            }
            else
            {
                this.readOnlyDateTime.Text = this.ReadOnlyDateTimePlaceHolder;
                this.readOnlyDateTime.TextColor = this.ReadOnlyDateTimePlaceholderColor;
            }
            this.SetRequiredMessage();
        }

        private void Clear_Tapped(object sender, EventArgs e)
        {            
            this.SelectedDateTime = null;
        }

        private void SetRequiredMessage()
        {
            if (this.ShowRequiredFlag)
            {
                if (this.SelectedDateTime.HasValue)
                {
                    this.required.Text = null;
                    this.required.IsVisible = false;
                }
                else
                {
                    this.required.Text = this.RequiredMessage;
                    this.required.IsVisible = true;
                }
            }
            else
            {
                this.required.Text = null;
                this.required.IsVisible = false;
            }
        }
    }
}