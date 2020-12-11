﻿using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.Common.Themes;
using SV.Builder.Mobile.Services;
using SV.Builder.Mobile.ViewModels.Pages;
using System;
using Xamarin.Forms;

namespace SV.Builder.Mobile
{
    public partial class App : Application
    {
        public AppTheme AppTheme { get; private set; }
        public App Instance { get; }
        public App()
        {
            Instance = this;

            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();

            setDefaultApplicationTheme();

            Resources.Add(new ThemeResourceDictionary());
        }

        private void setDefaultApplicationTheme()
        {
            applyTheme(new LightTheme());

            addMessageCenterListener();
        }

        private void addMessageCenterListener()
        {
            MessagingCenter.Subscribe<SettingsPageViewModel, AppTheme>(this, Messages.SwitchApplicationTheme, (sender, appTheme) =>
            {
                applyTheme(appTheme);
            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void applyTheme(AppTheme apptheme)
        {
            if (apptheme == null)
                throw new ArgumentNullException(nameof(apptheme));

            AppTheme = apptheme;

            Resources.ApplyTheme(AppTheme);
        }
    }
}
