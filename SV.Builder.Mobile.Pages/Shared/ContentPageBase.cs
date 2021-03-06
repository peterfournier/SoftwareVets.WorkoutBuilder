﻿using SV.Builder.Mobile.ViewModels.Shared;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SV.Builder.Mobile.Views.Shared
{
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
            On<iOS>().SetUseSafeArea(true);
        }
    }

    public abstract class ContentPageBase<TViewModel> : ContentPage
        where TViewModel : BaseContentPageViewModel, new()
    {
        public ContentPageBase()
        {
            On<iOS>().SetUseSafeArea(true);

            BindingContext = new TViewModel();
        }
    }
}