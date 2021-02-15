﻿using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using SampleApp.Prism.Helpers;
using SampleApp.Prism.Models.Enum;
using SampleApp.Prism.ViewModels;
using SampleApp.Prism.Views;
using Unity;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleApp.Prism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {
        }
        public static Theme AppTheme { get; set; }

        public static double ScreenWidth;
        public static double ScreenHeight;

        protected override void OnInitialized()
        {
            //Forms.SetFlags("IndicatorView_Experimental");//todo: need to check
            InitializeComponent();

            //Todo
            //Container.GetContainer().RegisterInstance<INavigationService>(NavigationService, new Unity.Lifetime.SingletonLifetimeManager());


            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            ScreenWidth = mainDisplayInfo.Width;

            // Height (in pixels)
            ScreenHeight = mainDisplayInfo.Height;



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
            containerRegistry.RegisterForNavigation<CarouselViewPage, CarouselViewPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomSVGPage, CustomSVGPageViewModel>();
            containerRegistry.RegisterForNavigation<FirstTabPage, FirstTabPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondTabPage, SecondTabPageViewModel>();


            //todo:
            //containerRegistry.RegisterForNavigation<HomePage>();
            //containerRegistry.GetContainer().RegisterType<HomePageViewModel>(new Unity.Lifetime.ContainerControlledLifetimeManager());

        }
    }
}
