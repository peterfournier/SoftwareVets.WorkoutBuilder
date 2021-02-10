using SV.Builder.Mobile.ViewModels.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace SV.Builder.Mobile.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRoundPage : CreateRoundPageXaml
    {
        public CreateRoundPage(Guid workoutId)
        {
            InitializeComponent();
            BindingContext = new CreateRoundPageViewModel(workoutId);
        }
    }

    public class CreateRoundPageXaml : ContentPageBase { }
}