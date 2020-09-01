using ESIXamarinLib.Models;
using System;
using System.Collections.ObjectModel;

namespace UsefulUI.ViewModels
{
    public class MultiColumnGridViewModel : HelpPageViewModel
    {
        private ObservableCollection<ISearchItem> filterList;
        public ObservableCollection<ISearchItem> FilterList
        {
            get { return filterList; }
            set
            {
                if (filterList != value)
                {
                    filterList = value;
                    OnPropertyChanged("FilterList");
                }
            }
        }

        private int screenWidth;
        public int ScreenWidth
        {
            get { return screenWidth; }
            set
            {
                if (screenWidth != value)
                {
                    screenWidth = value;
                    OnPropertyChanged("ScreenWidth");
                }
            }
        }

        private bool simpleMode;
        public bool SimpleMode
        {
            get { return simpleMode; }
            set
            {
                if (simpleMode != value)
                {
                    simpleMode = value;
                    OnPropertyChanged("SimpleMode");
                }
            }
        }


        public MultiColumnGridViewModel()
        {    
            this.SetHelp(Resource.MultiFilterHelp);
            this.ScreenWidth = App.screenWidth;
            this.Init();
        }

        public int fcount = 0;
        public void Init()
        {
            this.FilterList = new ObservableCollection<ISearchItem>()
            {
                this.NewSearchItem("Filter 1 just add text"),
                this.NewSearchItem("Filter 2"),
                this.NewSearchItem("Filter 3 it rains in spain"),
                this.NewSearchItem("Filter 4 going to take time off - need to make this longer to see if row is larger"),
                this.NewSearchItem("Filter 5"),
                this.NewSearchItem("Filter 6 it will be hot at end of the month of august"),
                this.NewSearchItem("Filter 7"),
                this.NewSearchItem("Filter 8 testing"),
                this.NewSearchItem("Filter 9 make a mess"),
                this.NewSearchItem("Filter 10 this is unreasonable")
            };
        }

        public SearchItem NewSearchItem(string description)
        {
            fcount++;
            string key = fcount.ToString();
            return new SearchItem(key, description, null);
        }

    }
}
