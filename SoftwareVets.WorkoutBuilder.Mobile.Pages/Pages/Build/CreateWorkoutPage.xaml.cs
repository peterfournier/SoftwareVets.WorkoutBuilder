﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareVets.WorkoutBuilder.Mobile.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateWorkoutPage : CreateWorkoutPageXaml
    {
        public CreateWorkoutPage()
        {
            InitializeComponent();
            
        }
    }

    public class CreateWorkoutPageXaml : ContentPageBase { }
}