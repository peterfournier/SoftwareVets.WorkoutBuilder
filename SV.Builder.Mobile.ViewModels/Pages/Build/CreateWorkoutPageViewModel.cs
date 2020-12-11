using SV.Builder.Domain;
using SV.Builder.Domain.Factories;
using SV.Builder.Mobile.Common.MessageCenter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateWorkoutPageViewModel : BaseViewModel
    {
        private IWorkout _workout;


        private ICommand _addRoundCommand;
        public ICommand AddRoundCommand
        {
            get => _addRoundCommand;
            set => SetProperty(ref _addRoundCommand, value);
        }

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



        public CreateWorkoutPageViewModel()
        {
            Name = "Enter a name";
            Description = "Description";

            AddRoundCommand = new Command(onAddRoundCommand);

            MessagingCenter.Subscribe<EditWorkoutNamePageViewModel, IWorkout>(this, Messages.CreateWorkout, workoutCreatedHandler);
        }

        private void onAddRoundCommand(object obj)
        {
            //await Shell.Current.Navigation.PushModalAsync(new CreateWorkoutPage());
            var test = "";
        }

        private void workoutCreatedHandler(EditWorkoutNamePageViewModel viewModel, IWorkout workout)
        {
            Name = workout.Name;
            Description = workout.Description;

            _workout = workout;
        }
    }
}
