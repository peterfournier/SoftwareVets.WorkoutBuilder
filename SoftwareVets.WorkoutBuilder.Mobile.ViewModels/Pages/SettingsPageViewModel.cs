using SoftwareVets.WorkoutBuilder.Mobile.Common.MessageCenter;
using SoftwareVets.WorkoutBuilder.Mobile.Common.Themes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SoftwareVets.WorkoutBuilder.Mobile.ViewModels.Pages
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public Command OnLightModeCommand { get; }
        public Command OnDarkModeCommand { get; }


        public SettingsPageViewModel()
        {
            OnLightModeCommand = new Command(onLightModeCommand);
            OnDarkModeCommand = new Command(onDarkModeCommand);
        }

        private void onDarkModeCommand(object obj)
        {
            MessagingCenter.Send<SettingsPageViewModel, AppTheme>(this, Messages.SwitchApplicationTheme, new DarkTheme());
        }

        private void onLightModeCommand(object obj)
        {
            MessagingCenter.Send<SettingsPageViewModel, AppTheme>(this, Messages.SwitchApplicationTheme, new LightTheme());
        }
    }
}
