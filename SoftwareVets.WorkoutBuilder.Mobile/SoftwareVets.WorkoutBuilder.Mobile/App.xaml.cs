using SoftwareVets.WorkoutBuilder.Mobile.Common.MessageCenter;
using SoftwareVets.WorkoutBuilder.Mobile.Common.Themes;
using SoftwareVets.WorkoutBuilder.Mobile.Services;
using SoftwareVets.WorkoutBuilder.Mobile.ViewModels.Pages;
using System;
using Xamarin.Forms;

namespace SoftwareVets.WorkoutBuilder.Mobile
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
        }

        private void setDefaultApplicationTheme()
        {
            applyTheme(new DarkTheme());

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
