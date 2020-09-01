using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulUI.ViewModels
{
    public class EditorPageViewModel : HelpPageViewModel
    {

        private string selectedText;
        public string SelectedText
        {
            get { return selectedText; }
            set
            {
                if (selectedText != value)
                {
                    selectedText = value;
                    OnPropertyChanged("SelectedText");
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

        public EditorPageViewModel()
        {
            this.SetHelp(Resource.EditorHelp);
        }
    }
}
