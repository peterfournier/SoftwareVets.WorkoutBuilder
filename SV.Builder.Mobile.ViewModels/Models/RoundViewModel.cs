using SV.Builder.Domain;
using SV.Builder.Mobile.Common.MessageCenter;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels
{
    public class RoundViewModel : BaseViewModel
    {
        private IRound _round;

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _interations;
        public int Iternations
        {
            get { return _interations; }
            set { SetProperty(ref _interations, value); }
        }

        private TimeSpan _length;
        public TimeSpan Length
        {
            get { return _length; }
            set { SetProperty(ref _length, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public ICommand AddExerciseToRoundCommand { get; set; }

        public ObservableCollection<ExerciseViewModel> Exercises { get; private set; } = new ObservableCollection<ExerciseViewModel>();

        public RoundViewModel(IRound round)
        {
            AddExerciseToRoundCommand = new Command(addNewExerciseToRound);
            _round = round;
        }

        private void addNewExerciseToRound(object arg)
        {
            if (arg is RoundViewModel round)
                MessagingCenter.Send(this, Messages.GoToNewExercise, round);
        }

        internal void AddExercise(ExerciseViewModel exerciseViewModel)
        {
            _round.AddExercise(exerciseViewModel.Exercise);

            Exercises.Add(exerciseViewModel);
        }
    }
}
