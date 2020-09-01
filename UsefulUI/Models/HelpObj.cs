using UsefulUI.ViewModels;

namespace ESIStagingApp.Models
{
    public class HelpObj : BaseViewModel
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public HelpObj(string helpline)
        {
            if (string.IsNullOrEmpty(helpline))
                return;

            string[] sa = helpline.Split(':');
            this.Name = sa[0];
            this.Description = sa[1];
        }
    }
}
