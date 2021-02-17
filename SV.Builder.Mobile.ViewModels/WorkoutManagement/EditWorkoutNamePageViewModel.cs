using SV.Builder.Core.Common;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class EditWorkoutNamePageViewModel : BaseFormContentPageViewModel
    {
        private readonly Workout _workout;

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

        public EditWorkoutNamePageViewModel(Workout workout)
        {
            _workout = Guard.ForNull(workout, nameof(workout));
            Name = _workout.Name;
            Description = _workout.Description;
        }

        public override void OnSaveCommand()
        {
            _workout.Name = Name;
            _workout.Description = Description;

            MessagingCenter.Send(this, Messages.WorkoutDetailsUpdated);

            base.OnSaveCommand();
        }
    }
}
