using FluentAssertions;
using NUnit.Framework;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.ViewModels.WorkoutManagement;

namespace SV.Builder.Application.Tests
{
    public class SetViewModelTests
    {
        private Workout _workout;
        private Round _round;
        private Exercise _exercse;

        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1", "Description");
            _round = new Round(_workout, "Round 1", "Description", 1);
            _exercse = new Exercise(_round, "Push-ups", "Many as you can");
        }

        [Test]
        public void Default_SetViewModel_Initialize()
        {
            var set = new Set(_exercse, SetOptions.New);
            var setViewModel = new SetViewModel(set);

            setViewModel.Duration.Should().Be(Duration.None);
            setViewModel.MaxSet.Should().Be(false);
            setViewModel.Repetitions.Should().Be(1);
            setViewModel.SelectedHours.Should().Be("0 hrs");
            setViewModel.SelectedMinutes.Should().Be("0 mins");
            setViewModel.SelectedSeconds.Should().Be("0 secs");
            setViewModel.StopwatchSet.Should().Be(false);
            setViewModel.Weight.Should().Be("0");
        }

        [Test]
        public void SetViewModel_with_options_initializes()
        {
            var duration = new Duration(1, 5, 33);
            var set = new Set(_exercse, new SetOptions(duration, 10, 135));
            var setViewModel = new SetViewModel(set);

            setViewModel.Duration.Should().Be(duration);
            setViewModel.MaxSet.Should().Be(false);
            setViewModel.Repetitions.Should().Be(10);
            setViewModel.SelectedHours.Should().Be("1 hrs");
            setViewModel.SelectedMinutes.Should().Be("5 mins");
            setViewModel.SelectedSeconds.Should().Be("33 secs");
            setViewModel.StopwatchSet.Should().Be(false);
            setViewModel.Weight.Should().Be("135");
        }

        [Test]
        public void Minutes_changes_updates_duration()
        {
            var duration = new Duration(1, 5, 33);
            var set = new Set(_exercse, new SetOptions(duration, 10, 135));
            var setViewModel = new SetViewModel(set);

            setViewModel.SelectedMinutes = "7 mins";
            setViewModel.SelectedSeconds = "30 secs";
            setViewModel.SelectedHours = "0 hrs";

            setViewModel.SelectedMinutes.Should().Be("7 mins");
            setViewModel.Duration.Should().Be(new Duration(0, 7, 30));
        }

        [Test]
        public void Switching_to_timed_set_zeros_out_duration()
        {
            var duration = new Duration(1, 5, 33);
            var set = new Set(_exercse, new SetOptions(duration, 10, 135));
            var setViewModel = new SetViewModel(set);
            setViewModel.StopwatchSet = true;

            setViewModel.Duration.Should().Be(Duration.None);
        }

        [Test]
        public void Switching_to_()
        {
            var set = new Set(_exercse, new SetOptions(Duration.None,1, 0));
            var setViewModel = new SetViewModel(set);
            setViewModel.SelectedMinutes = "7 mins";
            setViewModel.SelectedMinutes.Should().Be("7 mins");
            setViewModel.StopwatchSet.Should().Be(false);
        }
    }
}