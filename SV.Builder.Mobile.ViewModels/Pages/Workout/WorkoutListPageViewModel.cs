using SV.Builder.WorkoutManagement;
using System.Collections.ObjectModel;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class WorkoutListPageViewModel : BaseFormContentPageViewModel
    {
        public ObservableCollection<Workout> Workouts { get; set; } = new ObservableCollection<Workout>();


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
