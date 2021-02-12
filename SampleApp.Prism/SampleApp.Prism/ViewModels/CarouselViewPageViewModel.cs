using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using SampleApp.Prism.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleApp.Prism.ViewModels
{
    public class CarouselViewPageViewModel : BaseViewModel
    {

        private List<CarouselModel> _list;
        public List<CarouselModel> CarouselList
        {
            get { return _list; }
            set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        private bool _leftBtnVisible;
        public bool LeftBtnVisible
        {
            get { return _leftBtnVisible; }
            set
            {
                _leftBtnVisible = value;
                RaisePropertyChanged();
            }
        }
        private bool _rightBtnVisible;
        public bool RightBtnVisible
        {
            get { return _rightBtnVisible; }
            set
            {
                _rightBtnVisible = value;
                RaisePropertyChanged();
            }
        }

        private int _currenrtImagePosition;
        public int CurrenrtImagePosition
        {
            get { return _currenrtImagePosition; }
            set
            {
                _currenrtImagePosition = value;
                RaisePropertyChanged();
                SetBtnStatus(value);
            }
        }


        public ICommand RightCommand { get; set; }

        public ICommand LeftCommand { get; set; }

        public CarouselViewPageViewModel(INavigationService navigationService, IDialogService dialogService, IPageDialogService pageDialogService)
              : base(navigationService, dialogService, pageDialogService)
        {
            RightCommand = new Command(RightClicked);

            LeftCommand = new Command(LeftClicked);

            GetData();
        }

        private void SetBtnStatus(int Position)
        {
            try
            {
                if (CarouselList != null && CarouselList.Any())
                {
                    var itemcount = CarouselList.Count - 1;

                    if (Position == 0)
                    {
                        LeftBtnVisible = false;
                        RightBtnVisible = true;
                    }

                    else if (Position == itemcount)
                    {
                        LeftBtnVisible = true;
                        RightBtnVisible = false;

                    }
                    else
                    {
                        LeftBtnVisible = true;
                        RightBtnVisible = true;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LeftClicked(object obj)
        {
            try
            {
                if (CarouselList != null && CarouselList.Any())
                {
                    CurrenrtImagePosition = CurrenrtImagePosition - 1;
                }
            }
            catch (Exception)
            {

            }

        }

        private void RightClicked(object obj)
        {
            try
            {
                if (CarouselList != null && CarouselList.Any())
                {
                    CurrenrtImagePosition = CurrenrtImagePosition + 1;
                }

            }
            catch (Exception)
            {

            }

        }

        public void GetData()
        {
            Height = App.ScreenHeight.ToString();
            Width = App.ScreenWidth.ToString();

            CarouselList = new List<CarouselModel>
            {
                new CarouselModel
                {

                    Id = 1,
                    ImageUrl = "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/410.svg",
                    IsCurrent = false,
                },

                new CarouselModel
                {

                    Id = 2,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0496/1029/files/Freesample.svg",
                    IsCurrent = false,
                },

                new CarouselModel
                {

                    Id = 3,
                    ImageUrl = "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/zillow.svg",
                    IsCurrent = false,
                },

                new CarouselModel
                {

                    Id = 4,
                    ImageUrl = "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/cartman.svg",
                    IsCurrent = false,
                },
                new CarouselModel
                {

                    Id = 5,
                    ImageUrl =  "https://dev.w3.org/SVG/tools/svgweb/samples/svg-files/mozilla.svg",
                    IsCurrent = false,
                },
            };
        }
    }
}
