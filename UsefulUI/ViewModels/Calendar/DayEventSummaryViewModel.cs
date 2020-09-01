using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulUI.ViewModels.Calendar
{
    public class DayEventSummaryViewModel : CalendarBaseViewModel
    {
        private string icon;
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }


        private string evtName;
        public string EvtName
        {
            get { return evtName; }
            set { SetProperty(ref evtName, value); }
        }


        private string evtDescription;
        public string EvtDescription
        {
            get { return evtDescription; }
            set { SetProperty(ref evtDescription, value); }
        }

    }
}
