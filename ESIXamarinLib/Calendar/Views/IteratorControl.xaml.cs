using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Calendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IteratorControl : ContentView
    {       
        public Models.IIteratorItem SelectedItem
        {
            get { return GetSelectedItem(this); }
            set { SetSelectedItem(this, value); }
        }
        #region SelectedItem
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedItem", returnType: typeof(Models.IIteratorItem), declaringType: typeof(IteratorControl), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.iteratorName.Text = (newValue as Models.IIteratorItem).Name;
            }
        }

        public static Models.IIteratorItem GetSelectedItem(BindableObject target)
        {
            object result = target.GetValue(SelectedItemProperty);
            return (Models.IteratorItem)result;
        }

        public static void SetSelectedItem(BindableObject target, Models.IIteratorItem value)
        {
            target.SetValue(SelectedItemProperty, value);
        }
        #endregion

        public Color SelectorBackgroundColor
        {
            get { return GetSelectorBackgroundColor(this); }
            set { SetSelectorBackgroundColor(this, value); }
        }
        #region SelectorBackgroundColor
        public static readonly BindableProperty SelectorBackgroundColorProperty = BindableProperty.CreateAttached(
                propertyName: "SelectorBackgroundColor", returnType: typeof(Color), declaringType: typeof(IteratorControl), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectorBackgroundColorChanged);

        private static void OnSelectorBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.iteratorGrid.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetSelectorBackgroundColor(BindableObject target)
        {
            object result = target.GetValue(SelectorBackgroundColorProperty);
            return (Color)result;
        }

        public static void SetSelectorBackgroundColor(BindableObject target, Color value)
        {
            target.SetValue(SelectorBackgroundColorProperty, value);
        }
        #endregion

        public Thickness PrevPadding
        {
            get { return GetPrevPadding(this); }
            set { SetPrevPadding(this, value); }
        }
        #region PrevPadding
        public static readonly BindableProperty PrevPaddingProperty = BindableProperty.CreateAttached(
                propertyName: "PrevPadding", returnType: typeof(Thickness), declaringType: typeof(IteratorControl), defaultValue: new Thickness(0,0,0,0),   
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPrevPaddingChanged);

        private static void OnPrevPaddingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            { 
                thisctrl.previous.Padding = (Thickness)newValue;
            }
        }

        public static Thickness GetPrevPadding(BindableObject target)
        {
            object result = target.GetValue(PrevPaddingProperty);
            return (Thickness)result;
        }

        public static void SetPrevPadding(BindableObject target, Thickness value)
        {
            target.SetValue(PrevPaddingProperty, value);
        }
        #endregion

        public Thickness NextPadding
        {
            get { return GetNextPadding(this); }
            set { SetNextPadding(this, value); }
        }
        #region NextPadding
        public static readonly BindableProperty NextPaddingProperty = BindableProperty.CreateAttached(
                propertyName: "NextPadding", returnType: typeof(Thickness), declaringType: typeof(IteratorControl), defaultValue: new Thickness(0,0,0,0),   
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnNextPaddingChanged);

        private static void OnNextPaddingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.next.Padding = (Thickness)newValue;
            }
        }

        public static Thickness GetNextPadding(BindableObject target)
        {
            object result = target.GetValue(NextPaddingProperty);
            return (Thickness)result;
        }

        public static void SetNextPadding(BindableObject target, Thickness value)
        {
            target.SetValue(NextPaddingProperty, value);
        }
        #endregion

        public Color NameColor
        {
            get { return GetNameColor(this); }
            set { SetNameColor(this, value); }
        }
        #region NameColor
        public static readonly BindableProperty NameColorProperty = BindableProperty.CreateAttached(
                propertyName: "NameColor", returnType: typeof(Color), declaringType: typeof(IteratorControl), defaultValue: Color.Black,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnNameColorChanged);

        private static void OnNameColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.iteratorName.TextColor = (Color)newValue;
            }
        }

        public static Color GetNameColor(BindableObject target)
        {
            object result = target.GetValue(NameColorProperty);
            return (Color)result;
        }

        public static void SetNameColor(BindableObject target, Color value)
        {
            target.SetValue(NameColorProperty, value);
        }
        #endregion

        public Color IconColor
        {
            get { return GetIconColor(this); }
            set { SetIconColor(this, value); }
        }           
        #region IconColor
        public static readonly BindableProperty IconColorProperty = BindableProperty.CreateAttached(
                propertyName: "IconColor", returnType: typeof(Color), declaringType: typeof(IteratorControl), defaultValue: Color.Black,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIconColorChanged);

        private static void OnIconColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.previous.TextColor = (Color)newValue;
                thisctrl.next.TextColor = (Color)newValue;
            }
        }

        public static Color GetIconColor(BindableObject target)
        {
            object result = target.GetValue(IconColorProperty);
            return (Color)result;
        }

        public static void SetIconColor(BindableObject target, Color value)
        {
            target.SetValue(IconColorProperty, value);
        }
        #endregion

        public string IconFontFamily
        {
            get { return GetIconFontFamily(this); }
            set { SetIconFontFamily(this, value); }
        }
        #region IconFontFamily
        public static readonly BindableProperty IconFontFamilyProperty = BindableProperty.CreateAttached(
                propertyName: "IconFontFamily", returnType: typeof(string), declaringType: typeof(IteratorControl), defaultValue: "FontAwesome5FreeSolid",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIconFontFamilyChanged);

        private static void OnIconFontFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.previous.FontFamily = newValue.ToString();
                thisctrl.next.FontFamily = newValue.ToString();
            }
        }

        public static string GetIconFontFamily(BindableObject target)
        {
            object result = target.GetValue(IconFontFamilyProperty);
            return (string)result;
        }

        public static void SetIconFontFamily(BindableObject target, string value)
        {
            target.SetValue(IconFontFamilyProperty, value);
        }
        #endregion


        public string FontSize
        {
            get { return GetFontSize(this); }
            set { SetFontSize(this, value); }
        }
        #region FontSize
        public static readonly BindableProperty FontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "FontSize", returnType: typeof(string), declaringType: typeof(IteratorControl), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnFontSizeChanged);

        private static void OnFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                FontSizeConverter fsc = new FontSizeConverter();
                double fsize = (double)fsc.ConvertFromInvariantString((string)newValue);
                thisctrl.previous.FontSize = fsize;
                thisctrl.next.FontSize = fsize;
                thisctrl.iteratorName.FontSize = fsize;
            }
        }

        public static string GetFontSize(BindableObject target)
        {
            object result = target.GetValue(FontSizeProperty);
            return (string)result;
        }

        public static void SetFontSize(BindableObject target, string value)
        {
            target.SetValue(FontSizeProperty, value);
        }
        #endregion
        public IteratorControl()
        {
            InitializeComponent();
        }

        public bool ShowControl
        {
            get { return GetShowControl(this); }
            set { SetShowControl(this, value); }
        }

        #region ShowControl
        public static readonly BindableProperty ShowControlProperty = BindableProperty.CreateAttached(
                propertyName: "ShowControl", returnType: typeof(bool), declaringType: typeof(IteratorControl), defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnShowControlChanged);

        private static void OnShowControlChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.iteratorGrid.IsVisible = (bool)newValue;
            }
        }

        public static bool GetShowControl(BindableObject target)
        {
            object result = target.GetValue(ShowControlProperty);
            return (bool)result;
        }

        public static void SetShowControl(BindableObject target, bool value)
        {
            target.SetValue(ShowControlProperty, value);
        }
        #endregion


        public string IteratorIconLeft
        {
            get { return GetIteratorIconLeft(this); }
            set { SetIteratorIconLeft(this, value); }
        }
        #region IteratorIconLeft
        public static readonly BindableProperty IteratorIconLeftProperty = BindableProperty.CreateAttached(
                propertyName: "IteratorIconLeft", returnType: typeof(string), declaringType: typeof(IteratorControl), defaultValue: "\uf053",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIteratorIconLeftChanged);

        private static void OnIteratorIconLeftChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.previous.Text = (string)newValue;
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
                propertyName: "IteratorIconRight", returnType: typeof(string), declaringType: typeof(IteratorControl), defaultValue: "\uf054",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIteratorIconRightChanged);

        private static void OnIteratorIconRightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            IteratorControl thisctrl = (IteratorControl)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.next.Text = (string)newValue;
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
        public Func<bool, Models.IIteratorItem, Models.IIteratorItem> GetNextItem { get; set; }

        public Action RefreshDisplay { get; set; }

        private void Previous_Tapped(object sender, EventArgs e)
        {
            this.SelectedItem = this.GetNextItem?.Invoke(false, this.SelectedItem);
            this.RefreshDisplay.Invoke();
        }

        private void Next_Tapped(object sender, EventArgs e)
        {
            this.SelectedItem = this.GetNextItem?.Invoke(true, this.SelectedItem);
            this.RefreshDisplay?.Invoke();
        }
    }
}