using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using SV.Builder.Service;
using SV.Builder.WorkoutManagement;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateWorkoutPageViewModel : BaseFormContentPageViewModel
    {
        private Workout _workout;
        //private LocalWorkoutService workoutService = DependencyService.Resolve<LocalWorkoutService>();
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

        private ICommand _goToNewRoundCommand;
        public ICommand GoToNewRoundPageCommand
        {
            get { return _goToNewRoundCommand; }
            set { SetProperty(ref _goToNewRoundCommand, value); }
        }

        private ICommand _goEditWorkoutNameCommand;
        public ICommand GoToEditWorkoutNameCommand
        {
            get { return _goEditWorkoutNameCommand; }
            set { SetProperty(ref _goEditWorkoutNameCommand, value); }
        }

        public ObservableCollection<RoundViewModel> Rounds { get; set; } = new ObservableCollection<RoundViewModel>();

        public Guid WorkoutId { get; private set;}

        public CreateWorkoutPageViewModel()
        {
            setNewWorkout();
            GoToNewRoundPageCommand = new DisableWhenBusyCommand(this, goToNewRoundPageHandler);
            GoToEditWorkoutNameCommand = new DisableWhenBusyCommand(this, goToEditWorkoutNameCommandHandler);
        }

        private void goToEditWorkoutNameCommandHandler(object obj)
        {
            MessagingCenter.Send(this, Messages.GoToEditWorkoutNamePage);
        }

        private void goToNewRoundPageHandler(object obj)
        {
            MessagingCenter.Send(this, Messages.GoToNewRoundPage);
        }

        protected override void WireUpSubscriptions()
        {
            MessagingCenter.Subscribe<EditWorkoutNamePageViewModel, Workout>(this, Messages.CreateWorkout, workoutCreatedHandler);
            MessagingCenter.Subscribe<CreateRoundPageViewModel, Round>(this, Messages.CreateRound, roundCreatedHandler);
        }

        private void setNewWorkout()
        {
            Name = DefaultWorkoutName;
            Description = DefaultDescription;

            _workout = new Workout(Name)
            {
                Description = Description
            };
            WorkoutId = _workout.ID;
        }

        private void roundCreatedHandler(CreateRoundPageViewModel createRoundPage, Round round)
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


        private void workoutCreatedHandler(EditWorkoutNamePageViewModel viewModel, Workout workout)
        {
            Name = workout.Name;
            Description = workout.Description;

            _workout.Name = Name;
            _workout.Description = Description;
        }

        public override void OnSaveCommand()
        {

            //workoutService.Create(_workout);

            base.OnSaveCommand();
        }
    }
}
