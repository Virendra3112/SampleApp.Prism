using Prism;
using Prism.Ioc;
using Prism.Unity;
using SampleApp.Prism.Helpers;

namespace SampleApp.Prism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
           // NavigationService.NavigateAsync(PageConstants.MY_PAGE);


        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            //containerRegistry.RegisterForNavigation<MyPage, MyPageViewModel>();
        }
    }
}
