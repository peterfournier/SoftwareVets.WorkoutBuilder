using FluentAssertions;
using NUnit.Framework;
using SV.WorkoutBuilder.Core.SharedKernel;
using SV.WorkoutBuilder.Core.WorkoutManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.WorkoutBuilder.Core.Tests
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
            var workout = new Workout("Workout Name");

            workout.Id.Should().NotBeEmpty();
        }

        [Test]
        public void Create_new_workoutName_is_set()
        {
            var name = "workout name";
            var workout = new Workout(name);

            workout.Name.Should().Be(name);
        }

        [Test]
        public void Create_new_workout_when_name_is_null_throws_exception()
        {
            Action act = () => new Workout(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Add_new_round()
        {
            var name = "workout name";
            var workout = new Workout(name);
            workout.AddRound("Round 1", new List<ExerciseOptions>()
            {

            });

            workout.Rounds.Should().HaveCount(1, "Only added one round");
        }

        [Test]
        public void Add_new_round_exercise_should_be_added()
        {
            var name = "workout name";
            var workout = new Workout(name);
            workout.AddRound("Round 1", createExercisesWithNoSets());

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
            var workout = new Workout(name);

            Action act = () => workout.AddRound(null, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Add_round_when_exercises_are_null_throwsException()
        {
            var name = "workout name";
            var workout = new Workout(name);

            Action act = () => workout.AddRound("Round 1", null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Exercise_duration_increase_withSets()
        {
            var name = "workout name";
            var workout = new Workout(name);

            workout.AddRound("Round 1", createExercisesWithSets());

            workout.EstimatedDuration.Should().Be(workout.Rounds.FirstOrDefault().Exercises.FirstOrDefault().EstimatedDuration);
        }

        [Test]
        public void Round_duration_increase_withSets()
        {
            var name = "workout name";
            var workout = new Workout(name);

            workout.AddRound("Round 1", createExercisesWithSets());

            workout.EstimatedDuration.Should().Be(workout.Rounds.FirstOrDefault().EstimatedDuration);
        }

        [Test]
        public void Workout_duration_increase_with_sets()
        {
            var name = "workout name";
            var workout = new Workout(name);

            workout.AddRound("Round 1", createExercisesWithSets());

            workout.EstimatedDuration.Should().Be(workout.Rounds.FirstOrDefault().Exercises.FirstOrDefault().Sets.FirstOrDefault().Duration);
        }

        [Test]
        public void Workout_duration_increase_with_two_sets()
        {
            var name = "workout name";
            var workout = new Workout(name);

            workout.AddRound("Round 1", createExercisesWithTwoSets());

            workout.EstimatedDuration.Should().Be(Duration.TenMinutes);
        }

        [Test]
        public void Negative_weights_throws_exception()
        {
            Action act = () => createExercisesWithNegativeReps();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}