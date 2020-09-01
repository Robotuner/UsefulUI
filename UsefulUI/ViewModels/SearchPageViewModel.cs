using ESIXamarinLib.Controls.ViewModels;
using ESIXamarinLib.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UsefulUI.ViewModels
{
    public class SearchPageViewModel : HelpPageViewModel
    {
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
                }
            }
        }

        private List<ExampleSearchModel> source;
        public List<ExampleSearchModel> Source
        {
            get { return source; }
            set
            {
                if (source != value)
                {
                    source = value;
                    OnPropertyChanged("Source");
                }
            }
        }

        private ObservableCollection<SearchItem> filteredList;
        public ObservableCollection<SearchItem> FilteredList
        {
            get { return filteredList; }
            set
            {
                if (filteredList != value)
                {
                    filteredList = value;
                    OnPropertyChanged("FilteredList");
                }
            }
        }

        private ObservableCollection<ISearchItem> selectionList;
        public ObservableCollection<ISearchItem> SelectionList
        {
            get { return selectionList; }
            set
            {
                if (selectionList != value)
                {
                    selectionList = value;
                    OnPropertyChanged("SelectionList");
                }
            }
        }

        private bool editMode;
        public bool EditMode
        {
            get { return editMode; }
            set
            {
                if (editMode != value)
                {
                    editMode = value;
                    OnPropertyChanged("EditMode");
                }
            }
        }

        private bool isRequired;
        public bool IsRequired
        {
            get { return isRequired; }
            set
            {
                if (isRequired != value)
                {
                    isRequired = value;
                    OnPropertyChanged("IsRequired");
                }
            }
        }

        public SearchPageViewModel()
        {
            this.SetHelp(Resource.SearchHelp);
            this.Source = new List<ExampleSearchModel>();
            for (int n = 0; n<100; n++)
            {
                this.Source.Add(new ExampleSearchModel());
            }
            this.SelectionList = new ObservableCollection<ISearchItem>();
            this.SelectionList.CollectionChanged += SelectionList_CollectionChanged;
        }

        private void SelectionList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;               
            }
        }

        public void OnAppearing()
        {
            this.FilteredList = new ObservableCollection<SearchItem>();
            foreach (var item in this.Source)
            {
                this.FilteredList.Add(new SearchItem(item.ID, item.ID, item));
            }
        }
        public void FilterChanged(string filter)
        {
            this.FilteredList.Clear();
            if (!string.IsNullOrEmpty(filter))
            {
                foreach (ExampleSearchModel item in this.Source.Where(n => n.ID.Contains(filter.ToUpper())).ToList())
                {
                    this.FilteredList.Add(this.CheckIfSelected(item));
                }
            }
            else
            {
                foreach (ExampleSearchModel item in this.Source.ToList())
                {
                    this.FilteredList.Add(this.CheckIfSelected(item));
                }
            }
        }

        private SearchItem CheckIfSelected(ExampleSearchModel model)
        {
            SearchItem sitem = new SearchItem(model.ID, model.ID, model);
            sitem.IsSelected = this.SelectionList.Any(n => n.Name == model.ID);
            return sitem;              
        }
    }
}
