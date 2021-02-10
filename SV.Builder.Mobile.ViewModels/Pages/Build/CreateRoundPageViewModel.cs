using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.WorkoutManagement;
using System;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateRoundPageViewModel : BaseFormContentPageViewModel
    {
        private int _iterations = 1;
        public int Iterations
        {
            get => _iterations;
            set => SetProperty(ref _iterations, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private readonly Guid _workoutId;

        public CreateRoundPageViewModel(Guid workoutId)
        {
            _workoutId = workoutId;
        }

        public override void OnSaveCommand()
        {
            var round = new Round(_workoutId, Name)
            {
                Description = Description,
                Iterations = Iterations
            };

            MessagingCenter.Send(this, Messages.CreateRound, round);

            base.OnSaveCommand();
        }

    }
}
