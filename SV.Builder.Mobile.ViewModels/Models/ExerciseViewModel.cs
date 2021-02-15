using SV.Builder.Core.SharedKernel;
using System.Collections.ObjectModel;

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

        public ObservableCollection<SetViewModel> Sets { get; set; } = new ObservableCollection<SetViewModel>();

        public ExerciseViewModel()
        {
            
        }

        internal void AddSet(SetViewModel setViewModel)
        {
            Duration += setViewModel.Duration;
            Sets.Add(setViewModel);
        }
    }
}
