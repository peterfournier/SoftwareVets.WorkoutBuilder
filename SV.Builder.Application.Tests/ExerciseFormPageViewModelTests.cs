using FluentAssertions;
using NUnit.Framework;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Core.WorkoutManagement;
using SV.Builder.Mobile.ViewModels.WorkoutManagement;
using System.Linq;

namespace SV.Builder.Application.Tests
{
    public class ExerciseFormPageViewModelTests
    {
        private Workout _workout;
        private Round _round;
        private Exercise _exercse;

        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1", "Description");
            _round = new Round(_workout, "Round 1", "Description", 1);
            _exercse = new Exercise(_round);
        }

        [Test]
        public void Constructor_name_and_description_is_set()
        {
            var pageVM = new ExerciseFormPageViewModel(_exercse);

            pageVM.Name.Should().Be(Exercise.DefaultName);
            pageVM.Description.Should().Be(Exercise.DefaultDescription);

        }

        [Test]
        public void Constructor_default_set_is_added()
        {
            var pageVM = new ExerciseFormPageViewModel(_exercse);
            pageVM.Sets.Count.Should().Be(1);
        }

        [Test]
        public void AddSet_set_name_is_valid()
        {
            var pageVM = new ExerciseFormPageViewModel(_exercse);

            pageVM.Sets.FirstOrDefault().Name.Should().Be("Set 1");
        }

        [Test]
        public void Set_duration_and_Id_change_persists()
        {
            _exercse.AddSet(new Set(_exercse, SetOptions.New));
            var pageVM = new ExerciseFormPageViewModel(_exercse);

            var setViewModel = pageVM.Sets.FirstOrDefault();
            setViewModel.SelectedMinutes = "7 mins";
            Duration expected = new Duration(0, 7, 0);

            pageVM.OnSaveCommand();
            var set = _exercse.Sets.FirstOrDefault();
            set.Duration.Should().Be(expected);
            setViewModel.Id.Should().Be(set.Id);
        }

        [Test]
        public void AddSet_duration_change_persists()
        {
            _exercse.AddSet(new Set(_exercse, SetOptions.New));
            var pageVM = new ExerciseFormPageViewModel(_exercse);
            pageVM.AddSetCommand.Execute(null);

            pageVM.OnSaveCommand();

            _exercse.Sets.Count.Should().Be(2);
        }

        [Test]
        public void Remove_set()
        {
            var set1 = new Set(_exercse, SetOptions.New);
            var set2 = new Set(_exercse, SetOptions.New);
            _exercse.AddSet(set1);
            _exercse.AddSet(set2);
            var pageVM = new ExerciseFormPageViewModel(_exercse);

            var setViewModel = pageVM.Sets.Last();
            pageVM.RemoveSet(setViewModel);

            pageVM.Sets.Count.Should().Be(1);
        }

        [Test]
        public void Remove_set_after_save()
        {
            var set1 = new Set(_exercse, SetOptions.New);
            var set2 = new Set(_exercse, SetOptions.New);
            _exercse.AddSet(set1);
            _exercse.AddSet(set2);
            var pageVM = new ExerciseFormPageViewModel(_exercse);

            var setViewModel = pageVM.Sets.Last();
            pageVM.RemoveSet(setViewModel);

            pageVM.OnSaveCommand();

            _exercse.Sets.Count.Should().Be(1);
        }
    }
}
