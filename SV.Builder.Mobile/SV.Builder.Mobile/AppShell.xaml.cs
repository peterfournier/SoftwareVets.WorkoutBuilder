using SV.Builder.Mobile.Views;
using SV.Builder.Mobile.Views.WorkoutManagement;
using System;
using Xamarin.Forms;

namespace SV.Builder.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(CreateRoundPage), typeof(CreateRoundPage));
            Routing.RegisterRoute(nameof(WorkoutFormPage), typeof(WorkoutFormPage));
            //Routing.RegisterRoute(nameof(EditWorkoutNamePage), typeof(EditWorkoutNamePage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
