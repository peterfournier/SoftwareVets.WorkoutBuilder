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
    public partial class CreateExercisePage : CreateExercisePageXaml
    {
        public CreateExercisePage(RoundViewModel roundViewModel)
        {
            if (roundViewModel == null)
                throw new ArgumentNullException(nameof(roundViewModel));

            InitializeComponent();

            BindingContext = new CreateExercisePageViewModel(roundViewModel);
            MessagingCenter.Subscribe<SetViewModel, SetViewModel>(this, Messages.RemoveSetViewModel, removeSetHandler);
        }

        private async void removeSetHandler(SetViewModel sender, SetViewModel setViewModelArg)
        {
            if (BindingContext is CreateExercisePageViewModel viewModel)
            {
                if (viewModel.ExerciseViewModel.Sets.Count > 1)
                {
                    if (await DisplayAlert("Comfirm", "Are you sure you want to remove this set?", "Yes Remove", "Cancel"))
                    {
                        viewModel.RemoveSet(setViewModelArg);
                    }
                }
                else
                {
                    await DisplayAlert("Nope", "Exercises must have at least 1 set", "Got it");
                }
            }
        }
        ~CreateExercisePage()
        {
            MessagingCenter.Unsubscribe<SetViewModel, SetViewModel>(this, Messages.RemoveSetViewModel);
        }
    }

    public partial class CreateExercisePageXaml : ContentPageBase { }
}