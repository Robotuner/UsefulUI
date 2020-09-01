using Xamarin.Forms;

namespace ESIXamarinLib.Calendar.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public partial class CalendarMonthView : ContentView
    {
        public Color SundayColor
        {
            get { return GetSundayColor(this); }
            set { SetSundayColor(this, value); }
        }
        #region SundayColor
        public static readonly BindableProperty SundayColorProperty = BindableProperty.CreateAttached(
                propertyName: "SundayColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSundayColorChanged);

        private static void OnSundayColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.SundayColor = (Color)newValue;
            }
        }

        public static Color GetSundayColor(BindableObject target)
        {
            object result = target.GetValue(SundayColorProperty);
            return (Color)result;
        }

        public static void SetSundayColor(BindableObject target, Color value)
        {
            target.SetValue(SundayColorProperty, value);
        }
        #endregion

        public Color SaturdayColor
        {
            get { return GetSaturdayColor(this); }

            set { SetSaturdayColor(this, value); }
        }
        #region SaturdayColor
        public static readonly BindableProperty SaturdayColorProperty = BindableProperty.CreateAttached(
                propertyName: "SaturdayColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSaturdayColorChanged);

        private static void OnSaturdayColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.SaturdayColor = (Color)newValue;
            }
        }

        public static Color GetSaturdayColor(BindableObject target)
        {
            object result = target.GetValue(SaturdayColorProperty);
            return (Color)result;
        }

        public static void SetSaturdayColor(BindableObject target, Color value)
        {
            target.SetValue(SaturdayColorProperty, value);
        }
        #endregion

        public Color SundayBackgroundColor
        {
            get { return GetSundayBackgroundColor(this); }
            set { SetSundayBackgroundColor(this, value); }
        }
        #region SundayBackgroundColor
        public static readonly BindableProperty SundayBackgroundColorProperty = BindableProperty.CreateAttached(
                propertyName: "SundayBackgroundColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSundayBackgroundColorChanged);

        private static void OnSundayBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.SundayBackgroundColor = (Color)newValue;
            }
        }

        public static Color GetSundayBackgroundColor(BindableObject target)
        {
            object result = target.GetValue(SundayBackgroundColorProperty);
            return (Color)result;
        }

        public static void SetSundayBackgroundColor(BindableObject target, Color value)
        {
            target.SetValue(SundayBackgroundColorProperty, value);
        }
        #endregion

        public Color SaturdayBackgroundColor
        {
            get { return GetSaturdayBackgroundColor(this); }
            set { SetSaturdayBackgroundColor(this, value); }
        }
        #region SaturdayBackgroundColor
        public static readonly BindableProperty SaturdayBackgroundColorProperty = BindableProperty.CreateAttached(
                propertyName: "SaturdayBackgroundColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSaturdayBackgroundColorChanged);

        private static void OnSaturdayBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.SaturdayBackgroundColor = (Color)newValue;
            }
        }

        public static Color GetSaturdayBackgroundColor(BindableObject target)
        {
            object result = target.GetValue(SaturdayBackgroundColorProperty);
            return (Color)result;
        }

        public static void SetSaturdayBackgroundColor(BindableObject target, Color value)
        {
            target.SetValue(SaturdayBackgroundColorProperty, value);
        }
        #endregion

        public Color WeekIteratorIconColor
        {
            get { return GetWeekIteratorIconColor(this); }
            set { SetWeekIteratorIconColor(this, value); }
        }
        #region WeekIteratorIconColor
        public static readonly BindableProperty WeekIteratorIconColorProperty = BindableProperty.CreateAttached(
                propertyName: "WeekIteratorIconColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekIteratorIconColorChanged);

        private static void OnWeekIteratorIconColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.weekIterator.IconColor = (Color)newValue;
            }
        }

        public static Color GetWeekIteratorIconColor(BindableObject target)
        {
            object result = target.GetValue(WeekIteratorIconColorProperty);
            return (Color)result;
        }

        public static void SetWeekIteratorIconColor(BindableObject target, Color value)
        {
            target.SetValue(WeekIteratorIconColorProperty, value);
        }
        #endregion

        public Color MonthIteratorIconColor
        {
            get { return GetMonthIteratorIconColor(this); }
            set { SetMonthIteratorIconColor(this, value); }
        }
        #region MonthIteratorIconColor
        public static readonly BindableProperty MonthIteratorIconColorProperty = BindableProperty.CreateAttached(
                propertyName: "MonthIteratorIconColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnMonthIteratorIconColorChanged);

        private static void OnMonthIteratorIconColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthIterator.IconColor = (Color)newValue;
            }
        }

        public static Color GetMonthIteratorIconColor(BindableObject target)
        {
            object result = target.GetValue(MonthIteratorIconColorProperty);
            return (Color)result;
        }

        public static void SetMonthIteratorIconColor(BindableObject target, Color value)
        {
            target.SetValue(MonthIteratorIconColorProperty, value);
        }
        #endregion

        public Color YearIteratorIconColor
        {
            get { return GetYearIteratorIconColor(this); }
            set { SetYearIteratorIconColor(this, value); }
        }
        #region YearIteratorIconColor
        public static readonly BindableProperty YearIteratorIconColorProperty = BindableProperty.CreateAttached(
                propertyName: "YearIteratorIconColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnYearIteratorIconColorChanged);

        private static void OnYearIteratorIconColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.yearIterator.IconColor = (Color)newValue;
            }
        }

        public static Color GetYearIteratorIconColor(BindableObject target)
        {
            object result = target.GetValue(YearIteratorIconColorProperty);
            return (Color)result;
        }

        public static void SetYearIteratorIconColor(BindableObject target, Color value)
        {
            target.SetValue(YearIteratorIconColorProperty, value);
        }
        #endregion

        public Color WeekIteratorNameColor
        {
            get { return GetWeekIteratorNameColor(this); }
            set { SetWeekIteratorNameColor(this, value); }
        }
        #region WeekIteratorNameColor
        public static readonly BindableProperty WeekIteratorNameColorProperty = BindableProperty.CreateAttached(
                propertyName: "WeekIteratorNameColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekIteratorNameColorChanged);

        private static void OnWeekIteratorNameColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.weekIterator.NameColor = (Color)newValue;
            }
        }

        public static Color GetWeekIteratorNameColor(BindableObject target)
        {
            object result = target.GetValue(WeekIteratorNameColorProperty);
            return (Color)result;
        }

        public static void SetWeekIteratorNameColor(BindableObject target, Color value)
        {
            target.SetValue(WeekIteratorNameColorProperty, value);
        }
        #endregion

        public Color MonthIteratorNameColor
        {
            get { return GetMonthIteratorNameColor(this); }
            set { SetMonthIteratorNameColor(this, value); }
        }
        #region MonthIteratorNameColor
        public static readonly BindableProperty MonthIteratorNameColorProperty = BindableProperty.CreateAttached(
                propertyName: "MonthIteratorNameColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnMonthIteratorNameColorChanged);

        private static void OnMonthIteratorNameColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthIterator.NameColor = (Color)newValue;
            }
        }

        public static Color GetMonthIteratorNameColor(BindableObject target)
        {
            object result = target.GetValue(MonthIteratorNameColorProperty);
            return (Color)result;
        }

        public static void SetMonthIteratorNameColor(BindableObject target, Color value)
        {
            target.SetValue(MonthIteratorNameColorProperty, value);
        }
        #endregion

        public Color YearIteratorNameColor
        {
            get { return GetYearIteratorNameColor(this); }
            set { SetYearIteratorNameColor(this, value); }
        }
        #region YearIteratorNameColor
        public static readonly BindableProperty YearIteratorNameColorProperty = BindableProperty.CreateAttached(
                propertyName: "YearIteratorNameColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnYearIteratorNameColorChanged);

        private static void OnYearIteratorNameColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.yearIterator.NameColor = (Color)newValue;
            }
        }

        public static Color GetYearIteratorNameColor(BindableObject target)
        {
            object result = target.GetValue(YearIteratorNameColorProperty);
            return (Color)result;
        }

        public static void SetYearIteratorNameColor(BindableObject target, Color value)
        {
            target.SetValue(YearIteratorNameColorProperty, value);
        }
        #endregion

        public Color WeekSelectorBackgroundColor
        {
            get { return GetWeekSelectorBackgroundColor(this); }
            set { SetWeekSelectorBackgroundColor(this, value); }
        }
        #region WeekSelectorBackgroundColor
        public static readonly BindableProperty WeekSelectorBackgroundColorProperty = BindableProperty.CreateAttached(
                propertyName: "WeekSelectorBackgroundColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekSelectorBackgroundColorChanged);

        private static void OnWeekSelectorBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.weekIterator.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetWeekSelectorBackgroundColor(BindableObject target)
        {
            object result = target.GetValue(WeekSelectorBackgroundColorProperty);
            return (Color)result;
        }

        public static void SetWeekSelectorBackgroundColor(BindableObject target, Color value)
        {
            target.SetValue(WeekSelectorBackgroundColorProperty, value);
        }
        #endregion

        public Color MonthYearSelectorGridBackground
        {
            get { return GetMonthYearSelectorGridBackground(this); }
            set { SetMonthYearSelectorGridBackground(this, value); }
        }
        #region MonthYearSelectorGridBackground
        public static readonly BindableProperty MonthYearSelectorGridBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "MonthYearSelectorGridBackground", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnMonthYearSelectorGridBackgroundChanged);

        private static void OnMonthYearSelectorGridBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthYear.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetMonthYearSelectorGridBackground(BindableObject target)
        {
            object result = target.GetValue(MonthYearSelectorGridBackgroundProperty);
            return (Color)result;
        }

        public static void SetMonthYearSelectorGridBackground(BindableObject target, Color value)
        {
            target.SetValue(MonthYearSelectorGridBackgroundProperty, value);
        }
        #endregion

        public Color MonthSelectorBackground
        {
            get { return GetMonthSelectorBackground(this); }
            set { SetMonthSelectorBackground(this, value); }
        }
        #region MonthSelectorBackground
        public static readonly BindableProperty MonthSelectorBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "MonthSelectorBackground", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnMonthSelectorBackgroundChanged);

        private static void OnMonthSelectorBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthIterator.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetMonthSelectorBackground(BindableObject target)
        {
            object result = target.GetValue(MonthSelectorBackgroundProperty);
            return (Color)result;
        }

        public static void SetMonthSelectorBackground(BindableObject target, Color value)
        {
            target.SetValue(MonthSelectorBackgroundProperty, value);
        }
        #endregion

        public Color YearSelectorBackground
        {
            get { return GetYearSelectorBackground(this); }
            set { SetYearSelectorBackground(this, value); }
        }
        #region YearSelectorBackground
        public static readonly BindableProperty YearSelectorBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "YearSelectorBackground", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnYearSelectorBackgroundChanged);

        private static void OnYearSelectorBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.yearIterator.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetYearSelectorBackground(BindableObject target)
        {
            object result = target.GetValue(YearSelectorBackgroundProperty);
            return (Color)result;
        }

        public static void SetYearSelectorBackground(BindableObject target, Color value)
        {
            target.SetValue(YearSelectorBackgroundProperty, value);
        }
        #endregion

        public Color NotCurrentMonthTextColor
        {
            get { return GetNotCurrentMonthTextColor(this); }
            set { SetNotCurrentMonthTextColor(this, value); }
        }
        #region NotCurrentMonthTextColor
        public static readonly BindableProperty NotCurrentMonthTextColorProperty = BindableProperty.CreateAttached(
                propertyName: "NotCurrentMonthTextColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnNotCurrentMonthTextColorChanged);

        private static void OnNotCurrentMonthTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.NotCurrentMonthTextColor = (Color)newValue;
            }
        }

        public static Color GetNotCurrentMonthTextColor(BindableObject target)
        {
            object result = target.GetValue(NotCurrentMonthTextColorProperty);
            return (Color)result;
        }

        public static void SetNotCurrentMonthTextColor(BindableObject target, Color value)
        {
            target.SetValue(NotCurrentMonthTextColorProperty, value);
        }
        #endregion

        public Color NotCurrentMonthBackgroundColor
        {
            get { return GetNotCurrentMonthBackgroundColor(this); }
            set { SetNotCurrentMonthBackgroundColor(this, value); }
        }
        #region NotCurrentMonthBackgroundColor
        public static readonly BindableProperty NotCurrentMonthBackgroundColorProperty = BindableProperty.CreateAttached(
                propertyName: "NotCurrentMonthBackgroundColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnNotCurrentMonthBackgroundColorChanged);

        private static void OnNotCurrentMonthBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.NotCurrentMonthBackgroundColor = (Color)newValue;
            }
        }

        public static Color GetNotCurrentMonthBackgroundColor(BindableObject target)
        {
            object result = target.GetValue(NotCurrentMonthBackgroundColorProperty);
            return (Color)result;
        }

        public static void SetNotCurrentMonthBackgroundColor(BindableObject target, Color value)
        {
            target.SetValue(NotCurrentMonthBackgroundColorProperty, value);
        }
        #endregion

        public Color WeekViewHeaderBackground
        {
            get { return GetWeekViewHeaderBackground(this); }
            set { SetWeekViewHeaderBackground(this, value); }
        }
        #region WeekViewHeaderBackground
        public static readonly BindableProperty WeekViewHeaderBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "WeekViewHeaderBackground", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekViewHeaderBackgroundChanged);

        private static void OnWeekViewHeaderBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.WeekViewHeaderBackground = (Color)newValue;
            }
        }

        public static Color GetWeekViewHeaderBackground(BindableObject target)
        {
            object result = target.GetValue(WeekViewHeaderBackgroundProperty);
            return (Color)result;
        }

        public static void SetWeekViewHeaderBackground(BindableObject target, Color value)
        {
            target.SetValue(WeekViewHeaderBackgroundProperty, value);
        }
        #endregion

        public Color TodayColor
        {
            get { return GetTodayColor(this); }
            set { SetTodayColor(this, value); }
        }
        #region TodayColor
        public static readonly BindableProperty TodayColorProperty = BindableProperty.CreateAttached(
                propertyName: "TodayColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnTodayColorChanged);

        private static void OnTodayColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.TodayColor = (Color)newValue;
            }
        }

        public static Color GetTodayColor(BindableObject target)
        {
            object result = target.GetValue(TodayColorProperty);
            return (Color)result;
        }

        public static void SetTodayColor(BindableObject target, Color value)
        {
            target.SetValue(TodayColorProperty, value);
        }
        #endregion

        public Color TodayBackgroundColor
        {
            get { return GetTodayBackgroundColor(this); }
            set { SetTodayBackgroundColor(this, value); }
        }
        #region TodayBackgroundColor
        public static readonly BindableProperty TodayBackgroundColorProperty = BindableProperty.CreateAttached(
                propertyName: "TodayBackgroundColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnTodayBackgroundColorChanged);

        private static void OnTodayBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.TodayBackgroundColor = (Color)newValue;
            }
        }

        public static Color GetTodayBackgroundColor(BindableObject target)
        {
            object result = target.GetValue(TodayBackgroundColorProperty);
            return (Color)result;
        }

        public static void SetTodayBackgroundColor(BindableObject target, Color value)
        {
            target.SetValue(TodayBackgroundColorProperty, value);
        }
        #endregion

        public Color SelectedDateBackgroundColor
        {
            get { return GetSelectedDateBackgroundColor(this); }
            set { SetSelectedDateBackgroundColor(this, value); }
        }
        #region SelectedDateBackgroundColor
        public static readonly BindableProperty SelectedDateBackgroundColorProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedDateBackgroundColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedDateBackgroundColorChanged);

        private static void OnSelectedDateBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.SelectedDateBackgroundColor = (Color)newValue;
            }
        }

        public static Color GetSelectedDateBackgroundColor(BindableObject target)
        {
            object result = target.GetValue(SelectedDateBackgroundColorProperty);
            return (Color)result;
        }

        public static void SetSelectedDateBackgroundColor(BindableObject target, Color value)
        {
            target.SetValue(SelectedDateBackgroundColorProperty, value);
        }
        #endregion

        public Color CalendarBackground
        {
            get { return GetCalendarBackground(this); }
            set { SetCalendarBackground(this, value); }
        }
        #region CalendarBackground
        public static readonly BindableProperty CalendarBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "CalendarBackground", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCalendarBackgroundChanged);

        private static void OnCalendarBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthGrid.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetCalendarBackground(BindableObject target)
        {
            object result = target.GetValue(CalendarBackgroundProperty);
            return (Color)result;
        }

        public static void SetCalendarBackground(BindableObject target, Color value)
        {
            target.SetValue(CalendarBackgroundProperty, value);
        }
        #endregion

        public Color DefaultColor
        {
            get { return GetDefaultColor(this); }
            set { SetDefaultColor(this, value); }
        }
        #region DefaultColor
        public static readonly BindableProperty DefaultColorProperty = BindableProperty.CreateAttached(
                propertyName: "DefaultColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDefaultColorChanged);

        private static void OnDefaultColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.DefaultColor = (Color)newValue;
            }
        }

        public static Color GetDefaultColor(BindableObject target)
        {
            object result = target.GetValue(DefaultColorProperty);
            return (Color)result;
        }

        public static void SetDefaultColor(BindableObject target, Color value)
        {
            target.SetValue(DefaultColorProperty, value);
        }
        #endregion

        public Color WeekHeaderTextColor
        {
            get { return GetWeekHeaderTextColor(this); }
            set { SetWeekHeaderTextColor(this, value); }
        }
        #region WeekHeaderTextColor
        public static readonly BindableProperty WeekHeaderTextColorProperty = BindableProperty.CreateAttached(
                propertyName: "WeekHeaderTextColor", returnType: typeof(Color), declaringType: typeof(CalendarMonthView), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekHeaderTextColorChanged);

        private static void OnWeekHeaderTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.header.TextColor = (Color)newValue;
            }
        }

        public static Color GetWeekHeaderTextColor(BindableObject target)
        {
            object result = target.GetValue(WeekHeaderTextColorProperty);
            return (Color)result;
        }

        public static void SetWeekHeaderTextColor(BindableObject target, Color value)
        {
            target.SetValue(WeekHeaderTextColorProperty, value);
        }
        #endregion

        public double SundayBackgroundOpacity
        {
            get { return GetSundayBackgroundOpacity(this); }
            set { SetSundayBackgroundOpacity(this, value); }
        }
        #region SundayBackgroundOpacity
        public static readonly BindableProperty SundayBackgroundOpacityProperty = BindableProperty.CreateAttached(
                propertyName: "SundayBackgroundOpacity", returnType: typeof(double), declaringType: typeof(CalendarMonthView), defaultValue: 1.0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSundayBackgroundOpacityChanged);

        private static void OnSundayBackgroundOpacityChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.SundayBackgroundOpacity = (double)newValue;
            }
        }

        public static double GetSundayBackgroundOpacity(BindableObject target)
        {
            object result = target.GetValue(SundayBackgroundOpacityProperty);
            return (double)result;
        }

        public static void SetSundayBackgroundOpacity(BindableObject target, double value)
        {
            target.SetValue(SundayBackgroundOpacityProperty, value);
        }
        #endregion

        public double SaturdayBackgroundOpacity
        {
            get { return GetSaturdayBackgroundOpacity(this); }
            set { SetSaturdayBackgroundOpacity(this, value); }
        }
        #region SaturdayBackgroundOpacity
        public static readonly BindableProperty SaturdayBackgroundOpacityProperty = BindableProperty.CreateAttached(
                propertyName: "SaturdayBackgroundOpacity", returnType: typeof(double), declaringType: typeof(CalendarMonthView), defaultValue: 1.0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSaturdayBackgroundOpacityChanged);

        private static void OnSaturdayBackgroundOpacityChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.SaturdayBackgroundOpacity = (double)newValue;
            }
        }

        public static double GetSaturdayBackgroundOpacity(BindableObject target)
        {
            object result = target.GetValue(SaturdayBackgroundOpacityProperty);
            return (double)result;
        }

        public static void SetSaturdayBackgroundOpacity(BindableObject target, double value)
        {
            target.SetValue(SaturdayBackgroundOpacityProperty, value);
        }
        #endregion

        public double NotInCurrentMonthOpacity
        {
            get { return GetNotInCurrentMonthOpacity(this); }
            set { SetNotInCurrentMonthOpacity(this, value); }
        }
        #region NotInCurrentMonthOpacity
        public static readonly BindableProperty NotInCurrentMonthOpacityProperty = BindableProperty.CreateAttached(
                propertyName: "NotInCurrentMonthOpacity", returnType: typeof(double), declaringType: typeof(CalendarMonthView), defaultValue: 1.0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnNotInCurrentMonthOpacityChanged);

        private static void OnNotInCurrentMonthOpacityChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.NotInCurrentMonthOpacity = (double)newValue;
            }
        }

        public static double GetNotInCurrentMonthOpacity(BindableObject target)
        {
            object result = target.GetValue(NotInCurrentMonthOpacityProperty);
            return (double)result;
        }

        public static void SetNotInCurrentMonthOpacity(BindableObject target, double value)
        {
            target.SetValue(NotInCurrentMonthOpacityProperty, value);
        }
        #endregion

        public double MonthSelectorDim
        {
            get { return GetMonthSelectorDim(this); }
            set { SetMonthSelectorDim(this, value); }
        }
        #region MonthSelectorDim
        public static readonly BindableProperty MonthSelectorDimProperty = BindableProperty.CreateAttached(
                propertyName: "MonthSelectorDim", returnType: typeof(double), declaringType: typeof(CalendarMonthView), defaultValue: 12.0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnMonthSelectorDimChanged);

        private static void OnMonthSelectorDimChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthYearRowDef.Height = (double)newValue;
            }
        }

        public static double GetMonthSelectorDim(BindableObject target)
        {
            object result = target.GetValue(MonthSelectorDimProperty);
            return (double)result;
        }

        public static void SetMonthSelectorDim(BindableObject target, double value)
        {
            target.SetValue(MonthSelectorDimProperty, value);
        }
        #endregion

        public double WeekHeaderDim
        {
            get { return GetWeekHeaderDim(this); }
            set { SetWeekHeaderDim(this, value); }
        }
        #region WeekHeaderDim
        public static readonly BindableProperty WeekHeaderDimProperty = BindableProperty.CreateAttached(
                propertyName: "WeekHeaderDim", returnType: typeof(double), declaringType: typeof(CalendarMonthView), defaultValue: 12.0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekHeaderDimChanged);

        private static void OnWeekHeaderDimChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.weekRowDef.Height = (double)newValue;
            }
        }

        public static double GetWeekHeaderDim(BindableObject target)
        {
            object result = target.GetValue(WeekHeaderDimProperty);
            return (double)result;
        }

        public static void SetWeekHeaderDim(BindableObject target, double value)
        {
            target.SetValue(WeekHeaderDimProperty, value);
        }
        #endregion

        public double GridDim
        {
            get { return GetGridDim(this); }
            set { SetGridDim(this, value); }
        }
        #region GridDim
        public static readonly BindableProperty GridDimProperty = BindableProperty.CreateAttached(
                propertyName: "GridDim", returnType: typeof(double), declaringType: typeof(CalendarMonthView), defaultValue: 40.0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnGridDimChanged);

        private static void OnGridDimChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.dayToday.HeightRequest = (double)newValue;
            }
        }

        public static double GetGridDim(BindableObject target)
        {
            object result = target.GetValue(GridDimProperty);
            return (double)result;
        }

        public static void SetGridDim(BindableObject target, double value)
        {
            target.SetValue(GridDimProperty, value);
        }
        #endregion


        public string MonthSelectorFontSize
        {
            get { return GetMonthSelectorFontSize(this); }
            set { SetMonthSelectorFontSize(this, value); }
        }
        #region MonthSelectorFontSize
        public static readonly BindableProperty MonthSelectorFontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "MonthSelectorFontSize", returnType: typeof(string), declaringType: typeof(CalendarMonthView), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnMonthSelectorFontSizeChanged);

        private static void OnMonthSelectorFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthIterator.FontSize = (string)newValue;
            }
        }

        public static string GetMonthSelectorFontSize(BindableObject target)
        {
            object result = target.GetValue(MonthSelectorFontSizeProperty);
            return (string)result;
        }

        public static void SetMonthSelectorFontSize(BindableObject target, string value)
        {
            target.SetValue(MonthSelectorFontSizeProperty, value);
        }
        #endregion

        public string YearSelectorFontSize
        {
            get { return GetYearSelectorFontSize(this); }
            set { SetYearSelectorFontSize(this, value); }
        }
        #region YearSelectorFontSize
        public static readonly BindableProperty YearSelectorFontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "YearSelectorFontSize", returnType: typeof(string), declaringType: typeof(CalendarMonthView), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnYearSelectorFontSizeChanged);

        private static void OnYearSelectorFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.yearIterator.FontSize = (string)newValue;
            }
        }

        public static string GetYearSelectorFontSize(BindableObject target)
        {
            object result = target.GetValue(YearSelectorFontSizeProperty);
            return (string)result;
        }

        public static void SetYearSelectorFontSize(BindableObject target, string value)
        {
            target.SetValue(YearSelectorFontSizeProperty, value);
        }
        #endregion

        public string WeekSelectorFontSize
        {
            get { return GetWeekSelectorFontSize(this); }
            set { SetWeekSelectorFontSize(this, value); }
        }
        #region WeekSelectorFontSize
        public static readonly BindableProperty WeekSelectorFontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "WeekSelectorFontSize", returnType: typeof(string), declaringType: typeof(CalendarMonthView), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekSelectorFontSizeChanged);

        private static void OnWeekSelectorFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.weekIterator.FontSize = (string)newValue;
            }
        }

        public static string GetWeekSelectorFontSize(BindableObject target)
        {
            object result = target.GetValue(WeekSelectorFontSizeProperty);
            return (string)result;
        }

        public static void SetWeekSelectorFontSize(BindableObject target, string value)
        {
            target.SetValue(WeekSelectorFontSizeProperty, value);
        }
        #endregion

        public string DayOfWeekFontSize
        {
            get { return GetDayOfWeekFontSize(this); }
            set { SetDayOfWeekFontSize(this, value); }
        }
        #region DayOfWeekFontSize
        public static readonly BindableProperty DayOfWeekFontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "DayOfWeekFontSize", returnType: typeof(string), declaringType: typeof(CalendarMonthView), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDayOfWeekFontSizeChanged);

        private static void OnDayOfWeekFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.DayOfWeekFontSize = (string)newValue;
            }
        }

        public static string GetDayOfWeekFontSize(BindableObject target)
        {
            object result = target.GetValue(DayOfWeekFontSizeProperty);
            return (string)result;
        }

        public static void SetDayOfWeekFontSize(BindableObject target, string value)
        {
            target.SetValue(DayOfWeekFontSizeProperty, value);
        }
        #endregion

        public FontAttributes DayOfWeekFontAttribute
        {
            get { return GetDayOfWeekFontAttribute(this); }
            set { SetDayOfWeekFontAttribute(this, value); }
        }
        #region DayOfWeekFontAttribute
        public static readonly BindableProperty DayOfWeekFontAttributeProperty = BindableProperty.CreateAttached(
                propertyName: "DayOfWeekFontAttribute", returnType: typeof(FontAttributes), declaringType: typeof(CalendarMonthView), defaultValue: FontAttributes.None,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDayOfWeekFontAttributeChanged);

        private static void OnDayOfWeekFontAttributeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.DayOfWeekFontAttribute = (string)newValue;
            }
        }

        public static FontAttributes GetDayOfWeekFontAttribute(BindableObject target)
        {
            object result = target.GetValue(DayOfWeekFontAttributeProperty);
            return (FontAttributes)result;
        }

        public static void SetDayOfWeekFontAttribute(BindableObject target, FontAttributes value)
        {
            target.SetValue(DayOfWeekFontAttributeProperty, value);
        }
        #endregion

        public string CalendarDayFontSize
        {
            get { return GetCalendarDayFontSize(this); }
            set { SetCalendarDayFontSize(this, value); }
        }
        #region CalendarDayFontSize
        public static readonly BindableProperty CalendarDayFontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "CalendarDayFontSize", returnType: typeof(string), declaringType: typeof(CalendarMonthView), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCalendarDayFontSizeChanged);

        private static void OnCalendarDayFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.CalendarDayFontSize = (string)newValue;
            }
        }

        public static string GetCalendarDayFontSize(BindableObject target)
        {
            object result = target.GetValue(CalendarDayFontSizeProperty);
            return (string)result;
        }

        public static void SetCalendarDayFontSize(BindableObject target, string value)
        {
            target.SetValue(CalendarDayFontSizeProperty, value);
        }
        #endregion


        public string IteratorIconLeft
        {
            get { return GetIteratorIconLeft(this); }
            set { SetIteratorIconLeft(this, value); }
        }
        #region IteratorIconLeft
        public static readonly BindableProperty IteratorIconLeftProperty = BindableProperty.CreateAttached(
                propertyName: "IteratorIconLeft", returnType: typeof(string), declaringType: typeof(CalendarMonthView), defaultValue: "\uf053",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIteratorIconLeftChanged);

        private static void OnIteratorIconLeftChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthIterator.IteratorIconLeft = (string)newValue;
                thisctrl.weekIterator.IteratorIconLeft = (string)newValue;
                thisctrl.yearIterator.IteratorIconLeft = (string)newValue;
            }
        }

        public static string GetIteratorIconLeft(BindableObject target)
        {
            object result = target.GetValue(IteratorIconLeftProperty);
            return (string)result;
        }

        public static void SetIteratorIconLeft(BindableObject target, string value)
        {
            target.SetValue(IteratorIconLeftProperty, value);
        }
        #endregion


        public string IteratorIconRight
        {
            get { return GetIteratorIconRight(this); }
            set { SetIteratorIconRight(this, value); }
        }
        #region IteratorIconRight
        public static readonly BindableProperty IteratorIconRightProperty = BindableProperty.CreateAttached(
                propertyName: "IteratorIconRight", returnType: typeof(string), declaringType: typeof(CalendarMonthView), defaultValue: "\uf054",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIteratorIconRightChanged);

        private static void OnIteratorIconRightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            CalendarMonthView thisctrl = (CalendarMonthView)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.monthIterator.IteratorIconRight = (string)newValue;
                thisctrl.weekIterator.IteratorIconRight = (string)newValue;
                thisctrl.yearIterator.IteratorIconRight = (string)newValue;
            }
        }

        public static string GetIteratorIconRight(BindableObject target)
        {
            object result = target.GetValue(IteratorIconRightProperty);
            return (string)result;
        }

        public static void SetIteratorIconRight(BindableObject target, string value)
        {
            target.SetValue(IteratorIconRightProperty, value);
        }
        #endregion
    }
}
