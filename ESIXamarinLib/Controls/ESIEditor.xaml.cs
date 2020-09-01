using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESIEditor : ContentView
    {
        public string FieldLabel
        {
            get { return GetFieldLabel(this); }
            set { SetFieldLabel(this, value); }
        }
        #region FieldLabel
        public static readonly BindableProperty FieldLabelProperty = BindableProperty.CreateAttached(
                propertyName: "FieldLabel", returnType: typeof(string), declaringType: typeof(ESIEditor), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnFieldLabelChanged);

        private static void OnFieldLabelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
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
            object result = target.GetValue(FieldLabelProperty);
            return (string)result;
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
                propertyName: "PlaceHolder", returnType: typeof(string), declaringType: typeof(ESIEditor), defaultValue: "Enter Value Here",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPlaceHolderChanged);

        private static void OnPlaceHolderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
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

        public string FieldValue
        {
            get { return GetFieldValue(this); }
            set { SetFieldValue(this, value); }
        }
        #region FieldValue
        public static readonly BindableProperty FieldValueProperty = BindableProperty.CreateAttached(
                propertyName: "FieldValue", returnType: typeof(string), declaringType: typeof(ESIEditor), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnFieldValueChanged);

        private static void OnFieldValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
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
                thisctrl.SetRequiredFlag();
                thisctrl.SetVisibility(thisctrl.CanEdit);
            }
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
                propertyName: "BkgColor", returnType: typeof(Color), declaringType: typeof(ESIEditor), defaultValue: Color.White,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnBkgColorChanged);

        private static void OnBkgColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
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

        public bool ShowRequiredFlag
        {
            get { return GetShowRequiredFlag(this); }
            set { SetShowRequiredFlag(this, value); }
        }
        #region ShowRequiredFlag
        public static readonly BindableProperty ShowRequiredFlagProperty = BindableProperty.CreateAttached(
                propertyName: "ShowRequiredFlag", returnType: typeof(bool), declaringType: typeof(ESIEditor), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnShowRequiredFlagChanged);

        private static void OnShowRequiredFlagChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SetRequiredFlag();
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
                propertyName: "CanEdit", returnType: typeof(bool), declaringType: typeof(ESIEditor), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCanEditChanged);

        private static void OnCanEditChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.fieldBorder.IsVisible = !(bool)newValue;
                //thisctrl.fieldValueDisplay.IsVisible = (bool)newValue;
                thisctrl.SetVisibility((bool)newValue);
                if (!string.IsNullOrEmpty(thisctrl.fieldValueDisplay.Text))
                {
                    thisctrl.fieldValueDisplay.TextColor = thisctrl.ReadOnlyTextColor;
                }
                else
                {
                    thisctrl.fieldValueDisplay.TextColor = Color.Gray;
                }
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

        public Color EditorBackground
        {
            get { return GetEditorBackground(this); }
            set { SetEditorBackground(this, value); }
        }
        #region EditorBackground
        public static readonly BindableProperty EditorBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "EditorBackground", returnType: typeof(Color), declaringType: typeof(ESIEditor), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnEditorBackgroundChanged);

        private static void OnEditorBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.fieldBorder.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetEditorBackground(BindableObject target)
        {
            object result = target.GetValue(EditorBackgroundProperty);
            return (Color)result;
        }

        public static void SetEditorBackground(BindableObject target, Color value)
        {
            target.SetValue(EditorBackgroundProperty, value);
        }
        #endregion

        public string RequiredMessage
        {
            get { return GetRequiredMessage(this); }
            set { SetRequiredMessage(this, value); }
        }
        #region RequiredMessage
        public static readonly BindableProperty RequiredMessageProperty = BindableProperty.CreateAttached(
                propertyName: "RequiredMessage", returnType: typeof(string), declaringType: typeof(ESIEditor), defaultValue: "Required",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnRequiredMessageChanged);

        private static void OnRequiredMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
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


        public Color ReadOnlyTextColor
        {
            get { return GetReadOnlyTextColor(this); }
            set { SetReadOnlyTextColor(this, value); }
        }
        #region ReadOnlyTextColor
        public static readonly BindableProperty ReadOnlyTextColorProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyTextColor", returnType: typeof(Color), declaringType: typeof(ESIEditor), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyTextColorChanged);

        private static void OnReadOnlyTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIEditor thisctrl = (ESIEditor)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.fieldValueDisplay.TextColor = (Color)newValue;
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

        public ESIEditor()
        {
            this.CanEdit = false;
            InitializeComponent();
            this.ShowRequiredFlag = false;
            this.SetVisibility(this.CanEdit);
        }

        protected void OnEntryChanged(object sender, TextChangedEventArgs e)
        {
            SetFieldValue(this, e.NewTextValue?.ToString());
        }

        private void SetRequiredFlag()
        {
            if (this.ShowRequiredFlag)
            {
                if (this.fieldValue?.Text?.Length > 0)
                {
                    this.required.IsVisible = false;
                    this.required.Text = null;
                }
                else
                {
                    this.required.IsVisible = true;
                    this.required.Text = this.RequiredMessage;
                }
            }
        }
        private void SetVisibility(bool canEdit)
        {
            this.required.IsVisible = canEdit;
            this.fieldBorder.IsVisible = canEdit;
            this.fieldValueDisplay.IsVisible = !canEdit;
            if (!canEdit)
            {
                if (string.IsNullOrEmpty(this.fieldValue.Text))
                {
                    this.fieldValueDisplay.Text = this.PlaceHolder;
                    this.fieldValueDisplay.TextColor = Color.Gray;
                }
                else
                {
                    this.fieldValueDisplay.TextColor = Color.Default;
                }
            }
        }
    }
}