using System;
using Xamarin.Forms;

namespace SoftwareVets.WorkoutBuilder.Mobile.Common.Themes
{
    public static class ThemeResourceDictionaryKeys
    {
        public static string TextColorKey = nameof(TextColorKey);
        public static string BackgroundColorKey = nameof(BackgroundColorKey);

        static ThemeResourceDictionaryKeys()
        {

        }
    }

    public class ThemeResourceDictionary : ResourceDictionary
    {

        public ThemeResourceDictionary()
        {
            Add(ThemeResourceDictionaryKeys.TextColorKey, new Color());
            Add(ThemeResourceDictionaryKeys.BackgroundColorKey, new Color());


            Add(labelStyle());
            Add(stackLayoutStyle());
        }

        private Style labelStyle()
        {
            var style = new Style(typeof(Label));
            style.Setters.AddDynamicResource(Label.TextColorProperty, ThemeResourceDictionaryKeys.TextColorKey);

            return style;
        }
        private Style stackLayoutStyle()
        {
            var style = new Style(typeof(StackLayout));
            style.Setters.AddDynamicResource(StackLayout.BackgroundColorProperty, ThemeResourceDictionaryKeys.BackgroundColorKey);

            return style;
        }
    }

    public static class ResourceDictionaryExtensions
    {
        public static void ApplyTheme(this ResourceDictionary resourceDictionary, AppTheme theme)
        {
            resourceDictionary[ThemeResourceDictionaryKeys.TextColorKey] = theme.TextColor;
            resourceDictionary[ThemeResourceDictionaryKeys.BackgroundColorKey] = theme.BackgroundColor;
        }
    }
}
