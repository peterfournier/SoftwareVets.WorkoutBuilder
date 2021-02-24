using SV.Builder.Core.Common;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.Common.MessageCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.WorkoutManagement
{
    public class SetViewModel : BaseViewModel
    {
        public Guid Id => _set.Id;

        private readonly Set _set;

        public static string ZeroSeconds = $"0{secondsSuffix}";
        public static string ZeroMins = $"0{minutesSuffix}";
        public static string ZeroHours = $"0{hoursSuffix}";

        private const string secondsSuffix = " secs";
        private const string minutesSuffix = " mins";
        private const string hoursSuffix = " hrs";

        private bool _stopwatchSet;
        public bool StopwatchSet
        {
            get { return _stopwatchSet; }
            set { SetProperty(ref _stopwatchSet, value); }
        }

        private bool _maxSet;
        public bool MaxSet
        {
            get { return _maxSet; }
            set { SetProperty(ref _maxSet, value); }
        }

        private int _repetitions;
        public int Repetitions
        {
            get { return _repetitions; }
            set { SetProperty(ref _repetitions, value); }
        }

        public Duration Duration => GetDuration();

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

        public List<string> SecondsList { get; set; } = new List<string>();
        public List<string> MinutesList { get; set; } = new List<string>();
        public List<string> HoursList { get; set; } = new List<string>();

        private string _selectedSeconds;
        public string SelectedSeconds
        {
            get { return _selectedSeconds; }
            set
            {
                SetProperty(ref _selectedSeconds, value);
            }
        }

        private string _selectedMinutes;
        public string SelectedMinutes
        {
            get { return _selectedMinutes; }
            set
            {
                SetProperty(ref _selectedMinutes, value);
            }
        }

        private string _selectedHours;
        public string SelectedHours
        {
            get { return _selectedHours; }
            set
            {
                SetProperty(ref _selectedHours, value);
            }
        }

        public SetViewModel(Set set)
        {

            _set = Guard.ForNull(set, nameof(set));
            populateSecondsList();
            populateMinutesList();
            populateHoursList();

            Weight = _set.Weight.ToString();
            MaxSet = _set.MaxSet;
            StopwatchSet = _set.Timed;
            Repetitions = _set.Reps;
            RemoveSetCommand = new Command(new Action(removeSetHandler));
            Name = _set.Name;

            SetSelectedTimeIntervals(_set.Duration);

            PropertyChanged += SetViewModel_PropertyChanged;
        }

        private void SetSelectedTimeIntervals(Duration duration)
        {
            if (SecondsList.Count > 0
                && MinutesList.Count > 0
                && HoursList.Count > 0)
            {
                SelectedSeconds = SecondsList.FirstOrDefault(x => x.Replace(secondsSuffix, "") == duration.Length.Seconds.ToString());
                SelectedMinutes = MinutesList.FirstOrDefault(x => x.Replace(minutesSuffix, "") == duration.Length.Minutes.ToString());
                SelectedHours = HoursList.FirstOrDefault(x => x.Replace(hoursSuffix, "") == duration.Length.Hours.ToString());
            }
        }

        ~SetViewModel()
        {
            PropertyChanged -= SetViewModel_PropertyChanged;
        }
        private void SetViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(StopwatchSet))
            {
                if (StopwatchSet && Duration != Duration.None)
                {
                    SelectedSeconds = ZeroSeconds;
                    SelectedMinutes = ZeroMins;
                    SelectedHours = ZeroHours;
                }
            }
        }

        private void removeSetHandler()
        {
            MessagingCenter.Send(this, Messages.RemoveSetViewModel, this);
        }

        private void populateHoursList()
        {
            for (int i = 0; i < 24; i++)
            {
                HoursList.Add($"{i}{hoursSuffix}");
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
                SecondsList.Add($"{i}{secondsSuffix}");
            }
        }

        private Duration GetDuration()
        {
            int seconds = getSeconds();
            int minutes = getMinutes();
            int hours = getHours();

            return new Duration(hours, minutes, seconds);
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

        public SetOptions GetSetOptions()
        {
            decimal.TryParse(Weight, out decimal weight);

            return new SetOptions(Duration,
                MaxSet ? 0 : Repetitions,
                weight,
                StopwatchSet);
        }

        public void UpdateSet()
        {
            _set.Update(GetSetOptions());
        }
    }
}
