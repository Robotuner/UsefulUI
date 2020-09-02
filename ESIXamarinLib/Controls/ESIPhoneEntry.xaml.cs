using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESIPhoneEntry : ContentView
    {

        public string SelectedPhone
        {
            get { return GetSelectedPhone(this); }
            set { SetSelectedPhone(this, value); }
        }
        #region SelectedPhone
        public static readonly BindableProperty SelectedPhoneProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedPhone", returnType: typeof(string), declaringType: typeof(ESIPhoneEntry), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedPhoneChanged);

        private static void OnSelectedPhoneChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.phone.Text = newValue.ToString();
                thisctrl.PhoneNumberChanged(newValue.ToString());
            }
        }

        public static string GetSelectedPhone(BindableObject target)
        {
            object result = target.GetValue(SelectedPhoneProperty);
            return (string)result;
        }

        public static void SetSelectedPhone(BindableObject target, string value)
        {
            target.SetValue(SelectedPhoneProperty, value);
        }
        #endregion

        public bool CanEdit
        {
            get { return GetCanEdit(this); }
            set { SetCanEdit(this, value); }
        }
        #region CanEdit
        public static readonly BindableProperty CanEditProperty = BindableProperty.CreateAttached(
                propertyName: "CanEdit", returnType: typeof(bool), declaringType: typeof(ESIPhoneEntry), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCanEditChanged);

        private static void OnCanEditChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
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

        public Func<string,string> FormatPhoneNumber
        {
            get { return GetFormatPhoneNumber(this); }
            set { SetFormatPhoneNumber(this, value); }
        }
        #region FormatPhoneNumber
        public static readonly BindableProperty FormatPhoneNumberProperty = BindableProperty.CreateAttached(
                propertyName: "FormatPhoneNumber", returnType: typeof(Func<string,string>), declaringType: typeof(ESIPhoneEntry), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnFormatPhoneNumberChanged);

        private static void OnFormatPhoneNumberChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.FormatPhoneNumber = (Func<string,string>)newValue;
            }
        }

        public static Func<string,string> GetFormatPhoneNumber(BindableObject target)
        {
            object result = target.GetValue(FormatPhoneNumberProperty);
            return (Func<string,string>)result;
        }

        public static void SetFormatPhoneNumber(BindableObject target, Func<string,string> value)
        {
            target.SetValue(FormatPhoneNumberProperty, value);
        }
        #endregion

        public Thickness SelectedPhoneMargin
        {
            get { return GetSelectedPhoneMargin(this); }
            set { SetSelectedPhoneMargin(this, value); }
        }
        #region SelectedPhoneMargin
        public static readonly BindableProperty SelectedPhoneMarginProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedPhoneMargin", returnType: typeof(Thickness), declaringType: typeof(ESIPhoneEntry), defaultValue: new Thickness(0),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedPhoneMarginChanged);

        private static void OnSelectedPhoneMarginChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.phone.Margin = (Thickness)newValue;
                thisctrl.readOnlyPhone.Margin = (Thickness)newValue;
            }
        }

        public static Thickness GetSelectedPhoneMargin(BindableObject target)
        {
            object result = target.GetValue(SelectedPhoneMarginProperty);
            return (Thickness)result;
        }

        public static void SetSelectedPhoneMargin(BindableObject target, Thickness value)
        {
            target.SetValue(SelectedPhoneMarginProperty, value);
        }
        #endregion
        public string ReadOnlyPlaceHolder
        {
            get { return GetReadOnlyPlaceHolder(this); }
            set { SetReadOnlyPlaceHolder(this, value); }
        }
        #region ReadOnlyPlaceHolder
        public static readonly BindableProperty ReadOnlyPlaceHolderProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyPlaceHolder", returnType: typeof(string), declaringType: typeof(ESIPhoneEntry), defaultValue: "10 digit phone number",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyPlaceHolderChanged);

        private static void OnReadOnlyPlaceHolderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyPlaceHolder = (string)newValue;
            }
        }

        public static string GetReadOnlyPlaceHolder(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyPlaceHolderProperty);
            return (string)result;
        }

        public static void SetReadOnlyPlaceHolder(BindableObject target, string value)
        {
            target.SetValue(ReadOnlyPlaceHolderProperty, value);
        }
        #endregion

        public Color ReadOnlyPlaceHolderColor
        {
            get { return GetReadOnlyPlaceHolderColor(this); }
            set { SetReadOnlyPlaceHolderColor(this, value); }
        }
        #region ReadOnlyPlaceHolderColor
        public static readonly BindableProperty ReadOnlyPlaceHolderColorProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyPlaceHolderColor", returnType: typeof(Color), declaringType: typeof(ESIPhoneEntry), defaultValue: Color.Gray,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyPlaceHolderColorChanged);

        private static void OnReadOnlyPlaceHolderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.ReadOnlyPlaceHolderColor = (Color)newValue;
            }
        }

        public static Color GetReadOnlyPlaceHolderColor(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyPlaceHolderColorProperty);
            return (Color)result;
        }

        public static void SetReadOnlyPlaceHolderColor(BindableObject target, Color value)
        {
            target.SetValue(ReadOnlyPlaceHolderColorProperty, value);
        }
        #endregion

        public bool ShowRequiredFlag
        {
            get { return GetShowRequiredFlag(this); }
            set { SetShowRequiredFlag(this, value); }
        }
        #region ShowRequiredFlag
        public static readonly BindableProperty ShowRequiredFlagProperty = BindableProperty.CreateAttached(
                propertyName: "ShowRequiredFlag", returnType: typeof(bool), declaringType: typeof(ESIPhoneEntry), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnShowRequiredFlagChanged);

        private static void OnShowRequiredFlagChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.required.IsVisible = (bool)newValue;
                if ((bool)newValue)
                {
                    if (string.IsNullOrEmpty(thisctrl.phone.Text))
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
                propertyName: "RequiredMessage", returnType: typeof(string), declaringType: typeof(ESIPhoneEntry), defaultValue: "Required",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnRequiredMessageChanged);

        private static void OnRequiredMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
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

        public string PhoneTitle
        {
            get { return GetPhoneTitle(this); }
            set { SetPhoneTitle(this, value); }
        }
        #region PhoneTitle
        public static readonly BindableProperty PhoneTitleProperty = BindableProperty.CreateAttached(
                propertyName: "PhoneTitle", returnType: typeof(string), declaringType: typeof(ESIPhoneEntry), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPhoneTitleChanged);

        private static void OnPhoneTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPhoneEntry thisctrl = (ESIPhoneEntry)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.phoneTitle .Text= (string)newValue;
            }
        }

        public static string GetPhoneTitle(BindableObject target)
        {
            object result = target.GetValue(PhoneTitleProperty);
            return (string)result;
        }

        public static void SetPhoneTitle(BindableObject target, string value)
        {
            target.SetValue(PhoneTitleProperty, value);
        }
        #endregion

        public ESIPhoneEntry()
        {
            this.CanEdit = false;
            InitializeComponent();
            this.ShowRequiredFlag = false;
            this.required.Text = this.ShowRequiredFlag ? this.RequiredMessage : null;
            this.readOnlyPhone.Text = this.ReadOnlyPlaceHolder;
            this.readOnlyPhone.TextColor = this.ReadOnlyPlaceHolderColor;
            this.SetVisibility(this.CanEdit);
        }

        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                entry.TextColor = entry.Text.Length < 10 ? Color.Red : Color.Default;
                this.PhoneNumberChanged((sender as Entry).Text); 
            }           
        }

        private void PhoneNumberChanged(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                this.readOnlyPhone.Text = this.ReadOnlyPlaceHolder;
                this.readOnlyPhone.TextColor = this.ReadOnlyPlaceHolderColor;
                this.required.Text = this.RequiredMessage;
                this.required.IsVisible = true;
            }
            else
            {
                this.readOnlyPhone.TextColor = Color.Default;
                this.readOnlyPhone.Text = this.FormatPhoneNumber != null ? this.FormatPhoneNumber?.Invoke(phoneNumber) : this.DefaultFormat(phoneNumber);
                if (phoneNumber.Length >= 10)
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
            this.SelectedPhone = phoneNumber;
        }

        private string DefaultFormat(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                return null;

            int len = val.Length;         
            if (len == 10)
            {
                string areaCode = val.Substring(0, 3);
                string prefix = val.Substring(3, 3);
                string tail = val.Substring(6, 4);
                return string.Format("({0}) {1}-{2}", areaCode, prefix, tail);
            }
            if (len > 10)
            {
                int ccode = len - 10;
                string countryCode = val.Substring(0, ccode);
                string areaCode = val.Substring(ccode, 3);
                string prefix = val.Substring(ccode + 3, 3);
                string tail = val.Substring(ccode + 6, 4);
                return string.Format("{3} - ({0}) {1}-{2}", areaCode, prefix, tail, countryCode);
            }
            return val;
        }

        private void SetVisibility(bool canEdit)
        {
            this.phone.IsVisible = canEdit;
            this.readOnlyPhone.IsVisible = !canEdit;
        }
        private void Phone_Tapped(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedPhone) &&  SelectedPhone.Length >= 10)
            {
                PhoneDialer.Open(SelectedPhone);
            }
        }
    }
}