using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;

namespace SampleApp.Prism.ViewModels
{
    public class PanPinchSamplePageViewModel : BaseViewModel
    {
        public PanPinchSamplePageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {
        }
    }
}
