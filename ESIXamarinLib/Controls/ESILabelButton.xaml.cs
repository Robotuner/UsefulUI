using ESIXamarinLib.Models;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESILabelButton : ContentView
    {
        public Thickness ButtonMargin
        {
            get { return GetButtonMargin(this); }
            set { SetButtonMargin(this, value); }
        }   
        #region ButtonMargin
        public static readonly BindableProperty ButtonMarginProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonMargin", returnType: typeof(Thickness), declaringType: typeof(ESILabelButton), defaultValue: new Thickness(0,0,0,0),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonMarginChanged);

        private static void OnButtonMarginChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.frame.Margin = (Thickness)newValue;
            }
        }

        public static Thickness GetButtonMargin(BindableObject target)
        {
            object result = target.GetValue(ButtonMarginProperty);
            return (Thickness)result;
        }

        public static void SetButtonMargin(BindableObject target, Thickness value)
        {
            target.SetValue(ButtonMarginProperty, value);
        }
        #endregion

        public float ButtonCornerRadius
        {
            get { return GetButtonCornerRadius(this); }
            set { SetButtonCornerRadius(this, value); }
        }
        #region ButtonCornerRadius

        public static readonly BindableProperty ButtonCornerRadiusProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonCornerRadius", returnType: typeof(float), declaringType: typeof(ESILabelButton), defaultValue: 4.0f,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonCornerRadiusChanged);

        private static void OnButtonCornerRadiusChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.frame.CornerRadius = (float)newValue;
            }
        }

        public static float GetButtonCornerRadius(BindableObject target)
        {
            object result = target.GetValue(ButtonCornerRadiusProperty);
            return (float)result;
        }

        public static void SetButtonCornerRadius(BindableObject target, double value)
        {
            target.SetValue(ButtonCornerRadiusProperty, value);
        }
        #endregion

        public double ButtonWidthRequest
        {
            get { return GetButtonWidthRequest(this); }
            set { SetButtonWidthRequest(this, value); }
        }
        #region ButtonWidthRequest
        public static readonly BindableProperty ButtonWidthRequestProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonWidthRequest", returnType: typeof(double), declaringType: typeof(ESILabelButton), defaultValue: 100.0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonWidthRequestChanged);

        private static void OnButtonWidthRequestChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.labelText.WidthRequest = (double)newValue;
            }
        }

        public static double GetButtonWidthRequest(BindableObject target)
        {
            object result = target.GetValue(ButtonWidthRequestProperty);
            return (double)result;
        }

        public static void SetButtonWidthRequest(BindableObject target, double value)
        {
            target.SetValue(ButtonWidthRequestProperty, value);
        }
        #endregion

        public string ButtonText
        {
            get { return GetButtonText(this); }
            set { SetButtonText(this, value); }
        }
        #region ButtonText
        public static readonly BindableProperty ButtonTextProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonText", returnType: typeof(string), declaringType: typeof(ESILabelButton), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonTextChanged);

        private static void OnButtonTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.labelText.Text = (string)newValue;
            }
        }

        public static string GetButtonText(BindableObject target)
        {
            object result = target.GetValue(ButtonTextProperty);
            return (string)result;
        }

        public static void SetButtonText(BindableObject target, string value)
        {
            target.SetValue(ButtonTextProperty, value);
        }
        #endregion

        public FontAttributes ButtonAttributes
        {
            get { return GetButtonAttributes(this); }
            set { SetButtonAttributes(this, value); }
        }
        #region ButtonAttributes
        public static readonly BindableProperty ButtonAttributesProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonAttributes", returnType: typeof(FontAttributes), declaringType: typeof(ESILabelButton), defaultValue: FontAttributes.None,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonAttributesChanged);

        private static void OnButtonAttributesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.labelText.FontAttributes = (FontAttributes)newValue;
                thisctrl.labelIcon.FontAttributes = (FontAttributes)newValue;
            }
        }

        public static FontAttributes GetButtonAttributes(BindableObject target)
        {
            object result = target.GetValue(ButtonAttributesProperty);
            return (FontAttributes)result;
        }

        public static void SetButtonAttributes(BindableObject target, FontAttributes value)
        {
            target.SetValue(ButtonAttributesProperty, value);
        }
        #endregion

        public Color ButtonBackground
        {
            get { return GetButtonBackground(this); }
            set { SetButtonBackground(this, value); }
        }
        #region ButtonBackground
        public static readonly BindableProperty ButtonBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonBackground", returnType: typeof(Color), declaringType: typeof(ESILabelButton), defaultValue: Color.White,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonBackgroundChanged);

        private static void OnButtonBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.framebase.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetButtonBackground(BindableObject target)
        {
            object result = target.GetValue(ButtonBackgroundProperty);
            return (Color)result;
        }

        public static void SetButtonBackground(BindableObject target, Color value)
        {
            target.SetValue(ButtonBackgroundProperty, value);
        }
        #endregion

        public Thickness ButtonTextMargin
        {
            get { return GetButtonTextMargin(this); }
            set { SetButtonTextMargin(this, value); }
        }
        #region ButtonTextMargin
        public static readonly BindableProperty ButtonTextMarginProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonTextMargin", returnType: typeof(Thickness), declaringType: typeof(ESILabelButton), defaultValue: new Thickness(4,0),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonTextMarginChanged);

        private static void OnButtonTextMarginChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                Thickness thismargin = (Thickness)newValue;
                thisctrl.labelText.Margin = thismargin;
                thisctrl.labelIcon.Margin = new Thickness(0, 0, thismargin.Left, 0);
            }
        }

        public static Thickness GetButtonTextMargin(BindableObject target)
        {
            object result = target.GetValue(ButtonTextMarginProperty);
            return (Thickness)result;
        }

        public static void SetButtonTextMargin(BindableObject target, Thickness value)
        {
            target.SetValue(ButtonTextMarginProperty, value);
        }
        #endregion

        public LineBreakMode ButtonLineBreakMode
        {
            get { return GetButtonLineBreakMode(this); }
            set { SetButtonLineBreakMode(this, value); }
        }
        #region ButtonLineBreakMode
        public static readonly BindableProperty ButtonLineBreakModeProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonLineBreakMode", returnType: typeof(LineBreakMode), declaringType: typeof(ESILabelButton), defaultValue: LineBreakMode.TailTruncation,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonLineBreakModeChanged);

        private static void OnButtonLineBreakModeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.labelText.LineBreakMode = (LineBreakMode)newValue;
            }
        }

        public static LineBreakMode GetButtonLineBreakMode(BindableObject target)
        {
            object result = target.GetValue(ButtonLineBreakModeProperty);
            return (LineBreakMode)result;
        }

        public static void SetButtonLineBreakMode(BindableObject target, LineBreakMode value)
        {
            target.SetValue(ButtonLineBreakModeProperty, value);
        }
        #endregion

        public string ButtonIcon
        {
            get { return GetButtonIcon(this); }
            set { SetButtonIcon(this, value); }
        }
        #region ButtonIcon
        public static readonly BindableProperty ButtonIconProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonIcon", returnType: typeof(string), declaringType: typeof(ESILabelButton), defaultValue: ESILibFontAwesome.Check,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonIconChanged);

        private static void OnButtonIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.labelIcon.Text = (string)newValue;
            }
        }

        public static string GetButtonIcon(BindableObject target)
        {
            object result = target.GetValue(ButtonIconProperty);
            return (string)result;
        }

        public static void SetButtonIcon(BindableObject target, string value)
        {
            target.SetValue(ButtonIconProperty, value);
        }
        #endregion

        public string ButtonIconFamily
        {
            get { return GetButtonIconFamily(this); }
            set { SetButtonIconFamily(this, value); }
        }
        #region ButtonIconFamily
        public static readonly BindableProperty ButtonIconFamilyProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonIconFamily", returnType: typeof(string), declaringType: typeof(ESILabelButton), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonIconFamilyChanged);

        private static void OnButtonIconFamilyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.labelIcon.FontFamily = (string)newValue;
            }
        }

        public static string GetButtonIconFamily(BindableObject target)
        {
            object result = target.GetValue(ButtonIconFamilyProperty);
            return (string)result;
        }

        public static void SetButtonIconFamily(BindableObject target, string value)
        {
            target.SetValue(ButtonIconFamilyProperty, value);
        }
        #endregion

        public Color ButtonIconColor
        {
            get { return GetButtonIconColor(this); }
            set { SetButtonIconColor(this, value); }
        }
        #region ButtonIconColor
        public static readonly BindableProperty ButtonIconColorProperty = BindableProperty.CreateAttached(
                propertyName: "ButtonIconColor", returnType: typeof(Color), declaringType: typeof(ESILabelButton), defaultValue: Color.Gray,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnButtonIconColorChanged);

        private static void OnButtonIconColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.labelIcon.TextColor = (Color)newValue;
            }
        }

        public static Color GetButtonIconColor(BindableObject target)
        {
            object result = target.GetValue(ButtonIconColorProperty);
            return (Color)result;
        }

        public static void SetButtonIconColor(BindableObject target, Color value)
        {
            target.SetValue(ButtonIconColorProperty, value);
        }
        #endregion


        public Color TextColor
        {
            get { return GetTextColor(this); }
            set { SetTextColor(this, value); }
        }
        #region TextColor
        public static readonly BindableProperty TextColorProperty = BindableProperty.CreateAttached(
                propertyName: "TextColor", returnType: typeof(Color), declaringType: typeof(ESILabelButton), defaultValue: Color.Black,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnTextColorChanged);

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.labelText.TextColor = (Color)newValue;
            }
        }

        public static Color GetTextColor(BindableObject target)
        {
            object result = target.GetValue(TextColorProperty);
            return (Color)result;
        }

        public static void SetTextColor(BindableObject target, Color value)
        {
            target.SetValue(TextColorProperty, value);
        }
        #endregion

        public ICommand Command
        {
            get { return GetCommand(this); }
            set { SetCommand(this, value); }
        }
        #region Command
        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(
                propertyName: "Command", returnType: typeof(ICommand), declaringType: typeof(ESILabelButton), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCommandChanged);

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESILabelButton thisctrl = (ESILabelButton)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.ClickCommand = (ICommand)newValue;
            }
        }

        public static ICommand GetCommand(BindableObject target)
        {
            object result = target.GetValue(CommandProperty);
            return (ICommand)result;
        }

        public static void SetCommand(BindableObject target, ICommand value)
        {
            target.SetValue(CommandProperty, value);
        }
        #endregion

        private ICommand ClickCommand { get; set; }
        public ESILabelButton()
        {
            InitializeComponent();
            this.labelText.WidthRequest = this.ButtonWidthRequest;
            this.labelText.LineBreakMode = this.ButtonLineBreakMode;
        }

        private void LabelButton_Tapped(object sender, EventArgs e)
        {
            if (this.Command != null)
            {
                this.Command.Execute(labelText.Text);
            }
        }
    }
}