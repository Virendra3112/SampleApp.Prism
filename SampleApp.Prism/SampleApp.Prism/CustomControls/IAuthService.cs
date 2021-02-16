using System;
using System.Threading.Tasks;

namespace SampleApp.Prism.CustomControls
{
    public interface IAuthService
    {
        String GetAuthenticationType();
        Task<bool> AuthenticateUserIDWithTouchID();
        bool fingerprintEnabled();
    }
}
