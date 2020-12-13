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
            
        }

        private async void WorkoutNameTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new EditWorkoutNamePage());
        }

        private async void addRoundButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new CreateRoundPage());
        }
    }

    public class CreateWorkoutPageXaml : ContentPageBase<CreateWorkoutPageViewModel> { }
}