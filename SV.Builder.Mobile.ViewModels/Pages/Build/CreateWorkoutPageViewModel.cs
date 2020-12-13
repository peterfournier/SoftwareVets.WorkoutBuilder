using SV.Builder.Domain;
using SV.Builder.Domain.Factories;
using SV.Builder.Mobile.Common.MessageCenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateWorkoutPageViewModel : BaseViewModel
    {
        private IWorkout _workout;


        //private ICommand _addRoundCommand;
        //public ICommand AddRoundCommand
        //{
        //    get => _addRoundCommand;
        //    set => SetProperty(ref _addRoundCommand, value);
        //}

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

        public ObservableCollection<string> Rounds { get; set; } = new ObservableCollection<string>();

        public CreateWorkoutPageViewModel()
        {
            setNewWorkout();
        }

        protected override void WireUpSubscriptions()
        {
            MessagingCenter.Subscribe<EditWorkoutNamePageViewModel, IWorkout>(this, Messages.CreateWorkout, workoutCreatedHandler);
            MessagingCenter.Subscribe<CreateRoundPageViewModel, IRound>(this, Messages.CreateRound, roundCreatedHandler);
        }

        private void setNewWorkout()
        {
            Name = "Enter a name";
            Description = "Description";

            var factory = new WorkoutFactory();
            _workout = factory.CreateWorkout(Name, Description);
        }

        private void roundCreatedHandler(CreateRoundPageViewModel createRoundPage, IRound round)
        {
            _workout.AddRound(round);
            Rounds.Add(round.Name);
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
