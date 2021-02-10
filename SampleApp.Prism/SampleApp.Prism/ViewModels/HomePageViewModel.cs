﻿using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using SampleApp.Prism.Models;
using SampleApp.Prism.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private ObservableCollection<MyMenuItem> _categoryList;

        public ObservableCollection<MyMenuItem> CategoryList
        {
            get { return _categoryList; }
            set { _categoryList = value; RaisePropertyChanged(); }
        }
        public ICommand MenuItemCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
              : base(navigationService, dialogService, pageDialogService)
        {
            MenuItemCommand = new Command(MenuSelected);

            CategoryList = new ObservableCollection<MyMenuItem>();


            CategoryList.Add(new MyMenuItem { PageName = "Carousel View", Icon = "icon.png" });
            CategoryList.Add(new MyMenuItem { PageName = "SVG Scale", Icon = "icon.png" });
        }

        private async void MenuSelected(object obj)
        {
            if (obj != null)
            {
                var item = obj as MyMenuItem;

                switch (item.PageName)
                {
                    case ("Carousel View"):
                        await _navigationService.NavigateAsync(nameof(CarouselViewPage));
                        break;

                    case ("SVG Scale"):
                        await _navigationService.NavigateAsync(nameof(CustomSVGPage));
                        break;

                }

            }

        }
    }
}
