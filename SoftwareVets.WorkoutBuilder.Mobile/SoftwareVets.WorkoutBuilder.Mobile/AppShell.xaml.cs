using SoftwareVets.WorkoutBuilder.Mobile.ViewModels;
using SoftwareVets.WorkoutBuilder.Mobile.Views;
using SoftwareVets.WorkoutBuilder.Mobile.Views.Pages;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SoftwareVets.WorkoutBuilder.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CreateWorkoutPage), typeof(CreateWorkoutPage));            
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
