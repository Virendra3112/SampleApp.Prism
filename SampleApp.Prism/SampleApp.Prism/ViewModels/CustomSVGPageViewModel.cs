using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;

namespace SampleApp.Prism.ViewModels
{
    public class CustomSVGPageViewModel : BaseViewModel
    {
        private string _svgUrl;
        public string SvgUrl
        {
            get { return _svgUrl; }
            set
            {
                _svgUrl = value;
                RaisePropertyChanged();
            }
        }
        public CustomSVGPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
            : base(navigationService, dialogService, pageDialogService)
        {
            SvgUrl = "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/410.svg";
        }
    }
}
