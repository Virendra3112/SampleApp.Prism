using Prism;
using Prism.Ioc;
using Prism.Unity;
using SampleApp.Prism.Helpers;
using SampleApp.Prism.Models.Enum;
using SampleApp.Prism.ViewModels;
using SampleApp.Prism.Views;
using Xamarin.Forms;

namespace SampleApp.Prism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }
        public static Theme AppTheme { get; set; }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //add already loggged in check
            //NavigationService.NavigateAsync(PageConstants.LoginPageKey);
            //NavigationService.NavigateAsync(nameof(MainDeatilsPage) + "/" + nameof(NavigationPage) + "/" + nameof(FirstDetailsPage));


            if (AppSettings.IsLoggedIn)
            {
                NavigationService.NavigateAsync(nameof(MainDeatilsPage) + "/" + nameof(NavigationPage) + "/" + nameof(HomePage));

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
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        }
    }
}
