using SV.Builder.Core.Common;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class ExerciseFormPageViewModel : BaseFormContentPageViewModel
    {
        private readonly Exercise _exercise;

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        //public ICommand AddSetCommand { get; set; }

        public ExerciseFormPageViewModel(Exercise exercise)
        {

            _exercise = Guard.ForNull(exercise, nameof(exercise));
            Name = _exercise.Name;
            Description = _exercise.Description;
            //AddSetCommand = new Command(AddSet);
        }


        public override void OnSaveCommand()
        {
            _exercise.Update(Name, Description);

            MessagingCenter.Send(this, Messages.ExerciseUpdated);

            base.OnSaveCommand();
        }

        //protected void AddSet(object sender)
        //{
        //    var set = new SetViewModel()
        //    {
        //        Name = $"Set {ExerciseViewModel.Sets.Count + 1}"
        //    };
        //    ExerciseViewModel.Sets.Add(set);
        //}

        //public virtual void RemoveSet(SetViewModel setViewModelArg)
        //{
        //    var setToRemove = ExerciseViewModel.Sets.FirstOrDefault(x => x == setViewModelArg);
        //    if (setToRemove != null)
        //    {
        //        ExerciseViewModel.Sets.Remove(setToRemove);
        //    }
        //}
    }
}
