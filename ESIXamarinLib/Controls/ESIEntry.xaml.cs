using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESIEntry : ContentView
    {
        public string FieldLabel
        {
            get { return GetFieldLabel(this); }
            set { SetFieldLabel(this, value); }
        }
        #region FieldLabel
        public static readonly BindableProperty FieldLabelProperty = BindableProperty.CreateAttached(
                propertyName: "FieldLabel", returnType: typeof(string), declaringType: typeof(ESIEntry), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnFieldLabelChanged);

        private static void OnFieldLabelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.fieldLabel.Text = newValue.ToString();
                }
                else
                {
                    thisctrl.fieldLabel.Text = null;
                }
            }
        }

        public static string GetFieldLabel(BindableObject target)
        {
            if (FieldLabelProperty != null)
            {
                object result = target.GetValue(FieldLabelProperty);
                if (result != null) return (string)result;
            }
            return null;
        }

        public static void SetFieldLabel(BindableObject target, string value)
        {
            target.SetValue(FieldLabelProperty, value);
        }
        #endregion

        public string PlaceHolder
        {
            get { return GetPlaceHolder(this); }
            set { SetPlaceHolder(this, value); }
        }
        #region PlaceHolder
        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.CreateAttached(
                propertyName: "PlaceHolder", returnType: typeof(string), declaringType: typeof(ESIEntry), defaultValue: "Enter Value Here",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPlaceHolderChanged);

        private static void OnPlaceHolderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.fieldValue.Placeholder = (string)newValue;
                }
            }
        }

        public static string GetPlaceHolder(BindableObject target)
        {
            if (PlaceHolderProperty != null)
            {
                object result = target.GetValue(PlaceHolderProperty);
                if (result != null) return (string)result;
            }
            return null;
        }

        public static void SetPlaceHolder(BindableObject target, string value)
        {
            target.SetValue(PlaceHolderProperty, value);
        }
        #endregion
        public string PlaceKeyboardTypeHolder
        {
            get { return GetKeyboardType(this); }
            set { SetKeyboardType(this, value); }
        }
        #region KeyboardType
        public static readonly BindableProperty KeyboardTypeProperty = BindableProperty.CreateAttached(
                propertyName: "KeyboardType", returnType: typeof(string), declaringType: typeof(ESIEntry), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnKeyboardTypeChanged);

        private static void OnKeyboardTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    switch (newValue.ToString())
                    {
                        case "Chat":
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Chat;
                            break;
                        case "Default":
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Default;
                            break;
                        case "Email":
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Email;
                            break;
                        case "Numeric":
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Numeric;
                            break;
                        case "Plain":
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Plain;
                            break;
                        case "Telephone":
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Telephone;
                            break;
                        case "Text":
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Text;
                            break;
                        case "Url":
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Url;
                            break;
                        default:
                            thisctrl.fieldValue.Keyboard = Xamarin.Forms.Keyboard.Default;
                            break;
                    }
                }
            }
        }

        public static string GetKeyboardType(BindableObject target)
        {
            if (KeyboardTypeProperty != null)
            {
                object result = target.GetValue(KeyboardTypeProperty);
                if (result != null) return (string)result;
            }
            return null;
        }

        public static void SetKeyboardType(BindableObject target, string value)
        {
            target.SetValue(KeyboardTypeProperty, value);
        }
        #endregion
        public string FieldValue
        {
            get { return GetFieldValue(this); }
            set { SetFieldValue(this, value); }
        }
        #region FieldValue
        public static readonly BindableProperty FieldValueProperty = BindableProperty.CreateAttached(
                propertyName: "FieldValue", returnType: typeof(string), declaringType: typeof(ESIEntry), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnFieldValueChanged);

        private static void OnFieldValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.fieldValue.Text = newValue?.ToString();
                thisctrl.fieldValueDisplay.Text = newValue?.ToString();
                if (newValue == null)
                {
                    thisctrl.fieldValueDisplay.Text = thisctrl.PlaceHolder;
                    thisctrl.fieldValueDisplay.TextColor = Color.Gray;
                }
                else
                {
                    thisctrl.fieldValueDisplay.TextColor = Color.Default;
                }
            }
            thisctrl.SetIsRequired(newValue?.ToString());
        }

        public static string GetFieldValue(BindableObject target)
        {
            return target.GetValue(FieldValueProperty).ToString();
        }

        public static void SetFieldValue(BindableObject target, string value)
        {
            target.SetValue(FieldValueProperty, value);
        }
        #endregion

        public Color BkgColor
        {
            get { return GetBkgColor(this); }
            set { SetBkgColor(this, value); }
        }
        #region BkgColor
        public static readonly BindableProperty BkgColorProperty = BindableProperty.CreateAttached(
                propertyName: "BkgColor", returnType: typeof(Color), declaringType: typeof(ESIEntry), defaultValue: Color.White,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnBkgColorChanged);

        private static void OnBkgColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.fieldPanel.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetBkgColor(BindableObject target)
        {
            object result = target.GetValue(BkgColorProperty);
            return (Color)result;
        }

        public static void SetBkgColor(BindableObject target, Color value)
        {
            target.SetValue(BkgColorProperty, value);
        }
        #endregion

        public bool AsPassword
        {
            get { return GetAsPassword(this); }
            set { SetAsPassword(this, value); }
        }
        #region AsPassword
        public static readonly BindableProperty AsPasswordProperty = BindableProperty.CreateAttached(
                propertyName: "AsPassword", returnType: typeof(bool), declaringType: typeof(ESIEntry), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnAsPasswordChanged);

        private static void OnAsPasswordChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.fieldValue.IsPassword = (bool)newValue;
            }
        }

        public static bool GetAsPassword(BindableObject target)
        {
            object result = target.GetValue(AsPasswordProperty);
            return (bool)result;
        }

        public static void SetAsPassword(BindableObject target, bool value)
        {
            target.SetValue(AsPasswordProperty, value);
        }
        #endregion

        public bool ShowRequiredFlag
        {
            get { return GetShowRequiredFlag(this); }
            set { SetShowRequiredFlag(this, value); }
        }
        #region ShowRequiredFlag
        public static readonly BindableProperty ShowRequiredFlagProperty = BindableProperty.CreateAttached(
                propertyName: "ShowRequiredFlag", returnType: typeof(bool), declaringType: typeof(ESIEntry), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnShowRequiredFlagChanged);

        private static void OnShowRequiredFlagChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.required.IsVisible = (bool)newValue;
                if ((bool)newValue)
                {
                    if (string.IsNullOrEmpty(thisctrl.fieldValue.Text))
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

        public bool CanEdit
        {
            get { return GetCanEdit(this); }
            set { SetCanEdit(this, value); }
        }
        #region CanEdit
        public static readonly BindableProperty CanEditProperty = BindableProperty.CreateAttached(
                propertyName: "CanEdit", returnType: typeof(bool), declaringType: typeof(ESIEntry), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCanEditChanged);

        private static void OnCanEditChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
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

        public string RequiredMessage
        {
            get { return GetRequiredMessage(this); }
            set { SetRequiredMessage(this, value); }
        }
        #region RequiredMessage
        public static readonly BindableProperty RequiredMessageProperty = BindableProperty.CreateAttached(
                propertyName: "RequiredMessage", returnType: typeof(string), declaringType: typeof(ESIEntry), defaultValue: "Required",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnRequiredMessageChanged);

        private static void OnRequiredMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
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

        public string ReadOnlyPlaceholder
        {
            get { return GetReadOnlyPlaceholder(this); }
            set { SetReadOnlyPlaceholder(this, value); }
        }
        #region ReadOnlyPlaceholder
        public static readonly BindableProperty ReadOnlyPlaceholderProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyPlaceholder", returnType: typeof(string), declaringType: typeof(ESIEntry), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyPlaceholderChanged);

        private static void OnReadOnlyPlaceholderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyPlaceholder = (string)newValue;
            }
        }

        public static string GetReadOnlyPlaceholder(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyPlaceholderProperty);
            return (string)result;
        }

        public static void SetReadOnlyPlaceholder(BindableObject target, string value)
        {
            target.SetValue(ReadOnlyPlaceholderProperty, value);
        }
        #endregion

        public Color ReadOnlyPlaceholderColor
        {
            get { return GetReadOnlyPlaceholderColor(this); }
            set { SetReadOnlyPlaceholderColor(this, value); }
        }
        #region ReadOnlyPlaceholderColor
        public static readonly BindableProperty ReadOnlyPlaceholderColorProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyPlaceholderColor", returnType: typeof(Color), declaringType: typeof(ESIEntry), defaultValue: Color.Gray,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyPlaceholderColorChanged);

        private static void OnReadOnlyPlaceholderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyPlaceholderColor = (Color)newValue;
            }
        }

        public static Color GetReadOnlyPlaceholderColor(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyPlaceholderColorProperty);
            return (Color)result;
        }

        public static void SetReadOnlyPlaceholderColor(BindableObject target, Color value)
        {
            target.SetValue(ReadOnlyPlaceholderColorProperty, value);
        }
        #endregion

        public Color ReadOnlyTextColor
        {
            get { return GetReadOnlyTextColor(this); }
            set { SetReadOnlyTextColor(this, value); }
        }
        #region ReadOnlyTextColor
        public static readonly BindableProperty ReadOnlyTextColorProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyTextColor", returnType: typeof(Color), declaringType: typeof(ESIEntry), defaultValue: Color.Black,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyTextColorChanged);

        private static void OnReadOnlyTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyTextColor = (Color)newValue;
            }
        }

        public static Color GetReadOnlyTextColor(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyTextColorProperty);
            return (Color)result;
        }

        public static void SetReadOnlyTextColor(BindableObject target, Color value)
        {
            target.SetValue(ReadOnlyTextColorProperty, value);
        }
        #endregion

        public Thickness EntryMargin
        {
            get { return GetEntryMargin(this); }
            set { SetEntryMargin(this, value); }
        }
        #region EntryMargin
        public static readonly BindableProperty EntryMarginProperty = BindableProperty.CreateAttached(
                propertyName: "EntryMargin", returnType: typeof(Thickness), declaringType: typeof(ESIEntry), defaultValue: new Thickness(0),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnEntryMarginChanged);

        private static void OnEntryMarginChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEntry thisctrl = (ESIEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.fieldValue.Margin = (Thickness)newValue;
                thisctrl.fieldValueDisplay.Margin = (Thickness)newValue;
            }
        }

        public static Thickness GetEntryMargin(BindableObject target)
        {
            object result = target.GetValue(EntryMarginProperty);
            return (Thickness)result;
        }

        public static void SetEntryMargin(BindableObject target, Thickness value)
        {
            target.SetValue(EntryMarginProperty, value);
        }
        #endregion

        public ESIEntry()
        {
            this.CanEdit = false;
            InitializeComponent();
            this.required.IsVisible = false;
            this.fieldValue.IsReadOnly = false;
            this.SetVisibility(this.CanEdit);
            this.fieldValueDisplay.Text = this.PlaceHolder;
            this.fieldValueDisplay.TextColor = Color.Gray;
        }

        protected void OnEntryChanged(object sender, TextChangedEventArgs e)
        {
            SetFieldValue(this, e.NewTextValue?.ToString());
        }

        private void SetVisibility(bool canEdit)
        {
            this.fieldValue.IsVisible = canEdit;
            this.fieldValueDisplay.IsVisible = !canEdit;
            if (canEdit)
            {
                
            }
            else
            {
                this.fieldValueDisplay.Text =  string.IsNullOrEmpty(this.fieldValue.Text) ? this.PlaceHolder : this.fieldValue.Text;
                this.fieldValueDisplay.TextColor = string.IsNullOrEmpty(this.fieldValue.Text) ? this.ReadOnlyPlaceholderColor : this.ReadOnlyTextColor;
            }
        }

        private void SetIsRequired(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                if (this.ShowRequiredFlag)
                {
                    this.required.Text = this.RequiredMessage;
                    this.required.IsVisible = true;
                }
                else
                {
                    this.required.Text = null;
                    this.required.IsVisible = false;
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