using NUnit.Framework;
using System;
using SV.Builder.WorkoutManagement;
using System.Linq;

namespace SV.Builder.WorkoutManagement.Tests.WorkoutTests
{
    public class WorkoutTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Constructor_Name_CannotBeNull_Exception(string param)
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(constructWorkoutObject), "Workout constructor: Name parameter does not allow nulls");

            void constructWorkoutObject()
            {
                _ = new Workout(param);
            }
        }

        [Test]
        public void Workout_NameParamerter_IsSet()
        {
            var workoutName = "Workout Name";
            var workout = new Workout(workoutName);

            Assert.AreEqual(workoutName, workout.Name);
        }

        [Test]
        public void AddRound_NewRound_AddsRoundToWorkout()
        {
            int expectedRoundCount = 1;
            string workoutName = "Workout Name";
            string roundName = "Round 1";

            var workout = new Workout(workoutName);
            var round = new Round(workout.ID, roundName);

            workout.AddRound(round);

            Assert.AreEqual(expectedRoundCount, workout.Rounds.ToList().Count);
        }

        [TestCase("Workout Name")]
        public void AddRound_NewRound_SetsWorkoutIdProperty(string param)
        {
            var workout = new Workout(param);
            var round = new Round(workout.ID, "Round 1");
            workout.AddRound(round);

            Assert.AreEqual(workout.ID, round.WorkoutId);
        }

        [Test]
        public void AddRound_Null_ThrowsException()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(addRoundTest), "AddRound: Round parameter does not allow nulls");

            void addRoundTest()
            {
                var workout = new Workout("Workout 1");
                workout.AddRound(null);
            }
        }
    }
}