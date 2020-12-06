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
    public partial class GettingStarted : ContentPage
    {
        public GettingStarted()
        {
            InitializeComponent();
        }

        private async void buildWorkout_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushModalAsync(new CreateWorkoutPage());
        }
    }
}