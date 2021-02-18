using SV.Builder.Mobile.Common.Themes;
using Xamarin.Forms;

namespace SV.Builder.Mobile.Views.Buttons
{
    public abstract class CustomIconButton : ImageButton
    {
        protected abstract string Unicode { get; }
        protected abstract string FontFamily { get; }

        public CustomIconButton()
        {
            SetGlyph();
            Customize(40, 40, 5, 12);
            SetDynamicResource(BackgroundColorProperty, nameof(AppTheme.BackgroundColor));
        }

        protected void SetGlyph()
        {
            this.Source = new FontImageSource()
            {
                FontFamily = FontFamily,
                Glyph = Unicode.Replace("\\u", "$#x"),
                Color = Color.Gray,
                Size = 16,
            };
        }

        public virtual void Customize(int height,
            int width,
            int margin,
            int padding)
        {
            HeightRequest = height;
            WidthRequest = width;
            Margin = margin;
            Padding = padding;
        }
    }
}
