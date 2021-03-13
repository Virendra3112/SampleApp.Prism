using Acr.UserDialogs;
using Plugin.Connectivity;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp.Prism.ViewModels
{
    public class BaseViewModel : BindableBase, INotifyPropertyChanged, IActiveAware, INavigationAware
    {
        private string _height;
        public string Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged();
            }
        }
        private string _width;
        public string Width
        {
            get { return _width; }
            set
            {
                _width = value;
                RaisePropertyChanged();
            }
        }
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
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value, RaiseIsActiveChanged);
            }
            //set
            //{
            //    _isActive = value;
            //    RaisePropertyChanged();
            //}
        }


        private IEnumerator<KeyValuePair<string, object>> _onNavigatedFromParameter;
        public IEnumerator<KeyValuePair<string, object>> OnNavigatedFromParameter
        {
            get { return _onNavigatedFromParameter; }
            set
            {
                _onNavigatedFromParameter = value;
                RaisePropertyChanged();
            }
        }

        private IEnumerator<KeyValuePair<string, object>> _onNavigatedToParameter;
        public IEnumerator<KeyValuePair<string, object>> OnNavigatedToParameter
        {
            get { return _onNavigatedToParameter; }
            set
            {
                _onNavigatedToParameter = value;
                RaisePropertyChanged();
            }
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
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

            UserName = "Jack Sparrow";
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
        public event EventHandler IsActiveChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword


        protected new void RaisePropertyChanged([CallerMemberName]  string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion


        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Count > 0)
            {
                OnNavigatedToParameter = parameters.GetEnumerator();
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            if(parameters.Count > 0)
            {
                OnNavigatedFromParameter = parameters.GetEnumerator();
            }

        }
    }
}