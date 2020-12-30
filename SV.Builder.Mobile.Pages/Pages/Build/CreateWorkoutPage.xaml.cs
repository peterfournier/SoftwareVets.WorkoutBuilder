using SV.Builder.Domain;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels;
using SV.Builder.Mobile.ViewModels.Pages;
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

            MessagingCenter.Subscribe<RoundViewModel, RoundViewModel>(this, Messages.GoToNewExercise, addExerciseHandler);
        }

        private async void WorkoutNameTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (BindingContext is CreateWorkoutPageViewModel createWorkoutPageViewModel)
            {
                var workoutName = createWorkoutPageViewModel.Name.Equals(createWorkoutPageViewModel.DefaultWorkoutName) ? string.Empty : createWorkoutPageViewModel.Name;
                var workoutDescription = createWorkoutPageViewModel.Description.Equals(createWorkoutPageViewModel.DefaultDescription) ? string.Empty : createWorkoutPageViewModel.Description;

                await Shell.Current.Navigation.PushModalAsync(new EditWorkoutNamePage(workoutName, workoutDescription));
            }
        }

        private async void addRoundButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new CreateRoundPage());
        }

        private async void addExerciseHandler(object sender, RoundViewModel roundViewModel)
        {
            await Shell.Current.Navigation.PushModalAsync(new CreateExercisePage(roundViewModel));
        }
    }

    public class CreateWorkoutPageXaml : ContentPageBase<CreateWorkoutPageViewModel> { }
}