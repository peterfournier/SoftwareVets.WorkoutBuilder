using SV.Builder.Domain;
using SV.Builder.Domain.Factories;
using SV.Builder.Mobile.Common.MessageCenter;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateWorkoutPageViewModel : BaseContentPageViewModel
    {
        private IWorkout _workout;
        public string DefaultWorkoutName = "Enter a name";
        public string DefaultDescription = "Description";

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public ObservableCollection<RoundViewModel> Rounds { get; set; } = new ObservableCollection<RoundViewModel>();

        public CreateWorkoutPageViewModel()
        {
            setNewWorkout();
        }

        protected override void WireUpSubscriptions()
        {
            MessagingCenter.Subscribe<EditWorkoutNamePageViewModel, IWorkout>(this, Messages.CreateWorkout, workoutCreatedHandler);
            MessagingCenter.Subscribe<CreateRoundPageViewModel, IRound>(this, Messages.CreateRound, roundCreatedHandler);
            MessagingCenter.Subscribe<CreateExercisePageViewModel, IExercise>(this, Messages.CreateExercise, exerciseCreatedHandler);
        }

        private void setNewWorkout()
        {
            Name = DefaultWorkoutName;
            Description = DefaultDescription;

            var factory = new WorkoutFactory();
            _workout = factory.CreateWorkout(Name, Description);
        }

        private void roundCreatedHandler(CreateRoundPageViewModel createRoundPage, IRound round)
        {
            _workout.AddRound(round);
            var roundViewModel = new RoundViewModel(round)
            {
                Name = round.Name,
                Length = round.Duration,
                Iternations = round.Iterations,
                Description = round.Description
            };
            Rounds.Add(roundViewModel);
        }

        private void exerciseCreatedHandler(CreateExercisePageViewModel createExerciseViewModel, IExercise exercise)
        {
            // Which Round are we adding this exercise too?

            // Need a collection to bind too

            // Need Xaml
        }

        private void workoutCreatedHandler(EditWorkoutNamePageViewModel viewModel, IWorkout workout)
        {
            Name = workout.Name;
            Description = workout.Description;

            _workout.ChangeName(Name);
            _workout.Description = Description;
        }
    }
}
