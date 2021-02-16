using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using SampleApp.Prism.CustomControls;
using SampleApp.Prism.iOS.Helpers;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(AuthService))]
namespace SampleApp.Prism.iOS.Helpers
{
    public class AuthService : IAuthService
    {
        public Task<bool> AuthenticateUserIDWithTouchID()
        {
            throw new NotImplementedException();
        }

        public bool fingerprintEnabled()
        {
            throw new NotImplementedException();
        }

        public string GetAuthenticationType()
        {
            throw new NotImplementedException();
        }
    }
}