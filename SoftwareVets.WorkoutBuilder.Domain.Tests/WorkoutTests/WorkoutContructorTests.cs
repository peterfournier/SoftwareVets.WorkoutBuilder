using NUnit.Framework;
using System;
using SoftwareVets.WorkoutBuilder.Domain;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests
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
        public void TestConstructor_Name_CannotBeNull_Exception(string param)
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Workout constructor: Name parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Workout(param);
            }
        }

        [TestCase("Workout Name")]
        public void TestConstructor_Name_Is_Set(string param)
        {
            var workout = new Workout(param);

            Assert.AreEqual(param, workout.Name);
        }

        [TestCase("Workout Name")]
        public void TestConstructor_Rounds_Has_Default(string param)
        {
            var workout = new Workout(param);

            Assert.AreEqual(1, workout.Rounds.Count);
        }
    }
}