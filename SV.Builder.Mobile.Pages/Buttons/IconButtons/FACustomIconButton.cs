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
            HeightRequest = 40;
            WidthRequest = 40;
            BackgroundColor = Color.Transparent;
            Margin = 5;
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

    }
}
