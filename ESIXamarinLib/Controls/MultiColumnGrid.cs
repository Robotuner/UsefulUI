using ESIXamarinLib.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ESIXamarinLib.Controls
{
    public class MultiColumnGrid : Grid
    {
        public int ScreenWidth
        {
            get { return GetScreenWidth(this); }
            set { SetScreenWidth(this, value); }
        }
        #region ScreenWidth
        public static readonly BindableProperty ScreenWidthProperty = BindableProperty.CreateAttached(
                propertyName: "ScreenWidth", returnType: typeof(int), declaringType: typeof(MultiColumnGrid), defaultValue: 0,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnScreenWidthChanged);

        private static void OnScreenWidthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MultiColumnGrid thisctrl = (MultiColumnGrid)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.InitGrid();
            }
        }

        public static int GetScreenWidth(BindableObject target)
        {
            object result = target.GetValue(ScreenWidthProperty);
            return (int)result;
        }

        public static void SetScreenWidth(BindableObject target, int value)
        {
            target.SetValue(ScreenWidthProperty, value);
        }
        #endregion

        public int MinColumnWidth
        {
            get { return GetMinColumnWidth(this); }
            set { SetMinColumnWidth(this, value); }
        }
        #region MinColumnWidth
        public static readonly BindableProperty MinColumnWidthProperty = BindableProperty.CreateAttached(
                propertyName: "MinColumnWidth", returnType: typeof(int), declaringType: typeof(MultiColumnGrid), defaultValue: 100,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnMinColumnWidthChanged);

        private static void OnMinColumnWidthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MultiColumnGrid thisctrl = (MultiColumnGrid)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.InitGrid();
            }
        }

        public static int GetMinColumnWidth(BindableObject target)
        {
            object result = target.GetValue(MinColumnWidthProperty);
            return (int)result;
        }

        public static void SetMinColumnWidth(BindableObject target, int value)
        {
            target.SetValue(MinColumnWidthProperty, value);
        }
        #endregion

        public string RowHeight
        {
            get { return GetRowHeight(this); }
            set { SetRowHeight(this, value); }
        }
        #region RowHeight
        public static readonly BindableProperty RowHeightProperty = BindableProperty.CreateAttached(
                propertyName: "RowHeight", returnType: typeof(string), declaringType: typeof(MultiColumnGrid), defaultValue: "*",
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnRowHeightChanged);

        private static void OnRowHeightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MultiColumnGrid thisctrl = (MultiColumnGrid)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.InitGrid();
            }
        }

        public static string GetRowHeight(BindableObject target)
        {
            object result = target.GetValue(RowHeightProperty);
            return (string)result;
        }

        public static void SetRowHeight(BindableObject target, string value)
        {
            target.SetValue(RowHeightProperty, value);
        }
        #endregion


        public MultiColumnGridFillDirection FillDirection
        {
            get { return GetFillDirection(this); }
            set { SetFillDirection(this, value); }
        }
        #region FillDirection
        public static readonly BindableProperty FillDirectionProperty = BindableProperty.CreateAttached(
                propertyName: "FillDirection", returnType: typeof(MultiColumnGridFillDirection), declaringType: typeof(MultiColumnGrid), defaultValue: MultiColumnGridFillDirection.across,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnFillDirectionChanged);

        private static void OnFillDirectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MultiColumnGrid thisctrl = (MultiColumnGrid)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                thisctrl.InitGrid(); 
            }
        }

        public static MultiColumnGridFillDirection GetFillDirection(BindableObject target)
        {
            object result = target.GetValue(FillDirectionProperty);
            return (MultiColumnGridFillDirection)result;
        }

        public static void SetFillDirection(BindableObject target, MultiColumnGridFillDirection value)
        {
            target.SetValue(FillDirectionProperty, value);
        }
        #endregion
        public ObservableCollection<ISearchItem> ItemsSource
        {
            get { return GetItemsSource(this); }
            set { SetItemsSource(this, value); }
        }
        #region ItemsSource
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.CreateAttached(
                propertyName: "ItemsSource", returnType: typeof(ObservableCollection<ISearchItem>), declaringType: typeof(MultiColumnGrid), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            MultiColumnGrid thisctrl = (MultiColumnGrid)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (oldValue != null)
                {
                    thisctrl.ItemsSource.CollectionChanged -= thisctrl.ItemsSource_CollectionChanged;
                }
                thisctrl.ItemsSource.CollectionChanged += thisctrl.ItemsSource_CollectionChanged;
                thisctrl.InitGrid();
            }
        }

        public static ObservableCollection<ISearchItem> GetItemsSource(BindableObject target)
        {
            object result = target.GetValue(ItemsSourceProperty);
            return (ObservableCollection<ISearchItem>)result;
        }

        public static void SetItemsSource(BindableObject target, ObservableCollection<ISearchItem> value)
        {
            target.SetValue(ItemsSourceProperty, value);

        }
        #endregion

        public Func<ISearchItem, View> ViewSelector { get; set; }
        public MultiColumnGrid() : base()
        {

        }

        private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // just reinit the entire grid
            this.InitGrid();
        }

        public void InitGrid()
        {
            if (this.ScreenWidth == 0 || this.ItemsSource == null || this.ViewSelector == null)
                return;

            if (this.ColumnDefinitions != null || this.RowDefinitions != null)
            {
                this.Children.Clear();
                this.RowDefinitions.Clear();
                this.ColumnDefinitions.Clear();
            }
            this.RowSpacing = 1;
            this.ColumnSpacing = 1;
            this.ColumnDefinitions = new ColumnDefinitionCollection();
            this.RowDefinitions = new RowDefinitionCollection();
            // first decide how many columns we can fit
            int columns = this.ScreenWidth / this.MinColumnWidth;
            int columnDim = this.ScreenWidth / columns;
            this.ColumnDefinitions = new ColumnDefinitionCollection();
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = columnDim });
            // now decide how many rows we need
            int rows = this.ItemsSource.Count / columns;
            if (this.ItemsSource.Count % columns > 0) rows += 1;
            // now add the rows
            this.RowDefinitions = new RowDefinitionCollection();

            GridLength gl = GridLength.Auto;
            switch (RowHeight.ToLower())
            {
                case "auto": gl = GridLength.Auto; break;
                case "*": gl = new GridLength(1, GridUnitType.Star); break;
                default:
                    if (double.TryParse(RowHeight, out double ans))
                    {
                        gl = new GridLength(ans);
                    }
                    break;
            }

            if (this.FillDirection == MultiColumnGridFillDirection.across)
            {
                this.FillAcross(rows, columns, gl);
            }
            else
            {
                this.FillDown(rows, columns, gl);
            }

        }

        private void FillDown(int rows, int columns, GridLength gl)
        {
            int ndx = 0;
            for (int row = 0; row < rows; row++)
            {
                this.RowDefinitions.Add(new RowDefinition() { Height = gl });
                for (int col = 0; col < columns; col++)
                {
                    ndx = row + col * rows;
                    if (ndx < this.ItemsSource.Count)
                    {
                        View view = this.ViewSelector?.Invoke(this.ItemsSource[ndx]);
                        view.BindingContext = this.ItemsSource[ndx];
                        if (view != null)
                        {
                            this.Children.Add(view, col, row);
                        }   
                    }
                }
            }
        }

        private void FillAcross(int rows, int columns, GridLength gl)
        {
            int pos = 0;
            for (int row = 0; row < rows; row++)
            {
                this.RowDefinitions.Add(new RowDefinition() { Height = gl });
                for (int col = 0; col < columns; col++)
                {
                    if (pos < this.ItemsSource.Count)
                    {
                        View view = this.ViewSelector?.Invoke(this.ItemsSource[pos]);
                        view.BindingContext = this.ItemsSource[pos];
                        if (view != null)
                        {
                            this.Children.Add(view, col, row);
                        }
                        pos++;
                    }
                }
            }
        }
    }
}
