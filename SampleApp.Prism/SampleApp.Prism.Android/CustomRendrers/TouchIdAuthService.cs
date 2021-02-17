using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SampleApp.Prism.CustomControls;

namespace SampleApp.Prism.Droid.CustomRendrers
{
    public class TouchIdAuthService : IBiometricPieAuthenticate
    {
        public bool CheckSDKGreater29()
        {
            throw new NotImplementedException();
        }

        public void RegisterOrAuthenticate()
        {
            throw new NotImplementedException();
        }
    }
}