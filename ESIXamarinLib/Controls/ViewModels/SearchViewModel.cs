using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ESIXamarinLib.Controls.ViewModels
{
    public class SearchViewModel<T> : BaseViewModel
    {
        protected PropertyInfo[] objProperties = null;
        protected Type objType;
        protected Func<T, Task> Callback { get; set; }
        public ICommand ListItemTappedCommand { get; set; }

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

        public SearchViewModel() { }
  
        public SearchViewModel(Func<T, string> propertyName, List<T> list, Func<T, Task> callback)
        {
            this.Callback = callback;
            this.ListItemTappedCommand = new Command<ItemTappedEventArgs>(async (o) => await OnListItemTapped(o));
            this.objType = typeof(T);
            this.objProperties = objType.GetProperties();

            this.AllObjects = new List<SearchClass<T>>();
            foreach (T obj in list)
            {
                string propertyValue = propertyName(obj);
                this.AllObjects.Add(new SearchClass<T>(propertyValue == null ? null : propertyValue.ToString(), obj));
            }

            this.OnFilterChanged();
        }

        private List<SearchClass<T>> AllObjects { get; set; }

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

        private ObservableCollection<SearchClass<T>> sourceList;
        public ObservableCollection<SearchClass<T>> SourceList
        {
            get
            {
                if (sourceList == null)
                {
                    sourceList = new ObservableCollection<SearchClass<T>>();
                }
                return sourceList;
            }
        }

        public async Task OnListItemTapped(object o)
        {
            this.IsBusy = true;
            try
            {
                ItemTappedEventArgs tea = o as ItemTappedEventArgs;
                var item = tea.Item as SearchClass<T>;
                await this.Callback?.Invoke(item.SearchObject);
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

        private void OnFilterChanged()
        {
            try
            {
                this.IsBusy = true;
                if (string.IsNullOrEmpty(this.Filter))
                    this.Filter = string.Empty;

                this.SourceList.Clear();
                string match = this.Filter.ToLower();
                foreach (SearchClass<T> item in this.AllObjects.Where(n => n.DisplayField.ToLower().Contains(match)))
                {
                    this.SourceList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                this.IsBusy = false;
            }

        }

        private object ValueOf(object obj, string propertyName)
        {
            PropertyInfo objProperty = this.objProperties.SingleOrDefault(n => n.Name == propertyName);
            return objProperty.GetValue(obj, null);
        }
    }
}
