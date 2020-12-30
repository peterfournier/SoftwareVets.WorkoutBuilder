using SV.Builder.Domain;
using SV.Builder.Mobile.ViewModels;
using Xamarin.Forms;
using System;

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
            enduranceSetTemplate = new DataTemplate(typeof(EnduranceSetDataTemplate));
            exerciseSetTemplate = new DataTemplate(typeof(ExerciseSetDataTemplate));
            intenseEnduranceSetTemplate = new DataTemplate(typeof(IntenseEnduranceSetDataTemplate));
            intensePerformanceSetTemplate = new DataTemplate(typeof(IntensePerformanceSetDataTemplate));
            performanceSetTemplate = new DataTemplate(typeof(PerformanceSetDataTemplate));
            strengthSetTemplate = new DataTemplate(typeof(StrengthSetDataTemplate));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is SetViewModel setViewModel)
            {
                if (setViewModel.ExerciseSet is IIntenseEnduranceSet)
                {
                    return intenseEnduranceSetTemplate;
                }
                else if (setViewModel.ExerciseSet is IIntensePerformanceSet)
                {
                    return intensePerformanceSetTemplate;
                }
                else if (setViewModel.ExerciseSet is IEnduranceSet)
                {
                    return enduranceSetTemplate;
                }
                else if (setViewModel.ExerciseSet is IPerformanceSet)
                {
                    return performanceSetTemplate;
                }
                else if (setViewModel.ExerciseSet is IWeightedSet)
                {
                    return strengthSetTemplate;
                }
                else
                {
                    return exerciseSetTemplate;
                }
            }

            throw new NotImplementedException();
        }
    }
}
