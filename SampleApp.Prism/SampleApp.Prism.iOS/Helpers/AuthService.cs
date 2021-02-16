using System;
using System.Threading.Tasks;
using Foundation;
using SampleApp.Prism.CustomControls;
using SampleApp.Prism.iOS.Helpers;
using UIKit;
using LocalAuthentication;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AuthService))]
namespace SampleApp.Prism.iOS.Helpers
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {

        }


        public Task<bool> AuthenticateUserIDWithTouchID()
        {
            bool outcome = false;
            var tcs = new TaskCompletionSource<bool>();

            var context = new LAContext();
            if (context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out NSError AuthError))
            {


                var replyHandler = new LAContextReplyHandler((success, error) => {

                    Device.BeginInvokeOnMainThread(() => {
                        if (success)
                        {
                            outcome = true;
                        }
                        else
                        {
                            outcome = false;
                        }
                        tcs.SetResult(outcome);
                    });

                });
                //This will call both TouchID and FaceId 
                context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, "Login with touch ID", replyHandler);
            };
            return tcs.Task;
        }

        public bool fingerprintEnabled()
        {
            throw new NotImplementedException();
        }

        private static int GetOsMajorVersion()
        {
            return int.Parse(UIDevice.CurrentDevice.SystemVersion.Split('.')[0]);
        }

        public string GetAuthenticationType()
        {
            var localAuthContext = new LAContext();
            NSError AuthError;

            if (localAuthContext.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, out AuthError))
            {
                if (localAuthContext.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out AuthError))
                {
                    if (GetOsMajorVersion() >= 11 && localAuthContext.BiometryType == LABiometryType.FaceId)
                    {
                        return "FaceId";
                    }

                    return "TouchId";
                }

                return "PassCode";
            }

            return "None";
        }
    }
}