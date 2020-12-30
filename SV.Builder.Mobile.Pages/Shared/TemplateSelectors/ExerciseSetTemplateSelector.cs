using SV.Builder.Domain;
using Xamarin.Forms;

namespace SV.Builder.Mobile.Views.Shared
{
    public class ExerciseSetTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate exerciseSetTemplate;
        private readonly DataTemplate strengthSetTemplate;
        private readonly DataTemplate performanceSetTemplate;
        private readonly DataTemplate intensePerformanceSetTemplate;
        private readonly DataTemplate enduranceSetTemplate;
        private readonly DataTemplate intenseEnduranceSetTemplate;


        public ExerciseSetTemplateSelector()
        {
            exerciseSetTemplate = new DataTemplate(typeof(ExerciseSetDataTemplate));
            strengthSetTemplate = new DataTemplate(typeof(StrengthSetDataTemplate));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is IWeightedSet)
                return strengthSetTemplate;

            return exerciseSetTemplate;
        }
    }
}
