using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class ExerciseFormPageViewModel : BaseFormContentPageViewModel
    {
        private readonly Exercise _exercise;
        private List<Guid> _setIdsToRemove = new List<Guid>();

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

        private IList<SetViewModel> _sets;
        public IReadOnlyList<SetViewModel> Sets => _sets.ToList();

        public ExerciseFormPageViewModel(Exercise exercise)
        {
            _exercise = Guard.ForNull(exercise, nameof(exercise));
            Name = _exercise.Name;
            Description = _exercise.Description;
            AddSetCommand = new DisableWhenBusyCommand(this, AddSet);


            _sets = _exercise.Sets.Select(x => new SetViewModel(x))
                                 .ToList();

            MessagingCenter.Send(this, Messages.RemoveSetViewModel, this);

            if (Sets.Count == 0)
                AddSet(null);
        }


        public override void OnSaveCommand()
        {
            UpsertExerciseSets();

            RemoveAnyExerciseSets();

            _exercise.Update(Name, Description);

            MessagingCenter.Send(this, Messages.ExerciseUpdated);

            base.OnSaveCommand();
        }

        private void RemoveAnyExerciseSets()
        {
            foreach (var idToRemove in _setIdsToRemove)
            {
                var set = _exercise.Sets.Single(x => x.Id.Equals(idToRemove));
                if (set != null)
                {
                    _exercise.RemoveSet(idToRemove);
                }
            }
        }

        private void UpsertExerciseSets()
        {
            foreach (var setViewModel in Sets)
            {
                var existingSet = _exercise.Sets.FirstOrDefault(x => x.Id.Equals(setViewModel.Id));
                if (existingSet == null)
                {
                    _exercise.AddSet(new Set(_exercise, setViewModel.GetSetOptions()));
                }
                else
                {
                    existingSet.Update(setViewModel.GetSetOptions());
                }
            }
        }

        protected void AddSet(object sender)
        {
            var set = new Set(_exercise, SetOptions.New);
            var setVM = new SetViewModel(set) { Name = $"Set {_sets.Count + 1}" };
            _sets.Add(setVM);
            NotifyClients();
        }

        public void RemoveSet(SetViewModel setViewModel)
        {
            var setToRemove = Sets.Single(x => x.Id == setViewModel.Id);
            if (setToRemove != null)
            {
                _sets.Remove(setToRemove);
                _setIdsToRemove.Add(setToRemove.Id);
            }
            NotifyClients();
        }

        public override void NotifyClients()
        {
            OnPropertyChanged(nameof(Sets));
        }
    }
}
