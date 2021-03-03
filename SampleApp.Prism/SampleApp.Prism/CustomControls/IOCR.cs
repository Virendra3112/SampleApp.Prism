using System.Threading.Tasks;

namespace SampleApp.Prism.CustomControls
{
    public interface IOCR
    {
        Task<string> ReadImage(string path);
    }
}
