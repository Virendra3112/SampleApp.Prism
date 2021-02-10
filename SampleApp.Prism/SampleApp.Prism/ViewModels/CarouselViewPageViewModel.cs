using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using SampleApp.Prism.Models;
using SampleApp.Prism.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class CarouselViewPageViewModel : BaseViewModel
    {

        private List<string> _list;
        public List<string> CList
        {
            get { return _list; }
            set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }
        
        private string _height;
        public string Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged();
            }
        }
        private string _width;
        public string Width
        {
            get { return _width; }
            set
            {
                _width = value;
                RaisePropertyChanged();
            }
        }
        public CarouselViewPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
              : base(navigationService, dialogService, pageDialogService)
        {
            GetData();
        }

        public void GetData()
        {
            Height = App.ScreenHeight.ToString();
            Width = App.ScreenWidth.ToString();

            CList = new List<string>
            {
                "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/410.svg",
                "https://cdn.shopify.com/s/files/1/0496/1029/files/Freesample.svg",
                "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/zillow.svg",
                "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/cartman.svg",
                "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/mozilla.svg",
                
            };
        }
    }
}
