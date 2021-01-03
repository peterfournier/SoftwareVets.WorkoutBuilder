using SV.Builder.Domain;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels;
using SV.Builder.Mobile.ViewModels.Pages;
using SV.Builder.Mobile.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            MessagingCenter.Subscribe<RoundViewModel, RoundViewModel>(this, Messages.GoToNewExercisePage, addExerciseHandler);
            MessagingCenter.Subscribe<CreateWorkoutPageViewModel>(this, Messages.GoToNewRoundPage, goToNewRoundPageHandler);
            MessagingCenter.Subscribe<CreateWorkoutPageViewModel>(this, Messages.GoToEditWorkoutNamePage, goToEditWorkoutNamePageHandler);
        }

        private async void goToEditWorkoutNamePageHandler(CreateWorkoutPageViewModel createWorkoutPageViewModel)
        {
            using (new BusyStatus(createWorkoutPageViewModel))
            {
                var workoutName = createWorkoutPageViewModel.Name.Equals(createWorkoutPageViewModel.DefaultWorkoutName) ? string.Empty : createWorkoutPageViewModel.Name;
                var workoutDescription = createWorkoutPageViewModel.Description.Equals(createWorkoutPageViewModel.DefaultDescription) ? string.Empty : createWorkoutPageViewModel.Description;

                await Shell.Current.Navigation.PushModalAsync(new EditWorkoutNamePage(workoutName, workoutDescription));
            }
        }

        private async void goToNewRoundPageHandler(CreateWorkoutPageViewModel createWorkoutPageViewModel)
        {
            using (new BusyStatus(createWorkoutPageViewModel))
            {
                await Shell.Current.Navigation.PushModalAsync(new CreateRoundPage());
            }
        }

        private async void addExerciseHandler(object sender, RoundViewModel roundViewModel)
        {
            using (new BusyStatus(roundViewModel))
            {
                await Shell.Current.Navigation.PushModalAsync(new CreateExercisePage(roundViewModel));
            }
        }
    }

    public class CreateWorkoutPageXaml : ContentPageBase<CreateWorkoutPageViewModel> { }
}