using System;
using System.Threading.Tasks;
using SampleApp.Prism.CustomControls;
using SampleApp.Prism.Droid.CustomRendrers;

[assembly: Xamarin.Forms.Dependency(typeof(AuthService))]
namespace SampleApp.Prism.Droid.CustomRendrers
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