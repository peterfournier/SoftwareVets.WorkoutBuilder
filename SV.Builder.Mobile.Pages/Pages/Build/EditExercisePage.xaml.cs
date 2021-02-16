using SV.Builder.Core.Common;
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
    public partial class EditExercisePage : EditExercisePageXaml
    {
        public EditExercisePage(ExerciseViewModel exerciseViewModel)
        {
            Guard.ForNull(exerciseViewModel, nameof(exerciseViewModel));

            InitializeComponent();

            BindingContext = new EditExercisePageViewModel(exerciseViewModel);
            MessagingCenter.Subscribe<SetViewModel, SetViewModel>(this, Messages.RemoveSetViewModel, removeSetHandler);
        }
        ~EditExercisePage()
        {
            MessagingCenter.Unsubscribe<SetViewModel, SetViewModel>(this, Messages.RemoveSetViewModel);
        }

        // todo base class?
        private async void removeSetHandler(SetViewModel sender, SetViewModel setViewModelArg)
        {
            if (BindingContext is ExercisePageViewModel viewModel)
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

    }

    public partial class EditExercisePageXaml : ContentPageBase { }
}