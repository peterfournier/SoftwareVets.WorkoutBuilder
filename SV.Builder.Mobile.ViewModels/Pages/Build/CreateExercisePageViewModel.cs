using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateExercisePageViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public CreateExercisePageViewModel()
        {

        }
    }
}
