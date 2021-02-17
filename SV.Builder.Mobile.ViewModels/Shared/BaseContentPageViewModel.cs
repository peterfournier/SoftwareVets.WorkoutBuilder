using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Shared
{
    public abstract class BaseFormContentPageViewModel: BaseContentPageViewModel
    {
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

        public BaseFormContentPageViewModel()
        {
            CancelCommand = new Command(OnCancelCommand);
            SaveCommand = new Command(OnSaveCommand);
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
