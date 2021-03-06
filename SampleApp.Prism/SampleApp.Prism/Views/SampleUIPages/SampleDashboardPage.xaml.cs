using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Prism.Views.SampleUIPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SampleDashboardPage : ContentPage
    {
        public SampleDashboardPage()
        {
            InitializeComponent();
        }
    }
}