using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class RoundViewModel : BaseViewModel
    {
        private readonly Round _round;

        public string Name => _round.Name;

        public int Iterations => _round.Iterations;

        public Duration Duration => _round.EstimatedDuration;

        public string Description => _round.Description;

        public ICommand AddExerciseToRoundCommand { get; }

        public ICommand EditRoundCommand { get; }

        //public IReadOnlyList<ExerciseViewModel> Exercises => _round.Exercises;

        public RoundViewModel(Round round)
        {
            _round = Guard.ForNull(round, nameof(round));

            EditRoundCommand = new DisableWhenBusyCommand(this, (args)
                => MessagingCenter.Send(this, Messages.GoToRoundFormPage, _round));

            //AddExerciseToRoundCommand = new Command(addNewExerciseToRound);
        }

        //private void addNewExerciseToRound(object arg)
        //{
        //    MessagingCenter.Send(this, Messages.GoToCreateExercisePage);
        //}

        //internal void AddExercise(ExerciseViewModel exerciseViewModel)
        //{
        //    foreach (var set in exerciseViewModel.Sets)
        //    {
        //        Duration += set.Duration;
        //    }
        //    Exercises.Add(exerciseViewModel);
        //}
    }
}
