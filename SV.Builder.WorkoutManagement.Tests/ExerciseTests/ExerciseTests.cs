using NUnit.Framework;
using SV.Builder.WorkoutManagement;
using System;

namespace SV.Builder.WorkoutManagement.Tests.ExerciseTests
{
    public class ExerciseTests
    {
        private Workout _workout;
        private Round _round;

        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1");
            _round = new Round(_workout.ID, "Round 1");
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Constructor_NameWhenCannotBeNull_ThrowsException(string param)
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Round constructor: exerciseName parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Exercise(_round.ID, param);
            }
        }

        [TestCase("Exercise 1")]
        public void Constructor_NameIsSet(string param)
        {
            var exercise = new Exercise(_round.ID, param);

            Assert.AreEqual(param, exercise.Name);
        }
    }
}
