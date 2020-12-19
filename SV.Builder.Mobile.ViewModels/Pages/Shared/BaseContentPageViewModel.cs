using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class BaseContentPageViewModel : BaseViewModel
    {
        //public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();       
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
            set { SetProperty(ref _cancelCommand, value); }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get { return _saveCommand; }
            set { SetProperty(ref _saveCommand, value); }
        }

        public BaseContentPageViewModel()
        {
            CancelCommand = new Command(OnCancelCommand);
            SaveCommand = new Command(OnSaveCommand);
            WireUpSubscriptions();
        }

        protected virtual void WireUpSubscriptions()
        {

        }

        public async virtual void OnCancelCommand()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        public async virtual void OnSaveCommand()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
