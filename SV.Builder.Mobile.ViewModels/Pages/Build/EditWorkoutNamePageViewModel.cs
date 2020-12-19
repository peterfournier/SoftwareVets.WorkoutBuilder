using SV.Builder.Domain.Factories;
using SV.Builder.Mobile.Common.MessageCenter;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class EditWorkoutNamePageViewModel : BaseContentPageViewModel
    {
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

        public EditWorkoutNamePageViewModel()
        {

        }

        public override void OnSaveCommand()
        {
            var workoutFactory = new WorkoutFactory();

            var workout = workoutFactory.CreateWorkout(Name, Description);

            MessagingCenter.Send(this, Messages.CreateWorkout, workout);

            base.OnSaveCommand();
        }
    }
}
