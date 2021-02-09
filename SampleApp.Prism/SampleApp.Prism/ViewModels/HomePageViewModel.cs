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
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
              : base(navigationService, dialogService, pageDialogService)
        {
        }
    }
}
