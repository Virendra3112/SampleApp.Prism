using System;
using SampleApp.Prism.CustomControls;
using SampleApp.Prism.iOS.CustomRendrers;
using SampleApp.Prism.Models.Enum;
using SampleApp.Prism.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThemeHelper))]
namespace SampleApp.Prism.iOS.CustomRendrers
{
    public class ThemeHelper : IAppTheme
    {        public void SetAppTheme(Theme theme)
        {
            if (theme == Theme.Dark)
            {
                if (App.AppTheme == Theme.Dark)
                    return;
                App.Current.Resources = new DarkTheme();
            }
            else
            {
                if (App.AppTheme != Theme.Dark)
                    return;
                App.Current.Resources = new LightTheme();
            }
            App.AppTheme = theme;
        }
    }
}