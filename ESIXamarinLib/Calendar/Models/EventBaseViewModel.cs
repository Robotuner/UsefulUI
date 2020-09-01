namespace ESIXamarinLib.Calendar.Models
{
    public class EventBaseViewModel : BaseViewModel
    {

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

    }
}
