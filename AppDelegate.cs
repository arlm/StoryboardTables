//using System;
//using System.Collections.Generic;
using System.Linq;
using System; 
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace StoryboardTables
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
      protected string deviceToken = string.Empty;

      public string DeviceToken { get { return deviceToken; } }

		public override UIWindow Window {
			get;
			set;
		}
     

		//
		// This method is invoked when the application is about to move from active to inactive state.
		//
		// OpenGL applications should use this method to pause.
		//
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed. 
		public override void WillTerminate (UIApplication application)
		{
		}


      public override bool FinishedLaunching(UIApplication app, NSDictionary options)
      {
         //Checking Notoification

         if(options!= null)
         {
            if(options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
            {
               UILocalNotification localNotification = options[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
               if(localNotification!= null)
               {
                  new UIAlertView(localNotification.AlertAction, localNotification.AlertBody, null, "OK", null).Show();
                  UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;

               }
            }
               if(options.ContainsKey(UIApplication.LaunchOptionsRemoteNotificationKey)) {

               NSDictionary remoteNotification = options[UIApplication.LaunchOptionsRemoteNotificationKey] as NSDictionary;
               if(remoteNotification != null) {
   

                  //               new UIAlertView(  remoteNotification.AlertAction, remoteNotification.AlertBody, null, "OK", null).Show();
              
                }
            }

         }

         UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge;
         // register for remote notifications
         UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);



         //Register for remote notifications
         UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(UIRemoteNotificationType.Alert
            | UIRemoteNotificationType.Badge
            | UIRemoteNotificationType.Sound);
         return true;



      }

      public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
      {
         var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

         //There's probably a better way to do this
         var strFormat = new NSString("%@");
         var dt = new NSString(MonoTouch.ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr(new MonoTouch.ObjCRuntime.Class("NSString").Handle, new MonoTouch.ObjCRuntime.Selector("stringWithFormat:").Handle, strFormat.Handle, deviceToken.Handle));
         var newDeviceToken = dt.ToString().Replace("<", "").Replace(">", "").Replace(" ", "");

         if (string.IsNullOrEmpty(oldDeviceToken) || !deviceToken.Equals(newDeviceToken))
         {
            //TODO: Put your own logic here to notify your server that the device token has changed/been created!
         }

         //Save device token now
         NSUserDefaults.StandardUserDefaults.SetString(newDeviceToken, "PushDeviceToken");

         Console.WriteLine("Device Token: " + newDeviceToken);
      }

      public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
      {
         if (application.ApplicationState == UIApplicationState.Active)
            Console.Write("yakalandı");

      }
      public override void ReceivedLocalNotification (UIApplication application, UILocalNotification notification)
      {
         deviceToken = deviceToken.ToString ();

      }

      public override void FailedToRegisterForRemoteNotifications (UIApplication application, NSError error)
      {
         Console.WriteLine("Failed to register for notifications");
      }

      public override void ReceivedRemoteNotification (UIApplication application, NSDictionary userInfo)
      {


          


      }


   }
}




// Takvim Sistemi Başlat

//// //HalukYILMAZ IDB Genel Müdürlüğü İçin Hazırlamıştır
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
//
//using MonoTouch.Dialog;
//
//namespace takvimProjesi
//{
//   // The UIApplicationDelegate for the application. This class is responsible for launching the
//   // User Interface of the application, as well as listening (and optionally responding) to
//   // application events from iOS.
//   [Register("AppDelegate")]
//   public partial class AppDelegate : UIApplicationDelegate
//   {
//      // class-level declarations
//      UIWindow window;
//      EntryElement login,password;
//      UIViewController homeCTRL;
//      UINavigationController navController;
//
//
//      //
//      // This method is invoked when the application has loaded and is ready to run. In this
//      // method you should instantiate the window, load the UI into it and then make the window
//      // visible.
//      //
//      // You have 17 seconds to return from this method, or iOS will terminate your application.
//      //
//      public override bool FinishedLaunching(UIApplication app, NSDictionary options)
//      {
//         // create a new window instance based on the screen size
//         window = new UIWindow(UIScreen.MainScreen.Bounds);
//
//         // If you have defined a root view controller, set it here:
//         // window.RootViewController = myViewController;
//
//         // make the window visible
//         window.MakeKeyAndVisible();
//
//         navController = new UINavigationController();
//         window.RootViewController = navController;
//         homeCTRL = new Home();  
//         navController.PushViewController(homeCTRL, true);
//
//
//
//
//         window.RootViewController = new DialogViewController(new RootElement("login")
//         {
//            new Section("Credentials")
//               {  (login= new EntryElement("Login", "Giriş'i gerçekleştirin","")),
//                  (password =   new EntryElement("Password","","",true))
//                },
//               new Section()
//               {
//                  new StringElement("Login", () => 
//                     {
//
//                        string x = login.ToString();
//                        Console.Write(x);})
//
//                  }
//
//
//             
//         });
//         return true;
//      }
//   }
//}
//
//
