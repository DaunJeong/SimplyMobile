using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SimplyMobile.Core;
using SimplyMobile.Data;
using SimplyMobile.Text.ServiceStack;
using SimplyMobile.IoC;
using SQLite.Net.Interop;

using SQLite.Net.Platform.XamarinIOS;
using SQLiteBlobTests;

namespace DeviceTests
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
    [Register("DeviceApp")]
	public partial class DeviceApp
	{
	    /// <summary>
	    /// The window.
	    /// </summary>
	    UIWindow window;

	    /// <summary>
	    /// The controller.
	    /// </summary>
	    private MainViewController controller;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			this.window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// If you have defined a root view controller, set it here:
            this.controller = new MainViewController();

            this.window.RootViewController = this.controller;
			
			// make the window visible
            this.window.MakeKeyAndVisible();

            DependencyResolver.Current.RegisterService<ISQLitePlatform, SQLitePlatformIOS>();
            this.OnStart();

            DependencyResolver.Current.GetService<StoreAccelerometerData>().Start();
			return true;
		}

        public override void WillTerminate(UIApplication application)
        {
            DependencyResolver.Current.GetService<StoreAccelerometerData>().Stop();
            base.WillTerminate(application);
        }
	}
}

