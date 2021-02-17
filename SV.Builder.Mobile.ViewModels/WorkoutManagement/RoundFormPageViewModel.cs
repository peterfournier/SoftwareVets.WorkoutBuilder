using SV.Builder.Core.Common;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Pages;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class RoundFormPageViewModel : BaseFormContentPageViewModel
    {
        private readonly Round _round;

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

        private string _iterations;
        public string Iterations
        {
            get { return _iterations; }
            set { SetProperty(ref _iterations, value); }
        }

        public RoundFormPageViewModel(Round round)
        {
            _round = Guard.ForNull(round, nameof(round));
            Name = _round.Name;
            Description = _round.Description;
            Iterations = _round.Iterations.ToString();
        }

        public override void OnSaveCommand()
        {
            int.TryParse(Iterations, out int iterations);
            _round.Update(Name, Description, iterations);
            
            MessagingCenter.Send(this, Messages.RoundUpdated);

            base.OnSaveCommand();
        }

    }
}
