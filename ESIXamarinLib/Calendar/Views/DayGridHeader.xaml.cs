namespace ESIXamarinLib.Calendar.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayGridHeader : ContentView
    {
        public string DayOfWeek
        {
            get { return GetDayOfWeek(this); }
            set { SetDayOfWeek(this, value); }
        }
        #region DayOfWeek
        public static readonly BindableProperty DayOfWeekProperty = BindableProperty.CreateAttached(
                propertyName: "DayOfWeek", returnType: typeof(string), declaringType: typeof(DayGridHeader), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDayOfWeekChanged);

        private static void OnDayOfWeekChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayGridHeader thisctrl = (DayGridHeader)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                Label label = (Label)thisctrl.FindByName("header");
                if (label != null)
                {
                    label.Text = newValue.ToString();
                }
            }
        }

        public static string GetDayOfWeek(BindableObject target)
        {
            object result = target.GetValue(DayOfWeekProperty);
            return result.ToString();
        }

        public static void SetDayOfWeek(BindableObject target, string value)
        {
            target.SetValue(DayOfWeekProperty, value);
        }
        #endregion

        public Color WeekHeaderTextColor
        {
            get { return GetWeekHeaderTextColor(this); }
            set { SetWeekHeaderTextColor(this, value); }
        }
        #region WeekHeaderTextColor
        public static readonly BindableProperty WeekHeaderTextColorProperty = BindableProperty.CreateAttached(
                propertyName: "WeekHeaderTextColor", returnType: typeof(Color), declaringType: typeof(DayGridHeader), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnWeekHeaderTextColorChanged);

        private static void OnWeekHeaderTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayGridHeader thisctrl = (DayGridHeader)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.header.TextColor = (Color)newValue;
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

        public string DayOfWeekFontSize
        {
            get { return GetDayOfWeekFontSize(this); }
            set { SetDayOfWeekFontSize(this, value); }
        }
        #region DayOfWeekFontSize
        public static readonly BindableProperty DayOfWeekFontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "DayOfWeekFontSize", returnType: typeof(string), declaringType: typeof(DayGridHeader), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDayOfWeekFontSizeChanged);

        private static void OnDayOfWeekFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayGridHeader thisctrl = (DayGridHeader)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                FontSizeConverter fsc = new FontSizeConverter();
                double fsize = (double)fsc.ConvertFromInvariantString((string)newValue);
                thisctrl.header.FontSize = fsize;
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
        public static readonly BindableProperty DayOfWeekFontAtributeProperty = BindableProperty.CreateAttached(
                propertyName: "DayOfWeekFontAttribute", returnType: typeof(FontAttributes), declaringType: typeof(DayGridHeader), defaultValue: FontAttributes.None,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDayOfWeekFontAttributeChanged);

        private static void OnDayOfWeekFontAttributeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            DayGridHeader thisctrl = (DayGridHeader)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.header.FontAttributes = (FontAttributes)newValue;
            }
        }

        public static FontAttributes GetDayOfWeekFontAttribute(BindableObject target)
        {
            object result = target.GetValue(DayOfWeekFontAtributeProperty);
            return (FontAttributes)result;
        }

        public static void SetDayOfWeekFontAttribute(BindableObject target, FontAttributes value)
        {
            target.SetValue(DayOfWeekFontAtributeProperty, value);
        }
        #endregion
        public DayGridHeader()
        {
            InitializeComponent();
        }
    }
}