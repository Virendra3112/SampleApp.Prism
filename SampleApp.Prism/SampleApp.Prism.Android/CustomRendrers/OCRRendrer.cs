using SampleApp.Prism.CustomControls;
using SampleApp.Prism.Droid.CustomRendrers;
using System;
using System.Threading.Tasks;
using Tesseract.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(OCRRendrer))]
namespace SampleApp.Prism.Droid.CustomRendrers
{
    public class OCRRendrer : IOCR
    {
        public async Task<string> ReadImage(string path)
        {
            string text = null;

            try
            {

                var context = Android.App.Application.Context;
                var api = new TesseractApi(context, AssetsDeployment.OncePerInitialization);

               var isInit = await api.Init("eng");
                if (await api.SetImage(path))
                {
                    var result = api.Text;

                    text = result;
                }
                else
                {
                    text = "Not Initialized";
                }



                //if (!_tesseract.Initialized)
                //{
                //    var initialised = await _tesseract.Init("eng");
                //    //if (!initialised)
                //    //    return;
                //}


                //if (await _tesseract.SetImage(path))
                //{
                //    var res = _tesseract.Text;

                //    text = res;
                //}
                //if (!await _tesseract.SetImage(path))
                //    return;

                // var words = _tesseract.Results(Tesseract.PageIteratorLevel.Word);
                //var symbols = _tesseract.Results(PageIteratorLevel.Symbol);
                //var blocks = _tesseract.Results(PageIteratorLevel.Block);
                // var paragraphs = _tesseract.Results(PageIteratorLevel.Paragraph);
                //var lines = _tesseract.Results(PageIteratorLevel.Textline);

            }
            catch (Exception ex)
            {
                text = ex.Message;


            }

            return text;
        }
    }
}