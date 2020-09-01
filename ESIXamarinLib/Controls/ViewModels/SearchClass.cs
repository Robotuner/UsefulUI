namespace ESIXamarinLib.Controls.ViewModels
{
    public class SearchClass<T> : BaseViewModel
    {
        public string DisplayField { get; set; }
        public string DisplayContent { get; set; }
        public T SearchObject { get; set; }
        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        public SearchClass(string propertyName, T item)
        {
            this.DisplayField = propertyName;
            this.SearchObject = item;
        }
        public SearchClass(string propertyName, bool isSelected, T item) : 
            this(propertyName, item)
        {
            this.IsSelected = isSelected;
        }
        public SearchClass(string propertyName, string descriptionPropertyName, T item) : 
            this(propertyName, item)
        {
            this.DisplayContent = descriptionPropertyName;
        }
        public SearchClass(string propertyName, string descriptionPropertyName, bool isSelected, T item) : 
            this(propertyName, descriptionPropertyName, item)
        {
            this.IsSelected = isSelected;
        }

    }
}
