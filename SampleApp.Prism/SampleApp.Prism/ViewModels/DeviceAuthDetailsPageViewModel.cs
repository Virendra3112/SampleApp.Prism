using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using SampleApp.Prism.CustomControls;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class DeviceAuthDetailsPageViewModel : BaseViewModel
    {
        private string _authDetails;
        public string AuthDetails
        {
            get { return _authDetails; }
            set
            {
                _authDetails = value;
                RaisePropertyChanged();
            }
        }
        public DeviceAuthDetailsPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {
            GetData();
        }

        private void GetData()
        {
            try
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    var _authType = DependencyService.Get<IAuthService>().GetAuthenticationType();
                    AuthDetails = "Auth Type: " + _authType;
                }
                if (Device.RuntimePlatform == Device.Android)
                {
                    //var _authType = DependencyService.Get<IAuthService>().GetAuthenticationType();
                    AuthDetails = "Auth Type: ";

                }

            }
            catch (System.Exception ex)
            {

            }

        }
    }
}
