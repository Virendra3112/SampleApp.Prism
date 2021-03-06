using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using SampleApp.Prism.Views.SampleUIPages;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels.SampleUIViewModel
{
    public class SampleLoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }

        public SampleLoginPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {
            LoginCommand = new Command(LoginClicked);

        }

        private async void LoginClicked(object obj)
        {
           await _navigationService.NavigateAsync(nameof(SampleDashboardPage));

        }
    }
}
