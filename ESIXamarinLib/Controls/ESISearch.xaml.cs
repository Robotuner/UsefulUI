using ESIXamarinLib.Controls.ViewModels;
using ESIXamarinLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESIXamarinLib.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ESISearch : ContentView
    {
        public string SearchTitle
        {
            get { return GetSearchTitle(this); }
            set { SetSearchTitle(this, value); }
        }
        #region SearchTitle
        public static readonly BindableProperty SearchTitleProperty = BindableProperty.CreateAttached(
                propertyName: "SearchTitle", returnType: typeof(string), declaringType: typeof(ESISearch), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSearchTitleChanged);

        private static void OnSearchTitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESISearch thisctrl = (ESISearch)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.fieldLabel.Text = (string)newValue;
            }
        }

        public static string GetSearchTitle(BindableObject target)
        {
            object result = target.GetValue(SearchTitleProperty);
            return (string)result;
        }

        public static void SetSearchTitle(BindableObject target, string value)
        {
            target.SetValue(SearchTitleProperty, value);
        }
        #endregion

        public Action<string> FilterChangeCallback
        {
            get { return GetFilterChangeCallback(this); }
            set { SetFilterChangeCallback(this, value); }
        }
        #region FilterChangeCallback
        public static readonly BindableProperty FilterChangeCallbackProperty = BindableProperty.CreateAttached(
                propertyName: "FilterChangeCallback", returnType: typeof(Action<string>), declaringType: typeof(ESISearch), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnFilterChangeCallbackChanged);

        private static void OnFilterChangeCallbackChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESISearch thisctrl = (ESISearch)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.FilterChangeCallback = (Action<string>)newValue;
            }
        }

        public static Action<string> GetFilterChangeCallback(BindableObject target)
        {
            object result = target.GetValue(FilterChangeCallbackProperty);
            return (Action<string>)result;
        }

        public static void SetFilterChangeCallback(BindableObject target, Action<string> value)
        {
            target.SetValue(FilterChangeCallbackProperty, value);
        }
        #endregion

        public ObservableCollection<SearchItem> SourceList
        {
            get { return GetSourceList(this); }
            set { SetSourceList(this, value); }
        }
        #region SourceList
        public static readonly BindableProperty SourceListProperty = BindableProperty.CreateAttached(
                propertyName: "SourceList", returnType: typeof(ObservableCollection<SearchItem>), declaringType: typeof(ESISearch), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSourceListChanged);

        private static void OnSourceListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESISearch thisctrl = (ESISearch)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SearchableList.ItemsSource = (ObservableCollection<SearchItem>)newValue;
            }
        }

        public static ObservableCollection<SearchItem> GetSourceList(BindableObject target)
        {
            object result = target.GetValue(SourceListProperty);
            return (ObservableCollection<SearchItem>)result;
        }

        public static void SetSourceList(BindableObject target, ObservableCollection<SearchItem> value)
        {
            target.SetValue(SourceListProperty, value);
        }
        #endregion

        public bool IsSingleSelect
        {
            get { return GetIsSingleSelect(this); }
            set { SetIsSingleSelect(this, value); }
        }
        #region IsSingleSelect
        public static readonly BindableProperty IsSingleSelectProperty = BindableProperty.CreateAttached(
                propertyName: "IsSingleSelect", returnType: typeof(bool), declaringType: typeof(ESISearch), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIsSingleSelectChanged);

        private static void OnIsSingleSelectChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESISearch thisctrl = (ESISearch)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                //thisctrl.IsSingleSelect = (bool)newValue;
            }
        }

        public static bool GetIsSingleSelect(BindableObject target)
        {
            object result = target.GetValue(IsSingleSelectProperty);
            return (bool)result;
        }

        public static void SetIsSingleSelect(BindableObject target, bool value)
        {
            target.SetValue(IsSingleSelectProperty, value);
        }
        #endregion

        public ObservableCollection<ISearchItem> SelectionList
        {
            get { return GetSelectionList(this); }
            set { SetSelectionList(this, value); }
        }
        #region SelectionList
        public static readonly BindableProperty SelectionListProperty = BindableProperty.CreateAttached(
                propertyName: "SelectionList", returnType: typeof(ObservableCollection<ISearchItem>), declaringType: typeof(ESISearch), defaultValue: new ObservableCollection<ISearchItem>(),
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSelectionListChanged);

        private static void OnSelectionListChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESISearch thisctrl = (ESISearch)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.selectedItems.ItemsSource = (ObservableCollection<ISearchItem>)newValue;
            }
        }


        public static ObservableCollection<ISearchItem> GetSelectionList(BindableObject target)
        {
            object result = target.GetValue(SelectionListProperty);
            return (ObservableCollection<ISearchItem>)result;
        }

        public static void SetSelectionList(BindableObject target, ObservableCollection<ISearchItem> value)
        {
            target.SetValue(SelectionListProperty, value);
        }
        #endregion

        public bool ShowRequiredFlag
        {
            get { return GetShowRequiredFlag(this); }
            set { SetShowRequiredFlag(this, value); }
        }
        #region ShowRequiredFlag
        public static readonly BindableProperty ShowRequiredFlagProperty = BindableProperty.CreateAttached(
                propertyName: "ShowRequiredFlag", returnType: typeof(bool), declaringType: typeof(ESISearch), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnShowRequiredFlagChanged);

        private static void OnShowRequiredFlagChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESISearch thisctrl = (ESISearch)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.SetRequiredMessage();
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
                propertyName: "CanEdit", returnType: typeof(bool), declaringType: typeof(ESISearch), defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCanEditChanged);

        private static void OnCanEditChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ESISearch thisctrl = (ESISearch)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.searchBar.IsVisible = (bool)newValue;
                thisctrl.pickList.IsVisible = (bool)newValue;
                thisctrl.SetSelectedItemsHeightRequest();
                thisctrl.SetSelectedCanEdit((bool)newValue);
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

        public ESISearch()
        {
            InitializeComponent();

            this.CanEdit = false;
            this.searchBar.IsVisible = this.CanEdit;
            this.pickList.IsVisible = this.CanEdit;
            this.SetSelectedItemsHeightRequest();
            this.SetRequiredMessage();
        }

        private void SetRequiredMessage()
        {
            if (this.ShowRequiredFlag && this.SelectionList.Count == 0)
            {
                this.required.Text = "Required";
                this.required.TextColor = Color.Red;
            }
            else
            {
                this.required.Text = "No items selected";
                this.required.TextColor = Color.Gray;
            }
        }

        private void ItemTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if ((sender as Grid).BindingContext is ISearchItem sc)   
            {
                if (!sc.CanEdit)
                    return;

                if (this.IsSingleSelect)
                {
                    foreach (ISearchItem item in this.SourceList.Where(n => (n as ISearchItem).IsSelected))
                    {
                        if (item != sc)
                        {
                            item.IsSelected = false;
                        }
                        this.SelectionList.Remove(item);
                    }
                }
                else
                {
                    if (sc.IsSelected)
                    {
                        sc.IsSelected = !sc.IsSelected;
                        this.SelectionList.Remove(sc);
                    }
                    else
                    {
                        sc.IsSelected = !sc.IsSelected;
                        this.SelectionList.Add(sc);
                    }
                }
                this.SetSelectedItemsHeightRequest();
            }
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.FilterChangeCallback?.Invoke(this.filter.Text);
        }

        private void SetSelectedItemsHeightRequest()
        {
            int selectedCount = this.SelectionList.Count;
            if (this.CanEdit)
            {
                if (selectedCount == 0)
                    this.selectedItems.HeightRequest = 40;
                else if (selectedCount < 5)
                    this.selectedItems.HeightRequest = selectedCount * 30;
                else
                    this.selectedItems.HeightRequest = 4 * 30;
            }
            else
            {
                if (selectedCount == 0)
                {
                    this.selectedItems.HeightRequest = 40;
                }
                else
                {
                    this.selectedItems.HeightRequest = selectedCount * 30;
                }
            }
            this.selectedCount.Text = string.Format("({0})", selectedCount);
        }

        private void SetSelectedCanEdit(bool canEdit)
        {
            foreach(ISearchItem item in this.SelectionList)
            {
                item.CanEdit = canEdit;
            }
        }
    }
}