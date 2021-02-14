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

        //private string _name;
        //public string Name
        //{
        //    get => _name;
        //    set => SetProperty(ref _name, value);
        //}

        //public ObservableCollection<SetViewModel> Sets { get; private set; } = new ObservableCollection<SetViewModel>();

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
            //var setFactory = new ExerciseSetFactory();
            //_exercise = new Exercise(_roundViewModel.RoundId, Name);
            //var exerciseViewModel = new ExerciseViewModel(_exercise)
            //{
            //    Name = Name
            //};

            //foreach (var setViewModel in Sets)
            //{
            //    ExerciseSet exerciseSet = createDomainExerciseSet(setFactory, setViewModel);

            //    setDataBackingField(setViewModel, exerciseSet);

            //    exerciseViewModel.AddSet(setViewModel);
            //}

            _roundViewModel.AddExercise(ExerciseViewModel);

            //MessagingCenter.Send(this, Messages.ExerciseViewModelCreated);

            base.OnSaveCommand();
        }

        //private void setDataBackingField(SetViewModel setViewModel, ExerciseSet exerciseSet)
        //{
        //    //setViewModel.SetExerciseSet(exerciseSet);
        //}

        //private ExerciseSet createDomainExerciseSet(
        //    ExerciseSetFactory setFactory, 
        //    SetViewModel setViewModel
        //    )
        //{
        //    double.TryParse(setViewModel.Weight, out double weight);

        //    var set = new Set(weight: weight
        //                        , duration: setViewModel.Duration
        //                        , timed: setViewModel.StopwatchSet);

        //    var exerciseSet = setFactory.CreateSet(_exercise.ID, set);
        //    return exerciseSet;
        //}
    }
}
