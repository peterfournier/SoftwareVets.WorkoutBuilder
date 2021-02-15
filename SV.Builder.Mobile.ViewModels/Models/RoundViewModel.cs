using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Mobile.Common.MessageCenter;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels
{
    public class RoundViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _interations = 1;
        public int Iterations
        {
            get { return _interations; }
            set { SetProperty(ref _interations, value); }
        }

        private Duration _duration = Duration.None;
        public Duration Duration
        {
            get { return _duration; }
            set { SetProperty(ref _duration, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public ICommand AddExerciseToRoundCommand { get; set; }

        public ObservableCollection<ExerciseViewModel> Exercises { get; private set; } = new ObservableCollection<ExerciseViewModel>();

        public RoundViewModel()
        {
            AddExerciseToRoundCommand = new Command(addNewExerciseToRound);
        }

        private void addNewExerciseToRound(object arg)
        {
            MessagingCenter.Send(this, Messages.GoToNewExercisePage);
        }

        internal void AddExercise(ExerciseViewModel exerciseViewModel)
        {
            foreach (var set in exerciseViewModel.Sets)
            {
                Duration += set.Duration;
            }
            Exercises.Add(exerciseViewModel);
        }
    }
}
