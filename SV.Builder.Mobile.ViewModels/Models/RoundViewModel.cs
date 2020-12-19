using SV.Builder.Domain;
using SV.Builder.Mobile.Common.MessageCenter;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels
{
    public class RoundViewModel : BaseViewModel
    {
        private IRound _round;

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public ICommand AddExerciseToRoundCommand { get; set; }

        public RoundViewModel(IRound round)
        {
            AddExerciseToRoundCommand = new Command(addExerciseToRound);
            _round = round;
        }

        private void addExerciseToRound(object arg)
        {
            if (arg is RoundViewModel round)
                MessagingCenter.Send(this, Messages.GoToNewExercise, round);
        }
    }
}
