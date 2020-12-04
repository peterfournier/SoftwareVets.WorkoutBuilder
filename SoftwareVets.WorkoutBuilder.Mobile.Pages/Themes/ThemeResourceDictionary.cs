using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SoftwareVets.WorkoutBuilder.Mobile.Views.Themes
{
    public class ThemeResourceDictionary : ResourceDictionary
    {
        private string TextColorKey = nameof(TextColorKey);
        private string BackgroundColorKey = nameof(BackgroundColorKey);

        public ThemeResourceDictionary()
        {
            Add(TextColorKey, new Color());
            Add(BackgroundColorKey, new Color());
        }

        internal void ApplyTheme(AppTheme theme)
        {
            this[TextColorKey] = theme.TextColor;
            this[BackgroundColorKey] = theme.BackgroundColor;
            this["Test"] = Color.Red;
        }
    }
}
