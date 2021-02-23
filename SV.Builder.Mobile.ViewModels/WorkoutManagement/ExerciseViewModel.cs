using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class ExerciseViewModel : BaseViewModel
    {
        private readonly Exercise _exercise;

        public string Name => _exercise.Name;
        public string Description => _exercise.Description;
        public Duration Duration => _exercise.EstimatedDuration;

        public ICommand EditExerciseCommand { get; }

        public IReadOnlyList<SetViewModel> Sets => _exercise.Sets.Select(x => new SetViewModel(x))
                                                                 .ToList();

        public ExerciseViewModel(Exercise exercise)
        {
            _exercise = Guard.ForNull(exercise, nameof(exercise));

            EditExerciseCommand = new DisableWhenBusyCommand(this, EditExerciseHandler);
        }

        private void EditExerciseHandler(object obj)
        {
            MessagingCenter.Send(this, Messages.GoToExerciseFormPage, _exercise);
        }

        ~ExerciseViewModel()
        {
            MessagingCenter.Unsubscribe<ExerciseViewModel>(this, Messages.GoToExerciseFormPage);
        }

        //internal void AddSet(SetViewModel setViewModel)
        //{
        //    Duration += setViewModel.Duration;
        //    Sets.Add(setViewModel);
        //}
    }
}
