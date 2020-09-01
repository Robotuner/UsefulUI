using ESIStagingApp.Models;
using System.Collections.ObjectModel;

namespace UsefulUI.ViewModels
{
    public class HelpPageViewModel : BaseViewModel
    {
        private ObservableCollection<HelpObj> helpList;
        public ObservableCollection<HelpObj> HelpList
        {
            get { return helpList; }
            set
            {
                if (helpList != value)
                {
                    helpList = value;
                    OnPropertyChanged("HelpList");
                }
            }
        }

        public HelpPageViewModel() : base()
        {

        }

        public void SetHelp(string help)
        {
            this.HelpList = new ObservableCollection<HelpObj>();

            if (string.IsNullOrEmpty(help))
                return;
   
            foreach (string helpItem in help.Split('\n'))
            {
                this.HelpList.Add(new HelpObj(helpItem));
            }
        }
    }
}
