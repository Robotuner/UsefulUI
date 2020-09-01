using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace UsefulUI.ViewModels
{
    public class LabelButtonViewModel : HelpPageViewModel
    {
        public ICommand LabelClickedCommand { get; set; }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        private string[] MiscText = new string[]
        {
            "Click me!",
            "Supports Line break mode",
            "Support background color",
            "Supports Corner radius of button",
            "Supports Width request of button.",
            "Support custom message",
            "Support FontAwesome Icon",
            "Support Icon color",
            "Must specify Icon Font Family!",
            "Support Command on Click",
            "Supports Text Color"
        };

        private int pos = 0;
        public LabelButtonViewModel()
        {
            this.SetHelp(Resource.LabelButtonHelp);
            this.Message = MiscText[pos++];
            this.LabelClickedCommand = new Command((s) =>
            {
                if (pos >= MiscText.Length) pos = 0;
                this.Message = this.MiscText[pos++];
            });
        }


    }
}
