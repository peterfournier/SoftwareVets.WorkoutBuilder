using SV.Builder.Domain;
using SV.Builder.Domain.Factories;
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
        private IExercise _exercise;
        private readonly RoundViewModel _roundViewModel;

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<SetViewModel> Sets { get; private set; } = new ObservableCollection<SetViewModel>();

        public ICommand AddSetCommand { get; set; }

        public CreateExercisePageViewModel(RoundViewModel roundViewModel)
        {
            if (roundViewModel == null)
                throw new ArgumentNullException(nameof(roundViewModel));

            _roundViewModel = roundViewModel;
            
            addSet(null);
            AddSetCommand = new Command(addSet);
        }

        private void addSet(object sender)
        {
            var set = new SetViewModel()
            {
                Name = $"Set {Sets.Count + 1}"
            };
            Sets.Add(set);
        }

        public void RemoveSet(SetViewModel setViewModelArg)
        {
            var setToRemove = Sets.FirstOrDefault(x => x == setViewModelArg);
            if (setToRemove != null)
            {
                Sets.Remove(setToRemove);
            }
        }

        public override void OnSaveCommand()
        {
            var setFactory = new ExerciseSetFactory();
            var exerciseFactory = new ExerciseFactory();
            _exercise = exerciseFactory.CreateExercise(Name);
            var exerciseViewModel = new ExerciseViewModel(_exercise)
            { 
                Name = Name
            };

            foreach (var setViewModel in Sets)
            {
                IExerciseSet exerciseSet = createDomainExerciseSet(setFactory, setViewModel);

                setDataBackingField(setViewModel, exerciseSet);

                exerciseViewModel.AddSet(setViewModel);
            }

            _roundViewModel.AddExercise(exerciseViewModel);

            //MessagingCenter.Send(this, Messages.CreateExercise, _roundViewModel);

            base.OnSaveCommand();
        }

        private void setDataBackingField(SetViewModel setViewModel, IExerciseSet exerciseSet)
        {
            setViewModel.SetExerciseSet(exerciseSet);
        }

        private IExerciseSet createDomainExerciseSet(ExerciseSetFactory setFactory, SetViewModel setViewModel)
        {
            double.TryParse(setViewModel.Weight, out double weight);

            var set = new Set(weight: weight
                                , duration: setViewModel.Duration
                                , timed: setViewModel.StopwatchSet);

            var exerciseSet = setFactory.CreateSet(set);
            return exerciseSet;
        }
    }
}
