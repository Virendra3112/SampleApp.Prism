using System;

using Foundation;
using LocalAuthentication;
using SampleApp.Prism.Models.Enum;
using UIKit;

namespace SampleApp.Prism.iOS.Helpers
{
    public static class iOSAuthHelper
    {
        public static string GetLocalAuthLabelText()
        {
            var localAuthType = GetLocalAuthType();

            switch (localAuthType)
            {
                case AuthType.Passcode:
                    return "Passcode required";// Strings.RequirePasscode;
                case AuthType.TouchId:
                    return "Required Touch Id";// Strings.RequireTouchID;
                case AuthType.FaceId:
                    return "Faceid required";// Strings.RequireFaceID;
                default:
                    return string.Empty;
            }
        }

        public static string GetLocalAuthIcon()
        {
            var localAuthType = GetLocalAuthType();

            switch (localAuthType)
            {
                //case AuthType.Passcode:
                //    return SvgLibrary.LockIcon;
                //case AuthType.TouchId:
                //    return SvgLibrary.TouchIdIcon;
                //case AuthType.FaceId:
                //    return SvgLibrary.FaceIdIcon;
                default:
                    return string.Empty;
            }
        }

        public static string GetLocalAuthUnlockText()
        {
            var localAuthType = GetLocalAuthType();

            switch (localAuthType)
            {
                case AuthType.Passcode:
                    return AuthType.Passcode.ToString();//Strings.UnlockWithPasscode;
                case AuthType.TouchId:
                    return AuthType.TouchId.ToString();//Strings.UnlockWithTouchID;
                case AuthType.FaceId:
                    return AuthType.FaceId.ToString();//Strings.UnlockWithFaceID;
                default:
                    return string.Empty;
            }
        }

        public static bool IsLocalAuthAvailable => GetLocalAuthType() != AuthType.None;

        public static void Authenticate(Action onSuccess, Action onFailure)
        {
            var context = new LAContext();
            NSError AuthError;

            if (context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out AuthError)
                || context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, out AuthError))
            {
                var replyHandler = new LAContextReplyHandler((success, error) =>
                {
                    if (success)
                    {
                        onSuccess?.Invoke();
                    }
                    else
                    {
                        onFailure?.Invoke();
                    }
                });

                context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, "Please Authenticate To Proceed", replyHandler);
            }
        }

        private static AuthType GetLocalAuthType()
        {
            var localAuthContext = new LAContext();
            NSError AuthError;

            if (localAuthContext.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, out AuthError))
            {
                if (localAuthContext.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out AuthError))
                {
                    if (GetOsMajorVersion() >= 11 && localAuthContext.BiometryType == LABiometryType.FaceId)
                    {
                        return AuthType.FaceId;
                    }

                    return AuthType.TouchId;
                }

                return AuthType.Passcode;
            }

            return AuthType.None;
        }

        private static int GetOsMajorVersion()
        {
            return int.Parse(UIDevice.CurrentDevice.SystemVersion.Split('.')[0]);
        }
    }
}