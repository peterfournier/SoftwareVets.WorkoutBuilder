using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public abstract class BaseContentPageViewModel : BaseViewModel
    {
        //public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public BaseContentPageViewModel()
        {
            WireUpSubscriptions();
        }

        protected virtual void WireUpSubscriptions()
        {

        }
    }
}
