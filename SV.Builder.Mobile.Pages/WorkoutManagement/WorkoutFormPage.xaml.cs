using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels.Shared;
using SV.Builder.Mobile.ViewModels.WorkoutManagement;
using SV.Builder.Mobile.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SV.Builder.Mobile.Views.WorkoutManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutFormPage : WorkoutFormPageXaml
    {
        public WorkoutFormPage(Workout workout)
        {
            BindingContext = new WorkoutFormPageViewModel(workout);
            InitializeComponent();

            //MessagingCenter.Subscribe<RoundViewModel>(this, Messages.GoToCreateExercisePage, addExerciseHandler);
            //MessagingCenter.Subscribe<ExerciseViewModel>(this, Messages.GoToEditExercisePage, editExerciseHandler);
            //MessagingCenter.Subscribe<CreateWorkoutPageViewModel>(this, Messages.GoToNewRoundPage, goToNewRoundPageHandler);
            MessagingCenter.Subscribe<WorkoutFormPageViewModel, Workout>(this, Messages.GoToEditWorkoutNamePage, goToEditWorkoutNamePageHandler);
        }

        ~WorkoutFormPage()
        {
            //MessagingCenter.Unsubscribe<RoundViewModel>(this, Messages.GoToCreateExercisePage);
            //MessagingCenter.Unsubscribe<ExerciseViewModel>(this, Messages.GoToEditExercisePage);
            //MessagingCenter.Unsubscribe<CreateWorkoutPageViewModel>(this, Messages.GoToNewRoundPage);
            MessagingCenter.Unsubscribe<WorkoutFormPageViewModel>(this, Messages.GoToEditWorkoutNamePage);
        }

        private async void goToEditWorkoutNamePageHandler(WorkoutFormPageViewModel sender, Workout workout)
        {
            using (new BusyStatus(sender))
            {
                await Shell.Current.Navigation.PushModalAsync(new EditWorkoutNamePage(workout));
            }
        }
    }

    public class WorkoutFormPageXaml : ContentPageBase { }
}