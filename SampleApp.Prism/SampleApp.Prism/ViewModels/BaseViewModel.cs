using Acr.UserDialogs;
using Plugin.Connectivity;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp.Prism.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged 
    {

        public bool IsConnected
        {
            get { return CrossConnectivity.Current.IsConnected; }
        }

        bool isBusy;
        
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                ShowLoading(value);
                RaisePropertyChanged();
            }
        }

        private bool _isNetworkAvailable;

        public bool IsNetworkAvailable
        {
            get => _isNetworkAvailable;
            set
            {
                _isNetworkAvailable = value;
                RaisePropertyChanged();
            }
        }

        public readonly INavigationService _navigationService;
        public readonly IDialogService _dialogService;
        public readonly IPageDialogService _pageDialogService;

        public BaseViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _pageDialogService = pageDialogService;

            CheckConnectivity();
        }

        /// <summary>
        /// Called to show/ hide loader
        /// </summary>
        /// <param name="value"></param>
        private void ShowLoading(bool value)
        {
            try
            {

                if (value)
                    UserDialogs.Instance.ShowLoading();

                else
                    UserDialogs.Instance.HideLoading();
            }
            catch (Exception)
            {

            }
        }


      
        public void CheckConnectivity()
        {
            try
            {
                CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
                {
                    IsNetworkAvailable = args.IsConnected;

                    ToastConfig.DefaultPosition = ToastPosition.Top;

                    if (IsNetworkAvailable)
                    {
                        UserDialogs.Instance.Toast("Internet connected");                       
                    }

                    else
                        UserDialogs.Instance.Toast("Internet Lost");

                };
            }
            catch (Exception)
            {

            }
        }




        #region INotifyPropertyChanged implementation

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

       
        protected new void RaisePropertyChanged([CallerMemberName]  string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion
    }
}