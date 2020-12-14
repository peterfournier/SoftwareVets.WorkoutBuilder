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
    public partial class EditWorkoutNamePage : EditWorkoutNamePageXaml
    {
        public EditWorkoutNamePage(string workoutName, string workoutDescription)
        {
            InitializeComponent();
            var viewModel = new EditWorkoutNamePageViewModel();
            viewModel.Name = workoutName;
            viewModel.Description = workoutDescription;
            BindingContext = viewModel;
        }
    }

    public partial class EditWorkoutNamePageXaml : ContentPageBase { }
}