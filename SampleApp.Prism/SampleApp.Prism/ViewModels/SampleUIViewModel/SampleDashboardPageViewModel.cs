using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;

namespace SampleApp.Prism.ViewModels.SampleUIViewModel
{
    public class SampleDashboardPageViewModel : BaseViewModel
    {
        public SampleDashboardPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {
        }
    }
}
