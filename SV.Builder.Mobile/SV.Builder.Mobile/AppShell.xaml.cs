using SV.Builder.Mobile.ViewModels;
using SV.Builder.Mobile.Views;
using SV.Builder.Mobile.Views.Pages;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SV.Builder.Mobile
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
