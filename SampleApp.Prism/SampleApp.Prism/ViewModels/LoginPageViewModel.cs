using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using Prism.Unity;
using SampleApp.Prism.Helpers;
using SampleApp.Prism.Views;
using System;
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

                //show fingerprint page here 
                AppSettings.IsFingerprintSet = true;

                await _navigationService.NavigateAsync(nameof(MainDeatilsPage) + "/" + nameof(NavigationPage) + "/" + nameof(FirstDetailsPage));

            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Error", "Something went wrong" + ex.Message, "Ok");
            }
        }
    }
}