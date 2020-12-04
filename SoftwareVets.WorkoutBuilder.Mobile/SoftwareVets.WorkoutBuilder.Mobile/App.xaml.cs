using SoftwareVets.WorkoutBuilder.Mobile.Services;
using SoftwareVets.WorkoutBuilder.Mobile.Views;
using SoftwareVets.WorkoutBuilder.Mobile.Views.Themes;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoftwareVets.WorkoutBuilder.Mobile
{
    public partial class App : Application
    {
        public AppTheme AppTheme { get; private set; }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();

            setDefaultApplicationTheme();

            MainPage = new AppShell();

        }

        private void setDefaultApplicationTheme()
        {
            ApplyTheme(new DarkTheme());
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

        private void ApplyTheme(AppTheme apptheme)
        {
            if (apptheme == null)
                throw new ArgumentNullException(nameof(apptheme));

            AppTheme = apptheme;

            Resources.ApplyTheme(AppTheme);
        }
    }
}
