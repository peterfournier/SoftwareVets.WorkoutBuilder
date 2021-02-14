using SV.Builder.Core.WorkoutManagement;
using System.Collections.ObjectModel;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class WorkoutListPageViewModel : BaseFormContentPageViewModel
    {
        public ObservableCollection<Workout> Workouts { get; set; } = new ObservableCollection<Workout>(); // todo: should not be domain model


        public WorkoutListPageViewModel()
        {
            getWorkouts();
        }

        private void getWorkouts()
        {
            //Workouts = Repository.Get<IWorkout>();
        }
    }
}
