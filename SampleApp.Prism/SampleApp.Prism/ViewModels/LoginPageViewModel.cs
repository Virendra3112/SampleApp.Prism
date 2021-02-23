using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using Prism.Unity;
using SampleApp.Prism.CustomControls;
using SampleApp.Prism.Helpers;
using SampleApp.Prism.Models.Enum;
using SampleApp.Prism.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged();
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand LoginCommand { get; set; }

        //INavigationService _navigationService;
        public LoginPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
            : base(navigationService, dialogService, pageDialogService)
        {
            LoginCommand = new Command(LoginClicked);
            // _navigationService = navigationService;
        }



        private async void LoginClicked(object obj)
        {
            try
            {
                AppSettings.IsLoggedIn = true;

                var result = await _pageDialogService.DisplayAlertAsync("Security Alert", "Do you want to enable fingerprint/faceId ?", "YES", "NO");

                if (result)
                {

                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        var _authType = DependencyService.Get<IAuthService>().GetAuthenticationType();
                        if (!_authType.Equals("None"))
                        {
                            if (_authType.Equals(AuthType.TouchId) || _authType.Equals(AuthType.FaceId))
                            {
                               await GetAuthResults(_authType);
                            }
                        }
                    }

                    if (Device.RuntimePlatform == Device.Android)
                    {
                        //todo

                        if (DependencyService.Get<IBiometricPieAuthenticate>().CheckSDKGreater29())
                        {
                            var res = DependencyService.Get<IAuthService>().fingerprintEnabled();

                            if (res)
                            {
                                //subscribe for biometricpromt response from Android
                                MessagingCenter.Subscribe<object>("BiometricPrompt", "Success", (sender) =>
                                {
                                    MessagingCenter.Unsubscribe<object>("BiometricPrompt", "Success");
                                    
                                });
                                MessagingCenter.Subscribe<object>("BiometricPrompt", "Fail", (sender) =>
                                {
                                    MessagingCenter.Unsubscribe<object>("BiometricPrompt", "Fail");
                                    
                                });

                                //call biomtricprompt dependency service
                                DependencyService.Get<IBiometricPieAuthenticate>().RegisterOrAuthenticate();
                            }

                            else
                            {
                                //todo
                            }

                        }
                    }


                    //show fingerprint page here 
                    AppSettings.IsFingerprintSet = true;
                }
                else
                {
                    AppSettings.IsFingerprintSet = false;
                }


                await _navigationService.NavigateAsync(nameof(MainDeatilsPage) + "/" + nameof(NavigationPage) + "/" + nameof(FirstDetailsPage));

            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Error", "Something went wrong" + ex.Message, "Ok");
            }
        }

        private async Task GetAuthResults(string authType)
        {
            var result = await DependencyService.Get<IAuthService>().AuthenticateUserIDWithTouchID();
            if (result)
            {
                if (authType.Equals("TouchId"))
                {

                }
                else if (authType.Equals("FaceId"))
                {

                }
            }
            else
            {

            }
        }
    }
}