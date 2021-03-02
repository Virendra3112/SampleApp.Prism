using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SampleApp.Prism.Droid.Helpers;
using Android;
using Android.Util;
using Plugin.CurrentActivity;

namespace SampleApp.Prism.Droid
{
    [Activity(Label = "SampleApp.Prism", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]


    //Invite App Link
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
                  DataScheme = "https",
                  DataHost = "xamboy.com",
                  AutoVerify = true,
                  Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable })]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
                  DataScheme = "http",
                  DataHost = "xamboy.com",
                  AutoVerify = true,
                  Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable })]


    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Activity FormsContext { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            FormsContext = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            
            LoadApplication(new App(new AndroidInitializer()));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == 202)
            {
                Log.Info("Biometric", "Received response for Biometric Permission request");

                if ((grantResults.Length == 1) && (grantResults[0] == Permission.Granted))
                {
                    Log.Info("Biometric", "Biomtric permission has now been granted");

                }
                else
                {
                    Log.Info("Biometric", "Biometric permission is not granted");
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
                    {
                        string[] reruiredPermission = new string[] { Manifest.Permission.UseBiometric };
                    }
                    else
                    {
                        string[] reruiredPermission = new string[] { Manifest.Permission.UseFingerprint };
                    }
                }
            }
        }
    }
}