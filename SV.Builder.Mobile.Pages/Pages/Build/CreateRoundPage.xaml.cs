using SV.Builder.Mobile.ViewModels.Pages;
using Xamarin.Forms.Xaml;

namespace SV.Builder.Mobile.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRoundPage : CreateRoundPageXaml
    {
        public CreateRoundPage()
        {
            InitializeComponent();
        }
    }

    public class CreateRoundPageXaml : ContentPageBase<CreateRoundPageViewModel> { }
}