using SoftwareVets.WorkoutBuilder.Mobile.ViewModels.Pages;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SoftwareVets.WorkoutBuilder.Mobile.Views.Pages
{
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
            On<iOS>().SetUseSafeArea(true);
        }
    }

    public abstract class ContentPageBase<TViewModel> : ContentPage
        where TViewModel : BaseViewModel, new()
    {
        public ContentPageBase()
        {
            On<iOS>().SetUseSafeArea(true);

            BindingContext = new TViewModel();
        }
    }
}