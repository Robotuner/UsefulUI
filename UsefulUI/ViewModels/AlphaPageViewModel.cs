using ESIXamarinLib.Controls.ViewModels;
using ESIXamarinLib.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UsefulUI.ViewModels
{
    public class AlphaPageViewModel : HelpPageViewModel
    {
        // A collection of your model data types then you want the user to select
        // This is not passed to the control, it is simply your list of model items.
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

        // this is optional.  A collection of the alpha choices.  If this is not supplied
        // it will default to A-Z.  If you want to use lower case, the set this list to a-z.
        // Or if you want to use 0-9, that will work too.
        private ObservableCollection<ISearchItem> alphaList;
        public ObservableCollection<ISearchItem> AlphaList
        {
            get { return alphaList; }
            set
            {
                if (alphaList != value)
                {
                    alphaList = value;
                    OnPropertyChanged("AlphaList");
                }
            }
        }

        // this is filtered collection of ISearchItems based on the SelectedChoice
        // the ISearchItem is essentially your ExampleSearchModel that implements ISearchItem
        private ObservableCollection<ISearchItem> filteredList;
        public ObservableCollection<ISearchItem> FilteredList
        {
            get
            {
                return filteredList;
            }
            set
            {
                if (filteredList != value)
                {
                    filteredList = value;
                    OnPropertyChanged("FilteredList");
                }
            }
        }

        // this is the selected AlphaList item
        private ISearchItem selectedChoice;
        public ISearchItem SelectedChoice
        {
            get { return selectedChoice; }
            set
            {
                if (selectedChoice != value)
                {
                    selectedChoice = value;
                    OnPropertyChanged("SelectedChoice");
                    this.OnSelectedChoiceChanged(value);
                }
            }
        }

        // this is the selected FliteredList item
        private ISearchItem selectedItem;
        public ISearchItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        public AlphaPageViewModel() : base()
        {
            this.Source = new List<ExampleSearchModel>();
            for (int n = 0; n < 100; n++)
            {
                this.Source.Add(new ExampleSearchModel());
            }
            this.FilteredList = new ObservableCollection<ISearchItem>();
            this.AlphaList = new ObservableCollection<ISearchItem>();
        }

        // Here you do whatever is needed to create a list of FilteredList items that is 
        // passed to the control for display
        private void OnSelectedChoiceChanged(ISearchItem item)
        {
            if (item == null)
                return;

            this.FilteredList.Clear();
            foreach(var model in this.Source.Where(n => n.ID.StartsWith(item.Name)))
            {
                // note that we are just attaching the ExampeSearchModel object to the SearcItem
                this.FilteredList.Add(new SearchItem(model.ID, model.ID, model));
            }
        }
    }
}
