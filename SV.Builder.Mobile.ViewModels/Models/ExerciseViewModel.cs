using SV.Builder.WorkoutManagement;
using System.Collections.ObjectModel;

namespace SV.Builder.Mobile.ViewModels
{
    public class ExerciseViewModel : BaseViewModel
    {
        private string _name;
        public Exercise Exercise { get; private set; }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ObservableCollection<SetViewModel> Sets { get; set; } = new ObservableCollection<SetViewModel>();

        public ExerciseViewModel(Exercise exercise)
        {
            Exercise = exercise;
        }

        internal void AddSet(SetViewModel setViewModel)
        {
            Exercise.AddSet(setViewModel.ExerciseSet);
            Sets.Add(setViewModel);
        }
    }
}
