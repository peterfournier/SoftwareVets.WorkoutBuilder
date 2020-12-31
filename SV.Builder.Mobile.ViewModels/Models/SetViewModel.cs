using SV.Builder.Domain;
using SV.Builder.Mobile.Common.MessageCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels
{
    public class SetViewModel : BaseViewModel
    {
        private const string secondsSuffix = " secs";
        private const string minutesSuffix = " mins";
        private const string hoursSuffix = " hrs";

        private bool _stopwatchSet;
        public bool StopwatchSet
        {
            get { return _stopwatchSet; }
            set { SetProperty(ref _stopwatchSet, value); }
        }

        private int _repetitions = 1;
        public int Repetitions
        {
            get { return _repetitions; }
            set { SetProperty(ref _repetitions, value); }
        }

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            private set { SetProperty(ref _duration, value); }
        }

        private string _weight;
        public string Weight
        {
            get { return _weight; }
            set { SetProperty(ref _weight, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private ICommand _removeSetCommand;
        public ICommand RemoveSetCommand
        {
            get { return _removeSetCommand; }
            set { SetProperty(ref _removeSetCommand, value); }
        }

        public IExerciseSet ExerciseSet { get; private set; }

        public List<string> SecondsList { get; set; } = new List<string>();
        public List<string> MinutesList { get; set; } = new List<string>();
        public List<string> HoursList { get; set; } = new List<string>();

        private string _selectedSeconds;
        public string SelectedSeconds
        {
            get { return _selectedSeconds; }
            set
            {
                if (SetProperty(ref _selectedSeconds, value))
                {
                    setDuration();
                }
            }
        }

        private string _selectedMinutes;
        public string SelectedMinutes
        {
            get { return _selectedMinutes; }
            set
            {
                if (SetProperty(ref _selectedMinutes, value))
                {
                    setDuration();
                }
            }
        }

        private string _selectedHours;
        public string SelectedHours
        {
            get { return _selectedHours; }
            set
            {
                if (SetProperty(ref _selectedHours, value))
                {
                    setDuration();
                }
            }
        }

        public SetViewModel()
        {
            populateSecondsList();
            populateMinutesList();
            populateHoursList();
            RemoveSetCommand = new Command(new Action(removeSetHandler));
        }

        private void removeSetHandler()
        {
            MessagingCenter.Send(this, Messages.RemoveSetViewModel, this);
        }

        internal void SetExerciseSet(IExerciseSet exerciseSet)
        {
            if (ExerciseSet == null)
            {
                ExerciseSet = exerciseSet;
            }
        }

        private void populateHoursList()
        {
            for (int i = 0; i < 61; i++)
            {
                SecondsList.Add($"{i}{secondsSuffix}");
            }
        }

        private void populateMinutesList()
        {
            for (int i = 0; i < 61; i++)
            {
                MinutesList.Add($"{i}{minutesSuffix}");
            }
        }

        private void populateSecondsList()
        {
            for (int i = 0; i < 61; i++)
            {
                HoursList.Add($"{i}{hoursSuffix}");
            }
        }

        private void setDuration()
        {
            int seconds = getSeconds();
            int minutes = getMinutes();
            int hours = getHours();

            Duration = new TimeSpan(hours, minutes, seconds);
        }

        private int getHours()
        {
            return getTimeInteral(HoursList, SelectedHours, hoursSuffix);
        }

        private int getMinutes()
        {
            return getTimeInteral(MinutesList, SelectedMinutes, minutesSuffix);
        }

        private int getSeconds()
        {
            return getTimeInteral(SecondsList, SelectedSeconds, secondsSuffix);
        }

        private int getTimeInteral(List<string> timeUnitList,
            string selectedValue,
            string suffixToRemove)
        {
            var selected = timeUnitList.FirstOrDefault(x => x == selectedValue);
            if (selected != null)
            {
                int.TryParse(selected.Replace(suffixToRemove, ""), out int unit);
                return unit;
            }
            return 0;
        }
    }
}
