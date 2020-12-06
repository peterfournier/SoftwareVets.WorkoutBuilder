using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SV.Builder.Mobile.Views.Partial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormTitleBar : Grid
    {
        //private string _title;
        //public string Title
        //{
        //    get => _title;
        //    set => SetProperty(ref _title, value);
        //}

        public string Title { get; set; }
        public FormTitleBar()
        {
            InitializeComponent();
        }

        //protected bool SetProperty<T>(ref T backingStore, T value,
        //    [CallerMemberName] string propertyName = "",
        //    Action onChanged = null)
        //{
        //    if (EqualityComparer<T>.Default.Equals(backingStore, value))
        //        return false;

        //    backingStore = value;
        //    onChanged?.Invoke();
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}
    }
}