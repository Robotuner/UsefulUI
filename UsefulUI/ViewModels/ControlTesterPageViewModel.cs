namespace UsefulUI.ViewModels
{
    public class ControlTesterPageViewModel : BaseViewModel
    {

        private string selectAllText;
        public string SelectAllText
        {
            get { return selectAllText; }
            set
            {
                if (selectAllText != value)
                {
                    selectAllText = value;
                    OnPropertyChanged("SelectAllText");
                }
            }
        }

        public ControlTesterPageViewModel()
        {
            this.SelectAllText = "This should be selected on focus";
        }  
    }
}
