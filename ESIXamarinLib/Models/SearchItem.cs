namespace ESIXamarinLib.Models
{
    public class SearchItem: BaseViewModel, ISearchItem
    {

        private string id;
        public string ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

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

        private object item;
        public object Item
        {
            get { return item; }
            set
            {
                if (item != value)
                {
                    item = value;
                    OnPropertyChanged("Item");
                }
            }
        }


        private bool canEdit;
        public bool CanEdit
        {
            get { return canEdit; }
            set
            {
                if (canEdit != value)
                {
                    canEdit = value;
                    OnPropertyChanged("CanEdit");
                }
            }
        }

        public SearchItem(string id, string displayName, object dataModel)
        {
            this.ID = id;
            this.Name = displayName;
            this.Item = dataModel;
            this.CanEdit = true;
        }
    }
}
