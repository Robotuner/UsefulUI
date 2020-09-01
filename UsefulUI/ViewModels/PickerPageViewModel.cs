using System.Collections.ObjectModel;

namespace UsefulUI.ViewModels
{
    public class PickerPageViewModel : HelpPageViewModel
    {
        private ObservableCollection<string> source;
        public ObservableCollection<string>  Source
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
        public PickerPageViewModel()
        {
            this.EditMode = false;
            this.Source = new ObservableCollection<string>()
            {
                "Tom Smith", "John Adams", "Sam Shepard", "George Harrison", "Martin Selig", "Jason Bourne", "Tom Cruise", "Jane Doe", "Margret Thacher", "Amy Adams", "Keira Nitely"
            };
            this.SetHelp(Resource.PickerHelp);
        }

    }
}
