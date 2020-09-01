using System;
using System.Collections.Generic;
using System.Text;

namespace ESIXamarinLib.Controls.ViewModels
{
    public class DateAndTimePageViewModel : BaseViewModel
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

    }
}
