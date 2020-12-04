using SoftwareVets.WorkoutBuilder.Mobile.Views.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SoftwareVets.WorkoutBuilder.Mobile.Views.Pages
{
    public abstract class ContentPageBase : ContentPage
    {
        public AppTheme Theme { get; set; }

        public ContentPageBase()
        {
            On<iOS>().SetUseSafeArea(true);

            Theme = new DarkTheme();
            var themeResourceDictionary = new ThemeResourceDictionary();
            themeResourceDictionary.ApplyTheme(Theme);

            Resources.Add(themeResourceDictionary);
        }
    }
}