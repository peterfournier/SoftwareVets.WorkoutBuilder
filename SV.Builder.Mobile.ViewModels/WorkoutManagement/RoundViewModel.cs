using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public ICommand AddNewExerciseToRoundCommand { get; }

        public ICommand EditRoundCommand { get; }

        public IReadOnlyList<ExerciseViewModel> Exercises => _round.Exercises.Select(x => new ExerciseViewModel(x)).ToList();

        public RoundViewModel(Round round)
        {
            _round = Guard.ForNull(round, nameof(round));

            EditRoundCommand = new DisableWhenBusyCommand(this, (args)
                => MessagingCenter.Send(this, Messages.GoToRoundFormPage, _round));

            AddNewExerciseToRoundCommand = new DisableWhenBusyCommand(this, AddNewExercise);
        }

        private void AddNewExercise(object obj)
        {
            var exercise = new Exercise(_round);

            _round.AddExercise(exercise); // todo how to handle if the new exercise is not saved on this page? Use a temperary list?

            MessagingCenter.Send(this, Messages.GoToExerciseFormPage, exercise);
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
