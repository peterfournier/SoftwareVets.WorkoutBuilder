using SV.Builder.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SV.Builder.Mobile.Common.MessageCenter;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class EditExercisePageViewModel : ExercisePageViewModel
    {
        public ExerciseViewModel OriginalExerciseViewModel { get; private set; }
        public EditExercisePageViewModel(ExerciseViewModel exerciseViewModel)
        {
            OriginalExerciseViewModel = Guard.ForNull(exerciseViewModel, nameof(exerciseViewModel));
            ExerciseViewModel = new ExerciseViewModel();
            MapProperties(OriginalExerciseViewModel, ExerciseViewModel);
        }

        private void MapProperties(ExerciseViewModel source, ExerciseViewModel destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;
            foreach (var set in source.Sets)
            {
                var newSet = new SetViewModel();
                newSet.Name = set.Name;
                newSet.SelectedHours = set.SelectedHours;
                newSet.SelectedMinutes = set.SelectedMinutes;
                newSet.SelectedSeconds = set.SelectedSeconds;
                newSet.StopwatchSet = set.StopwatchSet;
                newSet.Weight = set.Weight;
                newSet.MaxSet = set.MaxSet;
            }
        }

        public override void OnSaveCommand()
        {
            // override to string properties for labels, duration, exerciseviewmodel

            OriginalExerciseViewModel.Sets.Clear();
            MapProperties(ExerciseViewModel, OriginalExerciseViewModel);

            MessagingCenter.Send(this, Messages.OnExerciseSaved, ExerciseViewModel);

            base.OnSaveCommand();
        }
    }
}
