using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UsefulUI.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        private string info;
        public string Info
        {
            get { return info; }
            set
            {
                if (info != value)
                {
                    info = value;
                    OnPropertyChanged("Info");
                }
            }
        }

        public AboutViewModel()
        {
            Title = "About";
            this.Info = Resource.AboutInfo;
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://Engenious.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}