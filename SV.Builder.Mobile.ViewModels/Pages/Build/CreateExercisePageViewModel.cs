using SV.Builder.Domain;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateExercisePageViewModel : BaseFormContentPageViewModel
    {
        private readonly IExercise _exercise;

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<SetViewModel> Sets { get; set; } = new ObservableCollection<SetViewModel>();

        public ICommand AddSetCommand { get; set; }

        public CreateExercisePageViewModel()
        {
            var exerciseFactory = new ExerciseFactory();
            _exercise = exerciseFactory.CreateExercise("Exercise 1");
            addSet(null);
            AddSetCommand = new Command(addSet);
            PropertyChanged += CreateExercisePageViewModel_PropertyChanged;
        }

        private void CreateExercisePageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Name)))
                updateExerciseName();
        }

        private void updateExerciseName()
        {
            _exercise.Name = Name;
        }

        private void addSet(object sender)
        {
            Sets.Add(new SetViewModel()
            {
                Name = $"Set {Sets.Count + 1}"
            });
        }

        public override void OnSaveCommand()
        {
            foreach (var setViewModel in Sets)
            {
                var setFactory = new ExerciseSetFactory();
                
                var set = new Set(weight: setViewModel.Weight ?? 0
                    , duration: setViewModel.Duration
                    , timed: setViewModel.StopwatchSet);

                var exerciseSet = setFactory.CreateSet(set);

                _exercise.AddSet(exerciseSet);
            }

            base.OnSaveCommand();
        }
    }
}
