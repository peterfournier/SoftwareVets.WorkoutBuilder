using Xamarin.Forms;

namespace SoftwareVets.WorkoutBuilder.Mobile.Views.Themes
{
    public static class ThemeResourceDictionaryKeys
    {
        public static string TextColorKey = nameof(TextColorKey);
        public static string BackgroundColorKey = nameof(BackgroundColorKey);
    }

    public class ThemeResourceDictionary : ResourceDictionary
    {

        public ThemeResourceDictionary()
        {
            Add(ThemeResourceDictionaryKeys.TextColorKey, new Color());
            Add(ThemeResourceDictionaryKeys.BackgroundColorKey, new Color());
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
