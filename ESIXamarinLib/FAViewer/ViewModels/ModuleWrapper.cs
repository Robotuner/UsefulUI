namespace ESIXamarinLib.FAViewer.Models
{
    using Plugin.Iconize;
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using Xamarin.Forms;

    /// <summary>
    /// https://github.com/jsmarcus/Iconize/tree/master/samples/Iconize.Sample
    /// </summary>
    public class ModuleWrapper : BaseViewModel
    {
        #region Commands

        //private Command _modalTestCommand;
        //public ICommand ModalTestCommand => _modalTestCommand ?? (_modalTestCommand = new Command(ExecuteModalTest));

        private Command _visibleTestCommand;
        public ICommand VisibleTestCommand => _visibleTestCommand ?? (_visibleTestCommand = new Command(ExecuteVisibleTest));

        #endregion Commands

        #region Members

        private IIconModule _module;

        #endregion Members

        #region Properties

        public ICollection<IIcon> Characters => _module.Characters;

        public String FontFamily => _module.FontFamily;

        private Boolean _visibleTest;
        public Boolean VisibleTest
        {
            get
            {
                return _visibleTest;
            }
            set
            {
                _visibleTest = value;
                OnPropertyChanged("VisibleTest");
            }
        }

        #endregion Properties

        public ModuleWrapper(IIconModule module)
        {
            _module = module;
        }

        //public void ExecuteModalTest()
        //{
        //    Application.Current.MainPage.Navigation.PushModalAsync(new IconNavigationPage(new Page1 { BindingContext = this }));
        //}

        public void ExecuteVisibleTest()
        {
            VisibleTest = !VisibleTest;
        }
    }
}
