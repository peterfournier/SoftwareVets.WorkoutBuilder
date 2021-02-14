using SV.Builder.Mobile.ViewModels;
using Xamarin.Forms;
using System;

namespace SV.Builder.Mobile.Views.Shared
{
    public class ExerciseSetTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate enduranceSetTemplate;
        private readonly DataTemplate exerciseSetTemplate;
        private readonly DataTemplate performanceSetTemplate;
        private readonly DataTemplate strengthEnduranceSetTemplate;
        private readonly DataTemplate strengthPerformanceSetTemplate;
        private readonly DataTemplate strengthSetTemplate;


        public ExerciseSetTemplateSelector()
        {
            enduranceSetTemplate = new DataTemplate(typeof(EnduranceSetDataTemplate));
            exerciseSetTemplate = new DataTemplate(typeof(ExerciseSetDataTemplate));
            performanceSetTemplate = new DataTemplate(typeof(PerformanceSetDataTemplate));
            strengthEnduranceSetTemplate = new DataTemplate(typeof(StrengthEnduranceSetDataTemplate));
            strengthPerformanceSetTemplate = new DataTemplate(typeof(StrengthPerformanceSetDataTemplate));
            strengthSetTemplate = new DataTemplate(typeof(StrengthSetDataTemplate));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is SetViewModel setViewModel)
            {
                switch (setViewModel.GetSetOptions().Type)
                {
                    case Core.SharedKernel.SetType.Performance:
                        return performanceSetTemplate;

                    case Core.SharedKernel.SetType.Endurance:
                        return enduranceSetTemplate;

                    case Core.SharedKernel.SetType.Strength:
                        return strengthSetTemplate;

                    case Core.SharedKernel.SetType.StrengthPerformance:
                        return strengthPerformanceSetTemplate;

                    case Core.SharedKernel.SetType.StrengthEndurance:
                        return strengthEnduranceSetTemplate;

                    case Core.SharedKernel.SetType.None:
                    default:
                        return exerciseSetTemplate;
                }
            }

            throw new NotImplementedException();
        }
    }
}
