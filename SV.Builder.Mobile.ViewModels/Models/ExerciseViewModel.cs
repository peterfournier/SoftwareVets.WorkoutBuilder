using SV.Builder.Core.SharedKernel;
using SV.Builder.Mobile.Common.MessageCenter;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels
{
    public class ExerciseViewModel : BaseViewModel
    {
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
        public Duration Duration { get; private set; } = Duration.None;

        public ICommand EditExerciseCommand { get; set; }

        public ObservableCollection<SetViewModel> Sets { get; set; } = new ObservableCollection<SetViewModel>();

        public ExerciseViewModel()
        {
            EditExerciseCommand = new Command(EditExerciseCommandHandler);
        }

        private void EditExerciseCommandHandler(object obj)
        {
            MessagingCenter.Send(this, Messages.GoToEditExercisePage);
        }

        internal void AddSet(SetViewModel setViewModel)
        {
            Duration += setViewModel.Duration;
            Sets.Add(setViewModel);
        }

        public ExerciseViewModel Clone()
        {
            return MemberwiseClone() as ExerciseViewModel;
        }
    }
}
