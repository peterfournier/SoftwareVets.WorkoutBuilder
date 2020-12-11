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
    public partial class EditWorkoutNamePage : EditWorkoutNamePageXaml
    {
        public EditWorkoutNamePage()
        {
            InitializeComponent();
        }
    }

    public partial class EditWorkoutNamePageXaml : ContentPageBase<EditWorkoutNamePageViewModel> { }
}