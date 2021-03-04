using Acr.UserDialogs;
using Plugin.Media;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using SampleApp.Prism.CustomControls;
using System;
using System.Windows.Input;
using Tesseract;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class OCRPageViewModel : BaseViewModel
    {
        public ICommand ReadDataCommand { get; set; }

        private string _imageText;

        private readonly ITesseractApi _tesseract;


        public string ImageText
        {
            get { return _imageText; }
            set { _imageText = value; RaisePropertyChanged(); }
        }

        public OCRPageViewModel(INavigationService navigationService,
            IDialogService dialogService, IPageDialogService 
            pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {

            ReadDataCommand = new Command(onReadData);
            _tesseract = DependencyService.Resolve<ITesseractApi>();

        }

        private async void onReadData(object obj)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    //DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "OCR",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                else
                {
                    //IsBusy = true;
                    UserDialogs.Instance.ShowLoading("Loading");
                    var _text = await DependencyService.Resolve<IOCR>()
                        .ReadImage(file.Path);

                    ImageText = _text;
                    UserDialogs.Instance.HideLoading();

                }
            }
            catch (Exception ex)
            {
                ImageText = ex.Message;
                UserDialogs.Instance.HideLoading();
            }

            finally
            {
               // IsBusy = false;
            }
        }
    }
}
