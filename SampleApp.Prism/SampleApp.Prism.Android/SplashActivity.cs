
using Android.App;
using Android.OS;

namespace SampleApp.Prism.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
           MainLauncher = true
          )]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            StartActivity(typeof(MainActivity));
        }
    }
}