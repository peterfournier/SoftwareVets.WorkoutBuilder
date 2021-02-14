using SV.Builder.Mobile.Common.MessageCenter;
using System;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateRoundPageViewModel : BaseFormContentPageViewModel
    {
        private RoundViewModel _roundViewModel;
        public RoundViewModel RoundViewModel
        {
            get { return _roundViewModel; }
            set { SetProperty(ref _roundViewModel, value); }
        }

        public CreateRoundPageViewModel()
        {
            RoundViewModel = new RoundViewModel();
        }

        public override void OnSaveCommand()
        {

            MessagingCenter.Send(this, Messages.CreateRound, RoundViewModel);

            base.OnSaveCommand();
        }

    }
}
