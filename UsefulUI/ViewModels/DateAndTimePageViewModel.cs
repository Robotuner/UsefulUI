using System;

namespace UsefulUI.ViewModels
{
    public class DateAndTimePageViewModel : HelpPageViewModel
    {
        private DateTime? selectedDateTime;
        public DateTime? SelectedDateTime
        {
            get { return selectedDateTime; }
            set
            {
                if (selectedDateTime != value)
                {
                    selectedDateTime = value;
                    OnPropertyChanged("SelectedDateTime");
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

        public DateAndTimePageViewModel()
        {
            this.SetHelp(Resource.DateAndTimeHelp);
        }
    }
}
