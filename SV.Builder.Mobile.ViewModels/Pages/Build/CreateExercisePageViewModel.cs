using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateExercisePageViewModel : BaseContentPageViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<SetViewModel> Sets { get; set; } = new ObservableCollection<SetViewModel>();

        public ICommand AddSetCommand { get; set; }

        public CreateExercisePageViewModel()
        {
            addSet(null);
            AddSetCommand = new Command(addSet);
        }

        private void addSet(object sender)
        {
            Sets.Add(new SetViewModel()
            {
                Name = $"Set {Sets.Count + 1}"
            });
        }
    }
}
