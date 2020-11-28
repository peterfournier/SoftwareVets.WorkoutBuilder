using SoftwareVets.WorkoutBuilder.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SoftwareVets.WorkoutBuilder.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}