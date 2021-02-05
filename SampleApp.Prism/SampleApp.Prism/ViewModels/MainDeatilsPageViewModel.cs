using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SampleApp.Prism.Models;
using SampleApp.Prism.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class MainDeatilsPageViewModel : BindableBase//BaseViewModel
    {
        private INavigationService _navigationService;

        public ObservableCollection<MyMenuItem> MenuItems { get; set; }

        private MyMenuItem selectedMenuItem;
        public MyMenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set => SetProperty(ref selectedMenuItem, value);
        }

        public DelegateCommand NavigateCommand { get; private set; }

        public MainDeatilsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MenuItems = new ObservableCollection<MyMenuItem>();

            MenuItems.Add(new MyMenuItem()
            {
                Icon = "icon",
                PageName = nameof(FirstDetailsPage),
                Title = "View A"
            });

            MenuItems.Add(new MyMenuItem()
            {
                Icon = "icon",
                PageName = nameof(SecondDetailsPage),
                Title = "View B"
            });

            NavigateCommand = new DelegateCommand(Navigate);
        }

        async void Navigate()
        {
            await _navigationService.NavigateAsync(nameof(NavigationPage) + "/" + SelectedMenuItem.PageName);
        }


        //// INavigationService _navigationService;
        // public DelegateCommand<string> OnNavigateCommand { get; set; }

        // public MainDeatilsPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
        //     : base(navigationService, dialogService, pageDialogService)
        // {
        //     //_navigationService = navigationService;
        //     OnNavigateCommand = new DelegateCommand<string>(NavigateToPage);
        // }

        // private async void NavigateToPage(string obj)
        // {
        //     try
        //     {
        //         await _navigationService.NavigateAsync(new Uri(obj, UriKind.Relative));
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }
        // }
    }
}
