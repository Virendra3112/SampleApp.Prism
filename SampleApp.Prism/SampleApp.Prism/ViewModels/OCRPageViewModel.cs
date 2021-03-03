using ImageReader;
using IronOcr;
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
                    IsBusy = true;
                    var dd = await DependencyService.Resolve<IOCR>()
                        .ReadImage(file.Path);

                    ImageText = dd;

                    //var Result = new IronTesseract().Read(file.Path);
                    //Console.WriteLine(Result.Text);

                    //var test = new Class1();
                    //var re = test.ReadData(file.Path);




                    //ImageText = re;
                    //var test = DependencyService.Resolve<ITesseractApi>().Init("eng");


                    //if (!_tesseract.Initialized)
                    //{
                    //    var initialised = await _tesseract.Init("eng");
                    //    if (!initialised)
                    //        return;
                    //}

                    //if (!await _tesseract.SetImage(file.Path))
                    //    return;

                    //var words = _tesseract.Results(PageIteratorLevel.Word);
                    //var symbols = _tesseract.Results(PageIteratorLevel.Symbol);
                    //var blocks = _tesseract.Results(PageIteratorLevel.Block);
                    //var paragraphs = _tesseract.Results(PageIteratorLevel.Paragraph);
                    //var lines = _tesseract.Results(PageIteratorLevel.Textline);
                }

                //await DisplayAlert("File Location", file.Path, "OK");

            }
            catch (Exception ex)
            {
                ImageText = ex.Message;
            }

            finally
            {
                IsBusy = false;
            }

        }
    }
}
