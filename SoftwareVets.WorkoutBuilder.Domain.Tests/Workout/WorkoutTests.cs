using NUnit.Framework;
using System;
using SoftwareVets.WorkoutBuilder.Domain;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests
{
    public class WorkoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstruct_Name_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Workout constructor: Name parameter allows nulls");

            void contructWorkoutObject()
            {
                var workout = new Workout("Workout Name");
            }
        }
    }
}