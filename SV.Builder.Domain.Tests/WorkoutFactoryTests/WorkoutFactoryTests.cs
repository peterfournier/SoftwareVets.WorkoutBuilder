using NUnit.Framework;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain.Tests.WorkoutFactoryTests
{
    public class WorkoutFactoryTests
    {
        private WorkoutFactory _workoutFactory;

        [SetUp]
        public void Setup()
        {
            _workoutFactory = new Factories.WorkoutFactory();
        }

        [Test]
        public void Test_CreateNewWorkout()
        {

            var workoutName = "Workout A";
            var workoutDescription = "Test";

            var workout = _workoutFactory.CreateWorkout(workoutName, workoutDescription);

            Assert.IsNotNull(workout);
        }

        [Test]
        public void Test_CreateNewWorkout_Name_IsEqual()
        {
            var workoutFactory = new Factories.WorkoutFactory();

            var workoutName = "Workout A";
            var workoutDescription = "Test";

            var workout = workoutFactory.CreateWorkout(workoutName, workoutDescription);

            Assert.AreEqual(workoutName, workout.Name);
        }

        [Test]
        public void Test_CreateNewWorkout_Description_IsEqual()
        {
            var workoutFactory = new Factories.WorkoutFactory();

            var workoutName = "Workout A";
            var workoutDescription = "Test";

            var workout = workoutFactory.CreateWorkout(workoutName, workoutDescription);

            Assert.AreEqual(workoutDescription, workout.Description);
        }
    }
}
