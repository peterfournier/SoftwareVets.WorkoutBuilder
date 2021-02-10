using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.WorkoutManagement;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class EditWorkoutNamePageViewModel : BaseFormContentPageViewModel
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

            var workout = new Workout(Name) { Description = Description };

            MessagingCenter.Send(this, Messages.CreateWorkout, workout);

            base.OnSaveCommand();
        }
    }
}
