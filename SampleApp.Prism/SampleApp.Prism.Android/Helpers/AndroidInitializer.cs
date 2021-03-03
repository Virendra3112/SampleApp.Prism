using Prism;
using Prism.Ioc;
using Tesseract;
using Tesseract.Droid;

namespace SampleApp.Prism.Droid.Helpers
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ITesseractApi, TesseractApi>();

        }
    }
}