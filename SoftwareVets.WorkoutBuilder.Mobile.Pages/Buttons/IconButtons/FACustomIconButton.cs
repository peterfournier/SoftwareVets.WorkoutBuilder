using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SoftwareVets.WorkoutBuilder.Mobile.Views.Buttons
{
    public abstract class CustomIconButton : ImageButton
    {
        protected abstract string Unicode { get; }
        protected abstract string FontFamily { get; }

        public CustomIconButton()
        {
            SetGlyph();
        }

        protected void SetGlyph()
        {
            this.Source = new FontImageSource()
            {
                FontFamily = FontFamily,
                Glyph = Unicode.Replace("\\u", "$#x"),
                Color = Color.Gray
            };
        }

    }
}
