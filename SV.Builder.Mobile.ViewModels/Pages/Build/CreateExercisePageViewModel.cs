using System;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateExercisePageViewModel : ExercisePageViewModel
    {
        private readonly RoundViewModel _roundViewModel;

        public CreateExercisePageViewModel(RoundViewModel roundViewModel)
        {
            if (roundViewModel == null)
                throw new ArgumentNullException(nameof(roundViewModel));

            _roundViewModel = roundViewModel;
            ExerciseViewModel = new ExerciseViewModel();

            AddDefaultSet();
        }

        private void AddDefaultSet()
        {
            AddSet(null);
        }
        public override void OnSaveCommand()
        {
            _roundViewModel.AddExercise(ExerciseViewModel); // todo this is leaky

            base.OnSaveCommand();
        }
    }
}
