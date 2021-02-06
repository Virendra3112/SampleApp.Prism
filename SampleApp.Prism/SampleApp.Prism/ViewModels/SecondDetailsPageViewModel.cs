using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
namespace SampleApp.Prism.ViewModels
{
    public class SecondDetailsPageViewModel : BaseViewModel
    {
        public SecondDetailsPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
             : base(navigationService, dialogService, pageDialogService)
        {
        }
    }
}
