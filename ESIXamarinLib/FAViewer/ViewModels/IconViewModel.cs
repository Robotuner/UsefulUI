using Plugin.Iconize;

namespace ESIXamarinLib.FAViewer.ViewModels
{
    public class IconViewModel : BaseViewModel
    {

        private char character;
        public char Character
        {
            get { return character; }
            set
            {
                if (character != value)
                {
                    character = value;
                    OnPropertyChanged("Character");
                }
            }
        }

        private string code;
        public string Code
        {
            get { return code; }
            set
            {
                if (code != value)
                {
                    code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        private string key;
        public string Key
        {
            get { return key; }
            set
            {
                if (key != value)
                {
                    key = value;
                    OnPropertyChanged("Key");
                }
            }
        }

        public IconViewModel(IIcon item)
        {
            this.Character = item.Character;
            this.Key = item.Key;
            string result = System.Convert.ToInt32(item.Character).ToString("x");
            this.Code = string.Format(@"\u{0}", result);            
        }
    }
}
