﻿using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.Common.Themes;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class SettingsPageViewModel : BaseContentPageViewModel
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
