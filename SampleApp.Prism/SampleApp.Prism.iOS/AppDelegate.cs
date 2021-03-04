using FFImageLoading;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Foundation;
using SampleApp.Prism.Helpers;
using SampleApp.Prism.iOS.Helpers;
using UIKit;
using Xamarin.Forms;

namespace SampleApp.Prism.iOS
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
            Forms.SetFlags("IndicatorView_Experimental");

            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();
            var ignore = typeof(SvgCachedImage);

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,

            };

            ImageService.Instance.Initialize(config);

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }

        //public override void WillEnterForeground(UIApplication application)
        //{
        //    if (!AppSettings.IsLocalAuthEnabled)
        //    {
        //        return;
        //    }

        //    iOSAuthHelper.Authenticate(null, // do not do anything on success
        //    () =>
        //    {
        //        // show View Controller that requires authentication
        //        InvokeOnMainThread(() =>
        //                {
        //                    //var localAuthViewController = new LocalAuthViewController();
        //                    //Window.RootViewController.ShowViewController(localAuthViewController, null);
        //                });
        //    });
        //}

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            //https://xamarincodes.com/2020/04/18/deep-links-in-xamarin-forms/
            //Custom deep linking
            // < key > CFBundleURLTypes </ key >
            //< array >
            //  < dict >
            //    < key > CFBundleURLName </ key >
            //    < string > DeepLinking </ string >
            //    < key > CFBundleURLSchemes </ key >
            //    < array >
            //      < string > TestApp </ string >
            //    </ array >
            //  </ dict >
            //</ array >

            return true;
            //return base.OpenUrl(application, url, sourceApplication, annotation);
        }


    }
}
