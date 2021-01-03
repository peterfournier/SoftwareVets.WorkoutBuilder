using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Shared
{
    class DisableWhenBusyCommand : Command
    {
        private readonly BaseViewModel _viewModel;
        public DisableWhenBusyCommand(
            BaseViewModel viewModel,
            Action<object> execute) : base(execute, x => viewModel.IsBusy == false)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        ~DisableWhenBusyCommand()
        {
            _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.IsBusy))
            {
                ChangeCanExecute();
            }
        }
    }
}
