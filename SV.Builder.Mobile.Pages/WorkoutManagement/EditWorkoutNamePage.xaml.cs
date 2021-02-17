using SV.Builder.Core.WorkoutManagement;
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
    public partial class EditWorkoutNamePage : EditWorkoutNamePageXaml
    {
        public EditWorkoutNamePage(Workout workout)
        {
            BindingContext = new EditWorkoutNamePageViewModel(workout);
            InitializeComponent();
        }
    }

    public partial class EditWorkoutNamePageXaml : ContentPageBase { }
}