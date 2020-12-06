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
    public partial class SettingsPage : SettingsPageXaml
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
    }
    public class SettingsPageXaml : ContentPageBase<SettingsPageViewModel> { }
}