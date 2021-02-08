using GraniteCore;
using SV.Builder.Domain.EntityModels;
using SV.Builder.Mobile.Common.MessageCenter;
using SV.Builder.Mobile.Common.Themes;
using SV.Builder.Mobile.Services;
using SV.Builder.Mobile.ViewModels.Pages;
using SV.Builder.Repository;
using SV.Builder.Service;
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
            DependencyService.Register<IBaseRepository<WorkoutEntity, Guid>, SVLocalRepository<WorkoutEntity, Guid>>();
            DependencyService.Register<IGraniteMapper, SvMapper>();
            DependencyService.Register<LocalWorkoutService>();

            MainPage = new AppShell();

            setDefaultApplicationTheme();

            Resources.Add(new ThemeResourceDictionary());

            setExperimentalFlags();
        }

        private void setExperimentalFlags()
        {
            Device.SetFlags(new string[] { "Expander_Experimental" });
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
