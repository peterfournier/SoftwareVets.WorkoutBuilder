using SV.Builder.Domain;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateWorkoutPageViewModel : BaseViewModel
    {
        private readonly WorkoutFactory workoutFactory;

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
            Name = "Workout a";
            Description = "description";
        }
    }
}
