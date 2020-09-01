using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulUI.ViewModels
{
    public class EntryPageViewModel : HelpPageViewModel
    {

        private string selectedEntry;
        public string SelectedEntry
        {
            get { return selectedEntry; }
            set
            {
                if (selectedEntry != value)
                {
                    selectedEntry = value;
                    OnPropertyChanged("SelectedEntry");
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

        public EntryPageViewModel()
        {
            this.SetHelp(Resource.EntryHelp);
        }
    }
}
