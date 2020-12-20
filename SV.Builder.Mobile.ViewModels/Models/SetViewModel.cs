using System;
using System.Collections.Generic;

namespace SV.Builder.Mobile.ViewModels
{
    public class SetViewModel : BaseViewModel
    {
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

        private TimeSpan _length;
        public TimeSpan Length
        {
            get { return _length; }
            set { SetProperty(ref _length, value); }
        }

        private double? _weight;
        public double? Weight
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

        public List<string> SecondsList { get; set; } = new List<string>();
        public List<string> MinutesList { get; set; } = new List<string>();
        public List<string> HoursList { get; set; } = new List<string>();

        private string _selectedSeconds;
        public string SelectedSeconds
        {
            get { return _selectedSeconds; }
            set { SetProperty(ref _selectedSeconds, value); }
        }

        private string _selectedMinutes;
        public string SelectedMinutes
        {
            get { return _selectedMinutes; }
            set { SetProperty(ref _selectedMinutes, value); }
        }

        private string _selectedHours;
        public string SelectedHours
        {
            get { return _selectedHours; }
            set { SetProperty(ref _selectedHours, value); }
        }


        public SetViewModel()
        {
            populateSecondsList();
            populateMinutesList();
            populateHoursList();
        }

        private void populateHoursList()
        {
            for (int i = 0; i < 61; i++)
            {
                SecondsList.Add($"{i} secs");
            }
        }

        private void populateMinutesList()
        {
            for (int i = 0; i < 61; i++)
            {
                MinutesList.Add($"{i} mins");
            }
        }

        private void populateSecondsList()
        {
            for (int i = 0; i < 61; i++)
            {
                HoursList.Add($"{i} hours");
            }
        }
    }
}
