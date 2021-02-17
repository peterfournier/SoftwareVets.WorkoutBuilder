using SV.Builder.Core.Common;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class WorkoutFormPageViewModel : BaseFormContentPageViewModel
    {
        private readonly Workout _workout;

        public string WorkoutName => _workout.Name;
        public string WorkoutDescription => _workout.Description;
        public string WorkoutDuration => _workout.EstimatedDuration.Length.ToString();
        public string NumberOfWorkoutRounds => _workout.Rounds.Count.ToString();

        public ICommand GoToEditWorkoutNamePageCommand { get; }

        public WorkoutFormPageViewModel(Workout workout)
        {
            _workout = Guard.ForNull(workout, nameof(workout));
            GoToEditWorkoutNamePageCommand = new DisableWhenBusyCommand(this, (args) => MessagingCenter.Send(this, Messages.GoToEditWorkoutNamePage, _workout));
        }

        protected override void WireUpSubscriptions()
        {
            MessagingCenter.Subscribe<EditWorkoutNamePageViewModel>(this, Messages.WorkoutDetailsUpdated, (sender) => UpdateClient());

            base.WireUpSubscriptions();
        }

        protected override void Breakdown()
        {
            MessagingCenter.Unsubscribe<EditWorkoutNamePageViewModel>(this, Messages.GoToEditWorkoutNamePage);

            base.Breakdown();
        }

        private void UpdateClient()
        {
            OnPropertyChanged(nameof(WorkoutName));
            OnPropertyChanged(nameof(WorkoutDescription));
            OnPropertyChanged(nameof(WorkoutDuration));
            OnPropertyChanged(nameof(NumberOfWorkoutRounds));
        }
    }
}
