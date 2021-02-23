using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
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

        public ICommand AddSetCommand { get; set; }

        public IList<SetViewModel> Sets { get; private set; }
        public ExerciseFormPageViewModel(Exercise exercise)
        {

            _exercise = Guard.ForNull(exercise, nameof(exercise));
            Name = _exercise.Name;
            Description = _exercise.Description;
            AddSetCommand = new DisableWhenBusyCommand(this, AddSet);

            Sets = _exercise.Sets.ToList().GetOrderedVMCollection();

            if (Sets.Count == 0)
                AddSet(null);
        }

        public override void OnSaveCommand()
        {
            foreach (var set in Sets)
            {
                set.UpdateSet();
            }
            _exercise.Update(Name, Description);

            MessagingCenter.Send(this, Messages.ExerciseUpdated);

            base.OnSaveCommand();
        }

        protected void AddSet(object sender)
        {
            var set = new Set(_exercise, SetOptions.New);
            _exercise.AddSet(set);
            Sets.Add(new SetViewModel(set));
            NotifyClients();
        }

        //public virtual void RemoveSet(SetViewModel setViewModelArg)
        //{
        //    var setToRemove = ExerciseViewModel.Sets.FirstOrDefault(x => x == setViewModelArg);
        //    if (setToRemove != null)
        //    {
        //        ExerciseViewModel.Sets.Remove(setToRemove);
        //    }
        //}

        public override void NotifyClients()
        {
            OnPropertyChanged(nameof(Sets));
        }

    }

    public static class ViewModelHelpers
    {
        public static IList<SetViewModel> GetOrderedVMCollection(this IList<Set> set)
        {
            Guard.ForNull(set, nameof(set));

            var list = new List<SetViewModel>();
            for (int i = 0; i < set.Count(); i++)
            {
                list.Add(new SetViewModel(set[i])
                {
                    Name = $"Set {i + 1}"
                });
            }

            return list;
        }
    }
}
