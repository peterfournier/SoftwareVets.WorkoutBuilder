using FluentAssertions;
using NUnit.Framework;
using SV.Builder.Core.SharedKernel;
using SV.Builder.Core.WorkoutManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.Builder.Core.Tests
{
    public class WorkoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create_new_workout_Id_is_set()
        {
            var workout = new Workout("Workout Name", "Description");

            workout.Id.Should().NotBeEmpty();
        }

        [Test]
        public void Create_new_workoutName_is_set()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");

            workout.Name.Should().Be(name);
        }

        [Test]
        public void Create_new_workout_when_name_is_null_throws_exception()
        {
            Action act = () => new Workout(null, "Description");

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Add_new_round()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");
            workout.AddRound(new RoundOptions("Round 1", "Description", 1, new List<ExerciseOptions>()
            {

            }));

            workout.Rounds.Should().HaveCount(1, "Only added one round");
        }

        [Test]
        public void Add_new_round_exercise_should_be_added()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");
            workout.AddRound(new RoundOptions("name", "description", 1, createExercisesWithNoSets()));

            workout.Rounds.FirstOrDefault().Exercises.Should().HaveCount(1, "Only added one exercise");
        }

        private static List<ExerciseOptions> createExercisesWithNoSets()
        {
            return new List<ExerciseOptions>()
            {
                new ExerciseOptions("Push ups", "push your body up", new List<SetOptions>()
                {

                })
            };
        }

        private static List<ExerciseOptions> createExercisesWithSets()
        {
            return new List<ExerciseOptions>()
            {
                new ExerciseOptions("Push ups", "push your body up", new List<SetOptions>()
                {
                    new SetOptions(Duration.FiveMinutes, 10)
                })
            };
        }

        private static List<ExerciseOptions> createExercisesWithTimedSet()
        {
            return new List<ExerciseOptions>()
            {
                new ExerciseOptions("Push ups", "push your body up", new List<SetOptions>()
                {
                    new SetOptions(Duration.FiveMinutes, 10, timed: true)
                })
            };
        }

        private static List<ExerciseOptions> createExercisesWithTwoSets()
        {
            return new List<ExerciseOptions>()
            {
                new ExerciseOptions("Push ups", "push your body up", new List<SetOptions>()
                {
                    new SetOptions(Duration.FiveMinutes, 10),
                    new SetOptions(Duration.FiveMinutes, 10)
                })
            };
        }

        private static List<ExerciseOptions> createExercisesWithNegativeReps()
        {
            return new List<ExerciseOptions>()
            {
                new ExerciseOptions("Push ups", "push your body up", new List<SetOptions>()
                {
                    new SetOptions(Duration.FiveMinutes, -1),
                })
            };
        }

        [Test]
        public void Add_round_when_roundName_is_null_throwsException()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");

            Action act = () => new RoundOptions(null, "Description", 1, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void When_exercises_are_null_throwsException()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");
            Action act = () => new RoundOptions("Round 1", "Description", 1, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Exercise_duration_increase_withSets()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");

            var roundOptions = new RoundOptions("Round 1", "Description", 1, createExercisesWithSets());
            workout.AddRound(roundOptions);

            workout.EstimatedDuration.Should().Be(workout.Rounds.FirstOrDefault().Exercises.FirstOrDefault().EstimatedDuration);
        }

        [Test]
        public void Round_duration_increase_withSets()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");

            var roundOptions = new RoundOptions("Round 1", "Description", 1, createExercisesWithSets());
            workout.AddRound(roundOptions);

            workout.EstimatedDuration.Should().Be(workout.Rounds.FirstOrDefault().EstimatedDuration);
        }

        [Test]
        public void Workout_duration_increase_with_sets()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");

            var roundOptions = new RoundOptions("Round 1", "Description", 1, createExercisesWithSets());
            workout.AddRound(roundOptions);

            workout.EstimatedDuration.Should().Be(workout.Rounds.FirstOrDefault().Exercises.FirstOrDefault().Sets.FirstOrDefault().Duration);
        }

        [Test]
        public void Workout_duration_increase_with_two_sets()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");

            var roundOptions = new RoundOptions("Round 1", "Description", 1, createExercisesWithTwoSets());
            workout.AddRound(roundOptions);

            workout.EstimatedDuration.Should().Be(Duration.TenMinutes);
        }

        [Test]
        public void Negative_weights_throws_exception()
        {
            Action act = () => createExercisesWithNegativeReps();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void If_timed_set_duration_must_be_zero()
        {
            Action act = () => createExercisesWithTimedSet();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Add_round_with_options()
        {
            var name = "workout name";
            var workout = new Workout(name, "Description");
            var roundOptions = new RoundOptions("Round 1", "Description", 1, createExercisesWithTwoSets());
            workout.AddRound(roundOptions);

            workout.EstimatedDuration.Should().Be(Duration.TenMinutes);
        }
    }
}