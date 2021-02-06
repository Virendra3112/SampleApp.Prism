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
    }
}
