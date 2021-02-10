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
        
        private double _height;
        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged();
            }
        }private double _width;
        public double Width
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
            Height = App.ScreenHeight;
            Width = App.ScreenWidth;

            CList = new List<string>
            {
                "Hey",
                "Did you check the",
                "The CarouselView",
                "In Xamarin.Forms?"
            };
        }
    }
}
