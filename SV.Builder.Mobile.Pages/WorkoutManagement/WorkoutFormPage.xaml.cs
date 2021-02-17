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

            //MessagingCenter.Subscribe<ExerciseViewModel>(this, Messages.GoToEditExercisePage, editExerciseHandler);
            //MessagingCenter.Subscribe<CreateWorkoutPageViewModel>(this, Messages.GoToNewRoundPage, goToNewRoundPageHandler);
            MessagingCenter.Subscribe<RoundViewModel, Round>(this, Messages.GoToRoundFormPage, GoToRoundFormPage);
            MessagingCenter.Subscribe<WorkoutFormPageViewModel, Round>(this, Messages.GoToRoundFormPage, GoToRoundFormPage);
            MessagingCenter.Subscribe<WorkoutFormPageViewModel, Workout>(this, Messages.GoToEditWorkoutNamePage, GoToEditWorkoutNamePageHandler);
        }


        ~WorkoutFormPage()
        {
            //MessagingCenter.Unsubscribe<RoundViewModel>(this, Messages.GoToCreateExercisePage);
            //MessagingCenter.Unsubscribe<ExerciseViewModel>(this, Messages.GoToEditExercisePage);
            //MessagingCenter.Unsubscribe<CreateWorkoutPageViewModel>(this, Messages.GoToNewRoundPage);
            MessagingCenter.Unsubscribe<WorkoutFormPageViewModel, Round>(this, Messages.GoToRoundFormPage);
            MessagingCenter.Unsubscribe<WorkoutFormPageViewModel>(this, Messages.GoToEditWorkoutNamePage);
        }
        private async void GoToRoundFormPage(object sender, Round roundArg)
        {
            if (sender is IBusyStatus busy)
            {
                using (new BusyStatus(busy))
                {
                    await Shell.Current.Navigation.PushModalAsync(new RoundFormPage(roundArg));
                }
            }
        }

        private async void GoToEditWorkoutNamePageHandler(WorkoutFormPageViewModel sender, Workout workout)
        {
            using (new BusyStatus(sender))
            {
                await Shell.Current.Navigation.PushModalAsync(new EditWorkoutNamePage(workout));
            }
        }
    }

    public class WorkoutFormPageXaml : ContentPageBase { }
}