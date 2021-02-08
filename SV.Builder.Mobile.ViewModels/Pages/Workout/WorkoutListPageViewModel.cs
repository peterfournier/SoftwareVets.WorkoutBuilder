using SV.Builder.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class WorkoutListPageViewModel : BaseFormContentPageViewModel
    {
        public ObservableCollection<IWorkout> Workouts { get; set; } = new ObservableCollection<IWorkout>();


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
