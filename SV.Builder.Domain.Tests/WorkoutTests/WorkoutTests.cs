using NUnit.Framework;
using System;
using SV.Builder.Domain;

namespace SV.Builder.Domain.Tests.WorkoutTests
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
        public void ChangeName_WithValidInput_IsChanged()
        {
            var workout = new Workout("Workout A");
            var newName = "Pete's awesome workout name";

            workout.ChangeName(newName);

            Assert.AreEqual(newName, workout.Name);
        }

        [TestCase("")]
        public void ChangeName_WithInvalidInput_ThrowsException(string newWorkoutNameParam)
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(changeWorkoutNameDelegate));

            void changeWorkoutNameDelegate()
            {
                var workout = new Workout("Workout A");
                workout.ChangeName(newWorkoutNameParam);
            }
        }
    }
}