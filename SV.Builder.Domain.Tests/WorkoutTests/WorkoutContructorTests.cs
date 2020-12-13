using NUnit.Framework;
using System;
using SV.Builder.Domain;

namespace SV.Builder.Domain.Tests.WorkoutTests
{
    public class WorkoutContructorTests
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
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Workout constructor: Name parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Workout(param);
            }
        }

        [TestCase("Workout Name")]
        public void Workout_NameParamerter_IsSet(string param)
        {
            var workout = new Workout(param);

            Assert.AreEqual(param, workout.Name);
        }
    }
}