using SV.Builder.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SV.Builder.Mobile.ViewModels
{
    public class ExerciseViewModel : BaseViewModel
    {
        private string _name;
        public IExercise Exercise { get; private set; }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public ObservableCollection<SetViewModel> Sets { get; set; } = new ObservableCollection<SetViewModel>();

        public ExerciseViewModel(IExercise exercise)
        {
            Exercise = exercise;
        }

        internal void AddSet(SetViewModel setViewModel)
        {
            Exercise.AddSet(setViewModel.ExerciseSet);
            Sets.Add(setViewModel);
        }
    }
}
