using ESIXamarinLib.FAViewer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ESIXamarinLib.FAViewer.ViewModels
{
    public class FAViewerViewModel : BaseViewModel
    {
        //private int batchSize = 20;
        //private int currentLoadIndex = 0;

        private List<FontViewModel> fontList;
        public List<FontViewModel> FontList
        {
            get { return fontList; }
            set
            {
                if (fontList != value)
                {
                    fontList = value;
                    OnPropertyChanged("FontList");
                }
            }
        }

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

        private FontViewModel selectedFont;
        public FontViewModel SelectedFont
        {
            get { return selectedFont; }
            set
            {
                if (selectedFont != value)
                {
                    selectedFont = value;
                    OnPropertyChanged("SelectedFont");
                    this.RefreshFilter(this.Filter);
                }
            }
        }

        //private ObservableCollection<FontViewModel> dataToDisplay;
        //public ObservableCollection<FontViewModel> DataToDisplay
        //{
        //    get { return dataToDisplay; }
        //    set
        //    {
        //        if (dataToDisplay != value)
        //        {
        //            dataToDisplay = value;
        //            OnPropertyChanged("DataToDisplay");
        //        }
        //    }
        //}

        public FAViewerViewModel()
        {
            this.FontList = new List<FontViewModel>();
            this.Init();
        }

        public void Init()
        {
            try
            {
                this.IsBusy = true;
                if (this.FontList.Count == 0)
                {
                    for (int i = 0; i < Math.Min(Plugin.Iconize.Iconize.Modules.Count, 4); i++)
                    {
                        var module = Plugin.Iconize.Iconize.Modules[i];
                        var bc = new ModuleWrapper(module);
                        this.FontList.Add(new FontViewModel(bc));
                    }
                }
            }
            finally
            {
                this.IsBusy = false;
            }
        }
        public async Task RefreshFilter(string filter)
        {
            try
            {
                this.IsBusy = true;
                if (this.SelectedFont == null)
                    return;

                await this.SelectedFont.RefreshFilter(filter);
            }
            finally
            {
                this.IsBusy = false;
            }
               
        }

        //private void Loadmore()
        //{
        //    DataToDisplay.AddRange(FontList.Skip(batchSize * currentLoadIndex).Take(batchSize));
        //}
    }
}
