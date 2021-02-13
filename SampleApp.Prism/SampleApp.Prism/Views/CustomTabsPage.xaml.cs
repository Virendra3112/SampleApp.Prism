
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Prism.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTabsPage : TabbedPage
    {
        public CustomTabsPage()
        {
            InitializeComponent();
        }
    }
}