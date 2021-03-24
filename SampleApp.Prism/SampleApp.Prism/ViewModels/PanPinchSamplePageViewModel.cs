using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;

namespace SampleApp.Prism.ViewModels
{
    public class PanPinchSamplePageViewModel : BaseViewModel
    {
        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                RaisePropertyChanged();
            }
        }
        public PanPinchSamplePageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {
            ImageUrl = "https://cdn.shopify.com/s/files/1/0496/1029/files/Freesample.svg";
        }

    }
}
