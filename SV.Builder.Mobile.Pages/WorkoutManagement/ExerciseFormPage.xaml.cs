using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.ViewModels;
using SV.Builder.Mobile.ViewModels.WorkoutManagement;
using SV.Builder.Mobile.Views.Shared;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SV.Builder.Mobile.Views.WorkoutManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseFormPage : ExerciseFormPageXaml
    {
        public ExerciseFormPage(Exercise exercise)
        {
            InitializeComponent();

            BindingContext = new ExerciseFormPageViewModel(exercise);
            //MessagingCenter.Subscribe<SetViewModel, SetViewModel>(this, Messages.RemoveSetViewModel, removeSetHandler);
        }
        ~ExerciseFormPage()
        {
            //MessagingCenter.Unsubscribe<SetViewModel, SetViewModel>(this, Messages.RemoveSetViewModel);
        }

        //private async void removeSetHandler(SetViewModel sender, SetViewModel setViewModelArg)
        //{
        //    if (BindingContext is CreateExercisePageViewModel viewModel)
        //    {
        //        if (viewModel.ExerciseViewModel.Sets.Count > 1)
        //        {
        //            if (await DisplayAlert("Comfirm", "Are you sure you want to remove this set?", "Yes Remove", "Cancel"))
        //            {
        //                viewModel.RemoveSet(setViewModelArg);
        //            }
        //        }
        //        else
        //        {
        //            await DisplayAlert("Nope", "Exercises must have at least 1 set", "Got it");
        //        }
        //    }
        //}
        
    }

    public partial class ExerciseFormPageXaml : ContentPageBase { }
}