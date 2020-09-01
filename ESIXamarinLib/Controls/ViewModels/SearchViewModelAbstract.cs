using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ESIXamarinLib.Controls.ViewModels
{
    public interface IRefreshFilter
    {
        Task RefreshFilter();
    }

    public abstract class SearchViewModel<T,S> : BaseViewModel, IRefreshFilter where S: SearchClass<T>
    {
        protected Func<string, Task<List<T>>> FilterCallback { get; set; }
        protected Func<T, Task<string>> DisplayCallback { get; set; }
        protected Func<T, Task<(string, bool)>> DisplayCallback2 { get; set; }
        protected Func<T, Task> ReturnSelectedItem { get; set; }
        protected int MinFilterLength { get; set; }
        public ICommand ListItemTappedCommand { get; set; }

        private string filter;
        public string Filter
        {
            get { return filter; }
            set
            {
                if (filter != value)
                {
                    filter = value;
                    OnPropertyChanged("Filter");
                    this.OnFilterChanged();
                }
            }
        }

        private ObservableCollection<S> sourceList;
        public virtual ObservableCollection<S> SourceList
        {
            get
            {
                if (sourceList == null)
                {
                    sourceList = new ObservableCollection<S>();
                }
                return sourceList;
            }
        }

        private string searchCriteria;
        public string SearchCriteria
        {
            get { return searchCriteria; }
            set
            {
                if (searchCriteria != value)
                {
                    searchCriteria = value;
                    OnPropertyChanged("SearchCriteria");
                }
            }
        }

        public SearchViewModel(Func<string, Task<List<T>>> filterCallback, Func<T, Task<string>> displayCallback, Func<T, Task> returnSelectedItem,
             int minFilterLength = 1)
        {
            this.FilterCallback = filterCallback;
            this.DisplayCallback = displayCallback;
            this.ReturnSelectedItem = returnSelectedItem;
            this.MinFilterLength = minFilterLength;
            this.ListItemTappedCommand = new Command<ItemTappedEventArgs>(async (o) => await OnListItemTapped(o));

            if (minFilterLength > 0)
            {
                this.SearchCriteria = string.Format("{0} character min search length", minFilterLength);
            }
        }

        public SearchViewModel(Func<string, Task<List<T>>> filterCallback, Func<T, Task<(string, bool)>> displayCallback, Func<T, Task> callback,
            int minFilterLength = 1)
        {
            this.FilterCallback = filterCallback;
            this.DisplayCallback2 = displayCallback;
            this.ReturnSelectedItem = callback;
            this.MinFilterLength = minFilterLength;
            this.ListItemTappedCommand = new Command<ItemTappedEventArgs>(async (o) => await OnListItemTapped(o));

            if (minFilterLength > 0)
            {
                this.SearchCriteria = string.Format("{0} character min search length", minFilterLength);
            }
        }

        public Task RefreshFilter()
        {
            this.OnFilterChanged();
            return Task.CompletedTask;
        }

        public async Task OnListItemTapped(object o)
        {
            try
            {
                this.IsBusy = true;
                ItemTappedEventArgs tea = o as ItemTappedEventArgs;
                var item = tea.Item as SearchClass<T>;
                this.ReturnSelectedItem?.Invoke(item.SearchObject);
                await Task.CompletedTask;
                throw new Exception("SearchViewModel needs to pop view here!");
                //await PopAsync();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        protected abstract S CreateItem(string propertyName, T item);
        protected abstract S CreateItem(string propertyName, bool isSelected, T item);
        protected abstract S CreateItem(string propertyName, string contentName, T item);
        protected abstract S CreateItem(string propertyName, string contentName, bool isSelected, T item);
        protected virtual async void OnFilterChanged()
        {
            this.IsBusy = true;
            try
            {
                if (this.SourceList != null && (this.MinFilterLength == 0 || this.Filter?.Length >= this.MinFilterLength))
                {
                    this.SourceList.Clear();

                    string match = this.Filter?.ToLower();
                    var callBackResult = await this.FilterCallback?.Invoke(match);
                    S newItem = null;
                    foreach (T item in callBackResult)
                    {
                        if (this.DisplayCallback != null)
                        {
                            string propertyName = await this.DisplayCallback?.Invoke(item);
                            newItem = CreateItem(propertyName, item);
                        }
                        else if (this.DisplayCallback2 != null)
                        {
                            (string propertyName, bool isSelected) = await this.DisplayCallback2?.Invoke(item);
                            newItem = CreateItem(propertyName, isSelected, item);
                        }

                        this.SourceList.Add(newItem);
                    }

                    this.CheckItemsInSelectedList();
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }
        protected virtual void CheckItemsInSelectedList()
        {
            throw new NotImplementedException("SezarchViewModelEnhanced.CheckIntesInSelectedList is not implemented");
        }
    }
}
