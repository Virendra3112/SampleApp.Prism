﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Prism.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstDetailsPage : ContentPage
    {
        public FirstDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}