using SV.Builder.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SV.Builder.Mobile.Views
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