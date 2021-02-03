using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Prism.ViewModels
{
   public class MainDeatilsPageViewModel : BaseViewModel
    {
       // INavigationService _navigationService;
        public DelegateCommand<string> OnNavigateCommand { get; set; }

        public MainDeatilsPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
            : base(navigationService, dialogService, pageDialogService)
        {
            //_navigationService = navigationService;
            OnNavigateCommand = new DelegateCommand<string>(NavigateToPage);
        }

        private async void NavigateToPage(string obj)
        {
            try
            {
                await _navigationService.NavigateAsync(new Uri(obj, UriKind.Relative));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
