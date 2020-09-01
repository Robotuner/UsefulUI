using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulUI.ViewModels
{
    public class PhoneEntryPageViewModel : HelpPageViewModel
    {

        private string selectedPhone;
        public string SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                if (selectedPhone != value)
                {
                    selectedPhone = value;
                    OnPropertyChanged("SelectedPhone");
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

        public string FormatPhoneNumber(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                return null;

            int len = val.Length;
            if (len == 10)
            {
                string areaCode = val.Substring(0, 3);
                string prefix = val.Substring(3, 3);
                string tail = val.Substring(6, 4);
                return string.Format("({0}) {1}-{2}", areaCode, prefix, tail);
            }
            if (len > 10)
            {
                int ccode = len - 10;
                string countryCode = val.Substring(0, ccode);
                string areaCode = val.Substring(ccode, 3);
                string prefix = val.Substring(ccode + 3, 3);
                string tail = val.Substring(ccode + 6, 4);
                return string.Format("{3} - ({0}) {1}-{2}", areaCode, prefix, tail, countryCode);
            }
            return val;
        }

        public PhoneEntryPageViewModel()
        {
            this.SetHelp(Resource.PhoneEntryHelp);
        }
    }
}
