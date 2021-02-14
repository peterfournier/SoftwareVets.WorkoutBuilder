using SV.Builder.Mobile.Common.MessageCenter;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateExercisePageViewModel : BaseFormContentPageViewModel
    {
        private readonly RoundViewModel _roundViewModel;

        private ExerciseViewModel _exerciseViewModel;
        public ExerciseViewModel ExerciseViewModel
        {
            get { return _exerciseViewModel; }
            set { SetProperty(ref _exerciseViewModel, value); }
        }


        public ICommand AddSetCommand { get; set; }

        public CreateExercisePageViewModel(RoundViewModel roundViewModel)
        {
            if (roundViewModel == null)
                throw new ArgumentNullException(nameof(roundViewModel));

            _roundViewModel = roundViewModel;
            ExerciseViewModel = new ExerciseViewModel();

            addSet(null);
            AddSetCommand = new Command(addSet);
        }

        private void addSet(object sender)
        {
            var set = new SetViewModel()
            {
                Name = $"Set {ExerciseViewModel.Sets.Count + 1}"
            };
            ExerciseViewModel.Sets.Add(set);
        }

        public void RemoveSet(SetViewModel setViewModelArg)
        {
            var setToRemove = ExerciseViewModel.Sets.FirstOrDefault(x => x == setViewModelArg);
            if (setToRemove != null)
            {
                ExerciseViewModel.Sets.Remove(setToRemove);
            }
        }

        public override void OnSaveCommand()
        {
            _roundViewModel.AddExercise(ExerciseViewModel);

            base.OnSaveCommand();
        }
    }
}
