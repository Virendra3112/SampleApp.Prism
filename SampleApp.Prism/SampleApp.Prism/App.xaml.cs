using Prism;
using Prism.Ioc;
using Prism.Navigation.Xaml;
using Prism.Unity;
using SampleApp.Prism.Helpers;
using SampleApp.Prism.ViewModels;
using SampleApp.Prism.Views;
using System;
using Xamarin.Forms;

namespace SampleApp.Prism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //add already loggged in check
            NavigationService.NavigateAsync(PageConstants.LoginPageKey);


            if (AppSettings.IsLoggedIn)
            {
                //NavigationService.NavigateAsync(new System.Uri("/NavigationPage/HomeTab?selectedTab=UserDeatilsTab", UriKind.Absolute));

            }
            else
            {
                NavigationService.NavigateAsync(PageConstants.LoginPageKey);
            }

        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<MainDeatilsPage, MainDeatilsPageViewModel>();
            containerRegistry.RegisterForNavigation<MainDeatilsPage, MainDeatilsPageViewModel>();
            containerRegistry.RegisterForNavigation<FirstDetailsPage, FirstDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondDetailsPage, SecondDetailsPageViewModel>();
        }
    }
}
