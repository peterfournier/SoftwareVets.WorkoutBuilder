using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.ViewModels.Pages;
using SV.Builder.Mobile.ViewModels.WorkoutManagement;
using SV.Builder.Mobile.Views.Shared;
using System;
using Xamarin.Forms.Xaml;

namespace SV.Builder.Mobile.Views.WorkoutManagement
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundFormPage : RoundFormPageXaml
    {
        public RoundFormPage(Round round)
        {
            BindingContext = new RoundFormPageViewModel(round);
            InitializeComponent();
        }
    }

    public class RoundFormPageXaml : ContentPageBase { }
}