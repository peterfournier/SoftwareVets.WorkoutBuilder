using NUnit.Framework;
using SV.Builder.WorkoutManagement;
using System;
using System.Linq;

namespace SV.Builder.WorkoutManagement.Tests.RoundTests
{
    public class RoundTests
    {
        private Workout workout;

        [SetUp]
        public void Setup()
        {
            workout = new Workout("Workout 1");
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Constructor_NameWhenNull_ThrowsException(string param)
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Round constructor: Name parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Round(workout.ID, param);
            }
        }

        [TestCase("Round 1")]
        public void Constructor_NameIsSet(string param)
        {
            var round = new Round(workout.ID, param);

            Assert.AreEqual(param, round.Name);
        }

        [Test]
        public void AddExercise_NewExercise_AddsExerciseToRound()
        {
            string roundName = "Round 1";
            string exerciseName = "Sit ups";
            var round = new Round(workout.ID, roundName);
            var exercise = new Exercise(round.ID, exerciseName);

            round.AddExercise(exercise);

            int expectedExercises = 1;
            Assert.AreEqual(expectedExercises, round.Exercises.ToList().Count);
        }
    }
}
