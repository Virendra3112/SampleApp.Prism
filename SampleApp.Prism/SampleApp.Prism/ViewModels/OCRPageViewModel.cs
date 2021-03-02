using IronOcr;
using Plugin.Media;
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

        private string _imageText;

        public string ImageText
        {
            get { return _imageText; }
            set { _imageText = value; RaisePropertyChanged(); }
        }

        public OCRPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService) : base(navigationService, dialogService, pageDialogService)
        {

            ReadDataCommand = new Command(onReadData);

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
                    var Result = new IronTesseract().Read(file.Path);
                    Console.WriteLine(Result.Text);

                    ImageText = Result.Text;
                }

                //await DisplayAlert("File Location", file.Path, "OK");

            }
            catch (Exception ex)
            {
            }

        }
    }
}
