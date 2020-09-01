using ESIXamarinLib.FAViewer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ESIXamarinLib.FAViewer.ViewModels
{
    public class FontViewModel : BaseViewModel
    {

        private string fontName;
        public string FontName
        {
            get { return fontName; }
            set
            {
                if (fontName != value)
                {
                    fontName = value;
                    OnPropertyChanged("FontName");
                }
            }
        }

        private string fontFamily;
        public string FontFamily
        {
            get { return fontFamily; }
            set
            {
                if (fontFamily != value)
                {
                    fontFamily = value;
                    OnPropertyChanged("FontFamily");
                }
            }
        }

        private List<IconViewModel>  charList;
        public List<IconViewModel> CharList
        {
            get { return charList; }
            set
            {
                if (charList != value)
                {
                    charList = value;
                    OnPropertyChanged("CharList");
                }
            }
        }

        private ObservableCollection<IconViewModel> filteredList;
        public ObservableCollection<IconViewModel> FilteredList
        {
            get { return filteredList; }
            set
            {
                if (filteredList != value)
                {
                    filteredList = value;
                    OnPropertyChanged("FilteredList");
                }
            }
        }

        public FontViewModel(ModuleWrapper mw)
        {
            this.FilteredList = new ObservableCollection<IconViewModel>();
            this.FontName = mw.FontFamily;
            if (mw.FontFamily.Contains("Regular"))
                this.FontFamily = Device.RuntimePlatform == Device.iOS ? "FontAwesome5Free-Regular" : "FontAwesome5Solid.otf#Regular";
            if (mw.FontFamily.Contains("Solid"))
                this.FontFamily = Device.RuntimePlatform == Device.iOS ? "FontAwesome5Free-Solid" : "FontAwesome5Solid.otf#Regular";
            if (mw.FontFamily.Contains("Brands"))
                this.FontFamily = Device.RuntimePlatform == Device.iOS ? "FontAwesome5Brands-Regular" : "FontAwesome5Brands.otf#Regular";

            CharList = new List<IconViewModel>();
            foreach(var item in mw.Characters)
            {
                CharList.Add(new IconViewModel(item));
            }
        }

        public override string ToString()
        {
            return this.FontName;
        }

        public async Task RefreshFilter(string filter)
        {
            if (this.CharList == null)
                return;

            this.FilteredList.Clear();
            if (string.IsNullOrEmpty(filter))
            {
                foreach (var item in this.CharList)
                {
                    this.FilteredList.Add(item);
                }

                return;
            }

            string match = filter?.ToLower();
            foreach (var item in this.CharList.Where(n => n.Code.Contains(match) || n.Key.ToLower().Contains(match)))
            {
                this.FilteredList.Add(item);
            }
            await Task.CompletedTask;
        }
    }
}
