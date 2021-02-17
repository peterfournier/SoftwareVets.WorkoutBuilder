using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels;
using SV.Builder.Mobile.ViewModels.Pages;
using SV.Builder.Mobile.ViewModels.Shared;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SV.Builder.Mobile.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateWorkoutPage : CreateWorkoutPageXaml
    {
        public CreateWorkoutPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<RoundViewModel>(this, Messages.GoToCreateExercisePage, addExerciseHandler);
            MessagingCenter.Subscribe<ExerciseViewModel>(this, Messages.GoToEditExercisePage, editExerciseHandler);
            MessagingCenter.Subscribe<CreateWorkoutPageViewModel>(this, Messages.GoToNewRoundPage, goToNewRoundPageHandler);
        }

        ~CreateWorkoutPage()
        {
            MessagingCenter.Unsubscribe<RoundViewModel>(this, Messages.GoToCreateExercisePage);
            MessagingCenter.Unsubscribe<ExerciseViewModel>(this, Messages.GoToEditExercisePage);
            MessagingCenter.Unsubscribe<CreateWorkoutPageViewModel>(this, Messages.GoToNewRoundPage);
            MessagingCenter.Unsubscribe<CreateWorkoutPageViewModel>(this, Messages.GoToEditWorkoutNamePage);
        }

        private async void goToNewRoundPageHandler(CreateWorkoutPageViewModel createWorkoutPageViewModel)
        {
            using (new BusyStatus(createWorkoutPageViewModel))
            {
                await Shell.Current.Navigation.PushModalAsync(new CreateRoundPage());
            }
        }

        private async void addExerciseHandler(RoundViewModel sender)
        {
            using (new BusyStatus(sender))
            {
                await Shell.Current.Navigation.PushModalAsync(new CreateExercisePage(sender));
            }
        }

        private async void editExerciseHandler(ExerciseViewModel sender)
        {
            using (new BusyStatus(sender))
            {
                await Shell.Current.Navigation.PushModalAsync(new EditExercisePage(sender));
            }
        }

    }

    public class CreateWorkoutPageXaml : ContentPageBase<CreateWorkoutPageViewModel> { }
}