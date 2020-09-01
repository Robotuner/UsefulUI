using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace UsefulUI.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();
            #region For Screen Height & Width
            // https://www.c-sharpcorner.com/article/absolute-dimensions-of-app-screen-xamarin-forms/#:~:text=For%20Xamarin.,of%20the%20views%20of%20Xamarin.
            App.screenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            App.screenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            #endregion
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
