using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using SampleApp.Prism.Models;
using SampleApp.Prism.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class MainDeatilsPageViewModel : BaseViewModel
    {
        public ObservableCollection<MyMenuItem> MenuItems { get; set; }

        private MyMenuItem selectedMenuItem;
        public MyMenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }


        private bool setDarkMode;
        public bool SetDarkMode
        {
            get => setDarkMode;
            set => SetProperty(ref setDarkMode, value);

            // SetTheme(setDarkMode);

        }
        public DelegateCommand NavigateCommand { get; private set; }

        //public MainDeatilsPageViewModel(INavigationService navigationService)
        //{
        //    _navigationService = navigationService;

        //    MenuItems = new ObservableCollection<MyMenuItem>();

        //    MenuItems.Add(new MyMenuItem()
        //    {
        //        Icon = "icon",
        //        PageName = nameof(FirstDetailsPage),
        //        Title = "First Details Page"
        //    });

        //    MenuItems.Add(new MyMenuItem()
        //    {
        //        Icon = "icon",
        //        PageName = nameof(SecondDetailsPage),
        //        Title = "Second Details Page"
        //    });

        //    NavigateCommand = new DelegateCommand(Navigate);
        //}

        public MainDeatilsPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
            : base(navigationService, dialogService, pageDialogService)
        {

            MenuItems = new ObservableCollection<MyMenuItem>();

            MenuItems.Add(new MyMenuItem()
            {
                Icon = "icon",
                PageName = nameof(FirstDetailsPage),
                Title = "First Details Page"
            });

            MenuItems.Add(new MyMenuItem()
            {
                Icon = "icon",
                PageName = nameof(SecondDetailsPage),
                Title = "Second Details Page"
            });

            NavigateCommand = new DelegateCommand(Navigate);

        }

        async void Navigate()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);
        }

        public void SetTheme(bool status)
        {
            //Theme themeRequested;
            //if (status)
            //{
            //    var backColor = (Color)Application.Current.Resources["DrawerPrimaryColor"];


            //    themeRequested = Theme.Dark;
            //}
            //else
            //{
            //    var backColor = (Color)Application.Current.Resources["DrawerPrimaryColor"];


            //    themeRequested = Theme.Light;
            //}

            //DependencyService.Get<IAppTheme>().SetAppTheme(themeRequested);
        }
    }
}
