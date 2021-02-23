using SV.Builder.Core.Common;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class WorkoutFormPageViewModel : BaseFormContentPageViewModel
    {
        private readonly Workout _workout;

        public string WorkoutName => _workout.Name;
        public string WorkoutDescription => _workout.Description;
        public string WorkoutDuration => _workout.EstimatedDuration.Length.ToString();
        public string NumberOfWorkoutRounds => _workout.Rounds.Count.ToString();

        public IReadOnlyList<RoundViewModel> Rounds => _workout.Rounds.Select(x => new RoundViewModel(x))
                                                                      .ToList();

        public ICommand GoToEditWorkoutNamePageCommand { get; }
        public ICommand AddNewRoundCommand { get; }

        public WorkoutFormPageViewModel(Workout workout)
        {
            _workout = Guard.ForNull(workout, nameof(workout));

            GoToEditWorkoutNamePageCommand = new DisableWhenBusyCommand(this, (args) 
                => MessagingCenter.Send(this, Messages.GoToEditWorkoutNamePage, _workout));

            AddNewRoundCommand = new DisableWhenBusyCommand(this, AddNewRound);
        }

        private void AddNewRound(object obj)
        {
            var round = new Round(_workout, "Round 1", "Brief Description", 1); // todo cleanup
            
            _workout.AddRound(round); // todo how to handle if the new round is not committed? Use a temperary list?

            MessagingCenter.Send(this, Messages.GoToRoundFormPage, round);
        }

        protected override void WireUpSubscriptions()
        {
            MessagingCenter.Subscribe<EditWorkoutNamePageViewModel>(this, Messages.WorkoutDetailsUpdated, (sender) => NotifyClients());
            MessagingCenter.Subscribe<RoundFormPageViewModel>(this, Messages.RoundUpdated, (sender) => NotifyClients());
            MessagingCenter.Subscribe<ExerciseFormPageViewModel>(this, Messages.ExerciseUpdated, (sender) => NotifyClients());

            base.WireUpSubscriptions();
        }

        protected override void Breakdown()
        {
            MessagingCenter.Unsubscribe<EditWorkoutNamePageViewModel>(this, Messages.GoToEditWorkoutNamePage);

            base.Breakdown();
        }

        
        public override void NotifyClients()
        {
            OnPropertyChanged(nameof(NumberOfWorkoutRounds));
            OnPropertyChanged(nameof(Rounds));
            OnPropertyChanged(nameof(WorkoutDescription));
            OnPropertyChanged(nameof(WorkoutDuration));
            OnPropertyChanged(nameof(WorkoutName));
        }
    }
}
