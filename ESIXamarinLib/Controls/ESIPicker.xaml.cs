using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESIPicker : ContentView
    {
        public string PickerLabel
        {
            get { return GetPickerLabel(this); }
            set { SetPickerLabel(this, value); }
        }
        #region PickerLabel
        public static readonly BindableProperty PickerLabelProperty = BindableProperty.CreateAttached(
                propertyName: "PickerLabel", returnType: typeof(string), declaringType: typeof(ESIPicker), defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPickerLabelChanged);

        private static void OnPickerLabelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.pickerLabel.Text = newValue != null ? (string)newValue : string.Empty;
                }
            }
        }

        public static string GetPickerLabel(BindableObject target)
        {
            if (PickerLabelProperty != null)
            {
                object result = target.GetValue(PickerLabelProperty);
                if (result != null) return (string)result;
            }
            return null;
        }

        public static void SetPickerLabel(BindableObject target, string value)
        {
            target.SetValue(PickerLabelProperty, value);
        }
        #endregion

        public string PickerTitle
        {
            get { return GetPickerTitle(this); }
            set { SetPickerTitle(this, value); }
        }
        #region PickerTitle
        public static readonly BindableProperty PickerTitleProperty = BindableProperty.CreateAttached(
                propertyName: "PickerTitle", returnType: typeof(string), declaringType: typeof(ESIPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPickerTitleChanged);

        private static void OnPickerTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.picker.Title = newValue != null ? (string)newValue : null;
                }
            }
        }

        public static string GetPickerTitle(BindableObject target)
        {
            if (PickerTitleProperty != null)
            {
                object result = target.GetValue(PickerTitleProperty);
                if (result != null) return (string)result;
            }
            return null;
        }

        public static void SetPickerTitle(BindableObject target, string value)
        {
            target.SetValue(PickerTitleProperty, value);
        }
        #endregion

        public IEnumerable<object> ItemsSource
        {
            get { return GetItemsSource(this); }
            set { SetItemsSource(this, value); }
        }
        #region ItemsSource
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.CreateAttached(
                propertyName: "ItemsSource", returnType: typeof(IEnumerable<object>), declaringType: typeof(ESIPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.picker.ItemsSource = (IEnumerable<object>)newValue;
                }
            }
        }

        public static IEnumerable<object> GetItemsSource(BindableObject target)
        {
            if (ItemsSourceProperty != null)
            {
                object result = target.GetValue(ItemsSourceProperty);
                if (result != null) return (IEnumerable<object>)result;
            }
            return null;
        }

        public static void SetItemsSource(BindableObject target, IEnumerable<object> value)
        {
            target.SetValue(ItemsSourceProperty, value);
        }
        #endregion     

        public int? SelectedIndex
        {
            get { return GetSelectedIndex(this); }
            set { SetSelectedIndex(this, value); }
        }
        #region SelectedIndex
        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedIndex", returnType: typeof(int?), declaringType: typeof(ESIPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedIndexChanged);

        private static void OnSelectedIndexChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue && newValue != null)
            {
                thisctrl.picker.SelectedIndex = (int)newValue;
            }
        }

        public static int? GetSelectedIndex(BindableObject target)
        {
            return (int?)target.GetValue(SelectedIndexProperty);
        }

        public static void SetSelectedIndex(BindableObject target, int? value)
        {
            target.SetValue(SelectedIndexProperty, value);
        }
        #endregion

        public object SelectedItem
        {
            get { return GetSelectedItem(this); }
            set { SetSelectedItem(this, value); }
        }
        #region SelectedItem
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedItem", returnType: typeof(object), declaringType: typeof(ESIPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            thisctrl.SelectionChanged(oldValue, newValue);
        }

        public static object GetSelectedItem(BindableObject target)
        {
            return target.GetValue(SelectedItemProperty);
        }

        public static void SetSelectedItem(BindableObject target, object value)
        {
            target.SetValue(SelectedItemProperty, value);
        }
        #endregion

        public string DisplayMemberPath
        {
            get { return GetDisplayMemberPath(this); }
            set { SetDisplayMemberPath(this, value); }
        }
        #region DisplayMemberPath
        public static readonly BindableProperty DisplayMemberPathProperty = BindableProperty.CreateAttached(
                propertyName: "DisplayMemberPath", returnType: typeof(string), declaringType: typeof(ESIPicker), defaultValue: string.Empty,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnDisplayMemberPathChanged);

        private static void OnDisplayMemberPathChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.picker.DisplayMemberPath = newValue?.ToString();
            }
        }

        public static string GetDisplayMemberPath(BindableObject target)
        {
            return (string)target.GetValue(DisplayMemberPathProperty);
        }

        public static void SetDisplayMemberPath(BindableObject target, string value)
        {
            target.SetValue(DisplayMemberPathProperty, value);
        }
        #endregion

        public string SelectedValuePath
        {
            get { return GetSelectedValuePath(this); }
            set { SetSelectedValuePath(this, value); }
        }
        #region SelectedValuePath
        public static readonly BindableProperty SelectedValuePathProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedValuePath", returnType: typeof(string), declaringType: typeof(ESIPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedValuePathChanged);

        private static void OnSelectedValuePathChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.picker.SelectedValuePath = newValue?.ToString();
            }
        }

        public static string GetSelectedValuePath(BindableObject target)
        {
            return (string)target.GetValue(SelectedValuePathProperty);
        }

        public static void SetSelectedValuePath(BindableObject target, string value)
        {
            target.SetValue(SelectedValuePathProperty, value);
        }
        #endregion

        public bool CanEdit
        {
            get { return GetCanEdit(this); }
            set { SetCanEdit(this, value); }
        }
        #region CanEdit
        public static readonly BindableProperty CanEditProperty = BindableProperty.CreateAttached(
                propertyName: "CanEdit", returnType: typeof(bool), declaringType: typeof(ESIPicker), defaultValue: true,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCanEditChanged);

        private static void OnCanEditChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.picker.IsEnabled = (bool)newValue;
                thisctrl.picker.IsVisible = (bool)newValue;
                thisctrl.pickerDisplay.IsVisible = !(bool)newValue;
                thisctrl.clearComponent.IsVisible = (bool)newValue;
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

        public Color ReadOnlyTextColor
        {
            get { return GetReadOnlyTextColor(this); }
            set { SetReadOnlyTextColor(this, value); }
        }
        #region ReadOnlyTextColor
        public static readonly BindableProperty ReadOnlyTextColorProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyTextColor", returnType: typeof(Color), declaringType: typeof(ESIPicker), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyTextColorChanged);

        private static void OnReadOnlyTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.pickerDisplay.TextColor = (Color)newValue;
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

        public string ReadOnlyFontSize
        {
            get { return GetReadOnlyFontSize(this); }
            set { SetReadOnlyFontSize(this, value); }
        }
        #region ReadOnlyFontSize
        public static readonly BindableProperty ReadOnlyFontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "ReadOnlyFontSize", returnType: typeof(string), declaringType: typeof(ESIPicker), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnReadOnlyFontSizeChanged);

        private static void OnReadOnlyFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                FontSizeConverter fsc = new FontSizeConverter();
                thisctrl.pickerDisplay.FontSize = (double)fsc.ConvertFromInvariantString((string)newValue);
            }
        }

        public static string GetReadOnlyFontSize(BindableObject target)
        {
            object result = target.GetValue(ReadOnlyFontSizeProperty);
            return (string)result;
        }

        public static void SetReadOnlyFontSize(BindableObject target, string value)
        {
            target.SetValue(ReadOnlyFontSizeProperty, value);
        }
        #endregion

        public bool ShowRequiredFlag
        {
            get { return GetShowRequiredFlag(this); }
            set { SetShowRequiredFlag(this, value); }
        }
        #region ShowRequiredFlag
        public static readonly BindableProperty ShowRequiredFlagProperty = BindableProperty.CreateAttached(
                propertyName: "ShowRequiredFlag", returnType: typeof(bool), declaringType: typeof(ESIPicker), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnShowRequiredFlagChanged);

        private static void OnShowRequiredFlagChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if ((bool)newValue)
                {
                    if (thisctrl.picker.SelectedItem == null)
                    {
                        thisctrl.required.Text = thisctrl.RequiredMessage;
                        thisctrl.required.IsVisible = true;
                    }
                    else
                    {
                        thisctrl.required.Text = null;
                        thisctrl.required.IsVisible = true;
                    }
                }
                else
                {
                    thisctrl.required.Text = null;
                    thisctrl.required.IsVisible = true;
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
                propertyName: "RequiredMessage", returnType: typeof(string), declaringType: typeof(ESIPicker), defaultValue: "Required",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnRequiredMessageChanged);

        private static void OnRequiredMessageChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
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

        public string PickerLabelFontSize
        {
            get { return GetPickerLabelFontSize(this); }
            set { SetPickerLabelFontSize(this, value); }
        }
        #region PIckerLabelFontSize
        public static readonly BindableProperty PickerLabelFontSizeProperty = BindableProperty.CreateAttached(
                propertyName: "PickerLabelFontSize", returnType: typeof(string), declaringType: typeof(ESIPicker), defaultValue: "Default",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPickerLabelFontSizeChanged);

        private static void OnPickerLabelFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                FontSizeConverter fsc = new FontSizeConverter();
                thisctrl.pickerLabel.FontSize = (double)fsc.ConvertFromInvariantString((string)newValue);
            }
        }

        public static string GetPickerLabelFontSize(BindableObject target)
        {
            object result = target.GetValue(PickerLabelFontSizeProperty);
            return (string)result;
        }

        public static void SetPickerLabelFontSize(BindableObject target, string value)
        {
            target.SetValue(PickerLabelFontSizeProperty, value);
        }
        #endregion

        public Color PickerLabelColor
        {
            get { return GetPickerLabelColor(this); }
            set { SetPickerLabelColor(this, value); }
        }
        #region PickerLabelColor
        public static readonly BindableProperty PickerLabelColorProperty = BindableProperty.CreateAttached(
                propertyName: "PickerLabelColor", returnType: typeof(Color), declaringType: typeof(ESIPicker), defaultValue: Color.Default,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPickerLabelColorChanged);

        private static void OnPickerLabelColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.pickerLabel.TextColor = (Color)newValue;
            }
        }

        public static Color GetPickerLabelColor(BindableObject target)
        {
            object result = target.GetValue(PickerLabelColorProperty);
            return (Color)result;
        }

        public static void SetPickerLabelColor(BindableObject target, Color value)
        {
            target.SetValue(PickerLabelColorProperty, value);
        }
        #endregion

        public Thickness PickerMargin
        {
            get { return GetPickerMargin(this); }
            set { SetPickerMargin(this, value); }
        }
        #region PickerMargin
        public static readonly BindableProperty PickerMarginProperty = BindableProperty.CreateAttached(
                propertyName: "PickerMargin", returnType: typeof(Thickness), declaringType: typeof(ESIPicker), defaultValue: new Thickness(0),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPickerMarginChanged);

        private static void OnPickerMarginChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.picker.Margin = (Thickness)newValue;
                thisctrl.pickerDisplay.Margin = (Thickness)newValue;
            }
        }

        public static Thickness GetPickerMargin(BindableObject target)
        {
            object result = target.GetValue(PickerMarginProperty);
            return (Thickness)result;
        }

        public static void SetPickerMargin(BindableObject target, Thickness value)
        {
            target.SetValue(PickerMarginProperty, value);
        }
        #endregion

        public string PickerPlaceholder
        {
            get { return GetPickerPlaceholder(this); }
            set { SetPickerPlaceholder(this, value); }
        }
        #region PickerPlaceholder
        public static readonly BindableProperty PickerPlaceholderProperty = BindableProperty.CreateAttached(
                propertyName: "PickerPlaceholder", returnType: typeof(string), declaringType: typeof(ESIPicker), defaultValue: "Pick from selection",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPickerPlaceholderChanged);

        private static void OnPickerPlaceholderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.PickerPlaceholder = (string)newValue;
            }
        }

        public static string GetPickerPlaceholder(BindableObject target)
        {
            object result = target.GetValue(PickerPlaceholderProperty);
            return (string)result;
        }

        public static void SetPickerPlaceholder(BindableObject target, string value)
        {
            target.SetValue(PickerPlaceholderProperty, value);
        }
        #endregion

        public Color PickerPlaceholderColor
        {
            get { return GetPickerPlaceholderColor(this); }
            set { SetPickerPlaceholderColor(this, value); }
        }
        #region PickerPlaceholderColor
        public static readonly BindableProperty PickerPlaceholderColorProperty = BindableProperty.CreateAttached(
                propertyName: "PickerPlaceholderColor", returnType: typeof(Color), declaringType: typeof(ESIPicker), defaultValue: Color.Gray,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnPickerPlaceholderColorChanged);

        private static void OnPickerPlaceholderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIPicker thisctrl = (ESIPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.PickerPlaceholderColor = (Color)newValue;
            }
        }

        public static Color GetPickerPlaceholderColor(BindableObject target)
        {
            object result = target.GetValue(PickerPlaceholderColorProperty);
            return (Color)result;
        }

        public static void SetPickerPlaceholderColor(BindableObject target, Color value)
        {
            target.SetValue(PickerPlaceholderColorProperty, value);
        }
        #endregion


        public ESIPicker()
        {
            InitializeComponent();
            this.pickerDisplay.Text = this.PickerPlaceholder;
            this.pickerDisplay.TextColor = this.PickerPlaceholderColor;
        }

        private void picker_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.SelectedItem = e.SelectedItem;
        }

        private void picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.SelectedIndex = picker.SelectedIndex;
        }
        private void Clear_Tapped(object sender, EventArgs e)
        {
            this.SelectedItem = null;
        }

        private void SelectionChanged(object oldValue, object newValue)
        {
            if (newValue == null)
            {
                this.picker.SelectedItem = null;
                this.pickerDisplay.Text = null;
                this.clearComponent.IsVisible = false;
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
                if (oldValue != newValue)
                {
                    this.picker.SelectedItem = newValue;
                    this.pickerDisplay.Text = newValue.ToString();
                    this.required.Text = null;
                    this.required.IsVisible = false;
                    this.clearComponent.IsVisible = true;
                }
            }
        }
    }
}