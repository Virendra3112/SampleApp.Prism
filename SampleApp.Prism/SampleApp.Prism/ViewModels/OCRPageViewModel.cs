using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class OCRPageViewModel : BaseViewModel
    {
        public ICommand ReadDataCommand { get; set; }

        public OCRPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {

            ReadDataCommand = new Command(onReadData);

        }

        private void onReadData(object obj)
        {
        }
    }
}
