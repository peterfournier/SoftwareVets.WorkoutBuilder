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
                return exerciseSetTemplate;
                //if (setViewModel.ExerciseSet is IntenseEnduranceSet)
                //{
                //    return intenseEnduranceSetTemplate;
                //}
                //else if (setViewModel.ExerciseSet is IntensePerformanceSet)
                //{
                //    return intensePerformanceSetTemplate;
                //}
                //else if (setViewModel.ExerciseSet is EnduranceSet)
                //{
                //    return enduranceSetTemplate;
                //}
                //else if (setViewModel.ExerciseSet is PerformanceSet)
                //{
                //    return performanceSetTemplate;
                //}
                //else if (setViewModel.ExerciseSet is StrengthSet)
                //{
                //    return strengthSetTemplate;
                //}
                //else
                //{
                //    return exerciseSetTemplate;
                //}
            }

            throw new NotImplementedException();
        }
    }
}
