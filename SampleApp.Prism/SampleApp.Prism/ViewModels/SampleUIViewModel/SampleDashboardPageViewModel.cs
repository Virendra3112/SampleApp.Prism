﻿using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using SampleApp.Prism.Models.Enum;
using SampleApp.Prism.Views.SampleUIPages;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels.SampleUIViewModel
{
    public class SampleDashboardPageViewModel : BaseViewModel
    {
        public ICommand SelectCommand { get; set; }

        public SampleDashboardPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {
            SelectCommand = new Command<string>(OnTileClicked);
        }

        private async void OnTileClicked(string obj)
        {
            try
            {
                switch (obj)
                {
                    case "Check-In":
                        var navParameters = new NavigationParameters
                            {
                                { "TileName", nameof(Tiles.CheckIn) }
                            };
                        await _navigationService.NavigateAsync(nameof(SampleCheckinOutTypePage), navParameters);

                        break;

                    case "Check-Out":
                        await _navigationService.NavigateAsync(nameof(SampleCheckinOutTypePage));

                        break;

                    case nameof(Tiles.Logs):

                        break;

                    case nameof(Tiles.Supervision):

                        break;


                }

            }
            catch (Exception)
            {

            }

        }
    }
}
