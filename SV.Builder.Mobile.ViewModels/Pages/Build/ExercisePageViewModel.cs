using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public abstract class ExercisePageViewModel : BaseFormContentPageViewModel
    {
        private ExerciseViewModel _exerciseViewModel;
        public ExerciseViewModel ExerciseViewModel
        {
            get { return _exerciseViewModel; }
            set { SetProperty(ref _exerciseViewModel, value); }
        }

        public ICommand AddSetCommand { get; set; }

        public ExercisePageViewModel()
        {
            AddSetCommand = new Command(AddSet);
        }

        protected void AddSet(object sender)
        {
            var set = new SetViewModel()
            {
                Name = $"Set {ExerciseViewModel.Sets.Count + 1}"
            };
            ExerciseViewModel.Sets.Add(set);
        }

        public virtual void RemoveSet(SetViewModel setViewModelArg)
        {
            var setToRemove = ExerciseViewModel.Sets.FirstOrDefault(x => x == setViewModelArg);
            if (setToRemove != null)
            {
                ExerciseViewModel.Sets.Remove(setToRemove);
            }
        }
    }
}
