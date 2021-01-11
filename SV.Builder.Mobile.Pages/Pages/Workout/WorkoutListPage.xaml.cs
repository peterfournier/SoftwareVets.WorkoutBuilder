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
    public partial class WorkoutListPage : WorkoutListPageXaml
    {
        public WorkoutListPage()
        {
            InitializeComponent();
        }
    }

    public partial class WorkoutListPageXaml : ContentPageBase { }
}