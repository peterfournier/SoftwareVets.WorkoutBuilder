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
        }
    }

    public partial class CreateExercisePageXaml : ContentPageBase { }
}