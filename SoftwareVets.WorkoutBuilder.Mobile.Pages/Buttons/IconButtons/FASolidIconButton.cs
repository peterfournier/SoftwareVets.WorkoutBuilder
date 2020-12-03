namespace SoftwareVets.WorkoutBuilder.Mobile.Views.Buttons
{
    public abstract class FASolidIconButton : CustomIconButton
    {
        public FASolidIconButton()
        {
        }

        protected abstract override string Unicode { get; }

        protected override string FontFamily => "FA-S";

    }
}
