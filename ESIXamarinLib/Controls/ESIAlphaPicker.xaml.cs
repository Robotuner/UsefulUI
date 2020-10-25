using ESIXamarinLib.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESIAlphaPicker : ContentView
    {
        public ObservableCollection<ISearchItem> SourceList
        {
            get { return GetSourceList(this); }
            set { SetSourceList(this, value); }
        }
        #region SourceList
        public static readonly BindableProperty SourceListProperty = BindableProperty.CreateAttached(
                propertyName: "SourceList", returnType: typeof(ObservableCollection<ISearchItem>), declaringType: typeof(ESIAlphaPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSourceListChanged);

        private static void OnSourceListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SearchableList.ItemsSource = (ObservableCollection<ISearchItem>)newValue;
                if (thisctrl.SelectedItem == null && thisctrl.ChoiceList != null)
                {
                    thisctrl.SelectedChoice = thisctrl.ChoiceList.First();
                }
            }
        }

        public static ObservableCollection<ISearchItem> GetSourceList(BindableObject target)
        {
            object result = target.GetValue(SourceListProperty);
            return (ObservableCollection<ISearchItem>)result;
        }

        public static void SetSourceList(BindableObject target, ObservableCollection<ISearchItem> value)
        {
            target.SetValue(SourceListProperty, value);
        }
        #endregion

        public ObservableCollection<ISearchItem> ChoiceList
        {
            get { return GetChoiceList(this); }
            set { SetChoiceList(this, value); }
        }
        #region ChoiceList
        public static readonly BindableProperty ChoiceListProperty = BindableProperty.CreateAttached(
                propertyName: "ChoiceList", returnType: typeof(ObservableCollection<ISearchItem>), declaringType: typeof(ESIAlphaPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnChoiceListChanged);

        private static void OnChoiceListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.choiceList.ItemsSource = (ObservableCollection<ISearchItem>)newValue;
            }
        }

        public static ObservableCollection<ISearchItem> GetChoiceList(BindableObject target)
        {
            object result = target.GetValue(ChoiceListProperty);
            return (ObservableCollection<ISearchItem>)result;
        }

        public static void SetChoiceList(BindableObject target, ObservableCollection<ISearchItem> value)
        {
            target.SetValue(ChoiceListProperty, value);
        }
        #endregion

        public DataTemplate Template
        {
            get { return GetTemplate(this); }
            set { SetTemplate(this, value); }
        }
        #region Template
        public static readonly BindableProperty TemplateProperty = BindableProperty.CreateAttached(
                propertyName: "Template", returnType: typeof(DataTemplate), declaringType: typeof(ESIAlphaPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnTemplateChanged);

        private static void OnTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SearchableList.ItemTemplate = (DataTemplate)newValue;
            }
        }

        public static DataTemplate GetTemplate(BindableObject target)
        {
            object result = target.GetValue(TemplateProperty);
            return (DataTemplate)result;
        }

        public static void SetTemplate(BindableObject target, DataTemplate value)
        {
            target.SetValue(TemplateProperty, value);
        }
        #endregion

        public ISearchItem SelectedItem
        {
            get { return GetSelectedItem(this); }
            set { SetSelectedItem(this, value); }
        }
        #region SelectedItem
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedItem", returnType: typeof(ISearchItem), declaringType: typeof(ESIAlphaPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SearchableList.SelectedItem = (ISearchItem)newValue;
            }
        }

        public static ISearchItem GetSelectedItem(BindableObject target)
        {
            object result = target.GetValue(SelectedItemProperty);
            return (ISearchItem)result;
        }

        public static void SetSelectedItem(BindableObject target, ISearchItem value)
        {
            target.SetValue(SelectedItemProperty, value);
        }
        #endregion

        public ISearchItem SelectedChoice
        {
            get { return GetSelectedChoice(this); }
            set { SetSelectedChoice(this, value); }
        }
        #region SelectedChoice
        public static readonly BindableProperty SelectedChoiceProperty = BindableProperty.CreateAttached(
                propertyName: "SelectedChoice", returnType: typeof(ISearchItem), declaringType: typeof(ESIAlphaPicker), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectedChoiceChanged);

        private static void OnSelectedChoiceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.choiceList.SelectedItem = (ISearchItem)newValue;
            }
        }

        public static ISearchItem GetSelectedChoice(BindableObject target)
        {
            object result = target.GetValue(SelectedChoiceProperty);
            return (ISearchItem)result;
        }

        public static void SetSelectedChoice(BindableObject target, ISearchItem value)
        {
            target.SetValue(SelectedChoiceProperty, value);
        }
        #endregion

        public Color ItemSourceBackground
        {
            get { return GetItemSourceBackground(this); }
            set { SetItemSourceBackground(this, value); }
        }
        #region ItemSourceBackground
        public static readonly BindableProperty ItemSourceBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "ItemSourceBackground", returnType: typeof(Color), declaringType: typeof(ESIAlphaPicker), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnItemSourceBackgroundChanged);

        private static void OnItemSourceBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SearchableList.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetItemSourceBackground(BindableObject target)
        {
            object result = target.GetValue(ItemSourceBackgroundProperty);
            return (Color)result;
        }

        public static void SetItemSourceBackground(BindableObject target, Color value)
        {
            target.SetValue(ItemSourceBackgroundProperty, value);
        }
        #endregion

        public Color ChoiceSourceBackground
        {
            get { return GetChoiceSourceBackground(this); }
            set { SetChoiceSourceBackground(this, value); }
        }
        #region ChoiceSourceBackground
        public static readonly BindableProperty ChoiceSourceBackgroundProperty = BindableProperty.CreateAttached(
                propertyName: "ChoiceSourceBackground", returnType: typeof(Color), declaringType: typeof(ESIAlphaPicker), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnChoiceSourceBackgroundChanged);

        private static void OnChoiceSourceBackgroundChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.choiceList.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetChoiceSourceBackground(BindableObject target)
        {
            object result = target.GetValue(ChoiceSourceBackgroundProperty);
            return (Color)result;
        }

        public static void SetChoiceSourceBackground(BindableObject target, Color value)
        {
            target.SetValue(ChoiceSourceBackgroundProperty, value);
        }
        #endregion

        public Color ControlBkgColor
        {
            get { return GetControlBkgColor(this); }
            set { SetControlBkgColor(this, value); }
        }
        #region ControlBkgColor
        public static readonly BindableProperty ControlBkgColorProperty = BindableProperty.CreateAttached(
                propertyName: "ControlBkgColor", returnType: typeof(Color), declaringType: typeof(ESIAlphaPicker), defaultValue: Color.Transparent,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnControlBkgColorChanged);

        private static void OnControlBkgColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.controlBackground.BackgroundColor = (Color)newValue;
            }
        }

        public static Color GetControlBkgColor(BindableObject target)
        {
            object result = target.GetValue(ControlBkgColorProperty);
            return (Color)result;
        }

        public static void SetControlBkgColor(BindableObject target, Color value)
        {
            target.SetValue(ControlBkgColorProperty, value);
        }
        #endregion

        public double ChoiceColumnWidth
        {
            get { return GetChoiceColumnWidth(this); }
            set { SetChoiceColumnWidth(this, value); }
        }
        #region ChoiceColumnWidth
        public static readonly BindableProperty ChoiceColumnWidthProperty = BindableProperty.CreateAttached(
                propertyName: "ChoiceColumnWidth", returnType: typeof(double), declaringType: typeof(ESIAlphaPicker), defaultValue: 12.0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnChoiceColumnWidthChanged);

        private static void OnChoiceColumnWidthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESIAlphaPicker thisctrl = (ESIAlphaPicker)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.controlBackground.ColumnDefinitions[1].Width = (double)newValue;
            }
        }

        public static double GetChoiceColumnWidth(BindableObject target)
        {
            object result = target.GetValue(ChoiceColumnWidthProperty);
            return (double)result;
        }

        public static void SetChoiceColumnWidth(BindableObject target, double value)
        {
            target.SetValue(ChoiceColumnWidthProperty, value);
        }
        #endregion

        public ESIAlphaPicker()
        {
            InitializeComponent();
            this.ChoiceList = new ObservableCollection<ISearchItem>();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                this.ChoiceList.Add(new SearchItem(i.ToString(), i.ToString(), null));
            }
            this.SelectedChoice = this.ChoiceList.First();
        }
    }
}