using NUnit.Framework;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Builder.Domain.Tests.WorkoutTests
{

    public class IWorkoutTests
    {
        private WorkoutFactory _workoutFactory;
        private RoundFactory _roundFactory;

        [SetUp]
        public void Setup()
        {
            _roundFactory = new RoundFactory();
            _workoutFactory = new WorkoutFactory();
        }

        [Test]
        public void AddRound_NewRound_AddsRoundToWorkout()
        {
            bool successfullyAddedRound = true;
            string workoutName = "Workout Name";
            string workoutDescription = "Description";
            string roundName = "Round 1";
            string roundDescription = "Round description";
            int roundIterations = 1;

            var workout = _workoutFactory.CreateWorkout(workoutName, workoutDescription);
            var round = _roundFactory.CreateRound(roundName, roundDescription, roundIterations);

            bool addedRoundResult = workout.AddRound(round);

            Assert.AreEqual(successfullyAddedRound, addedRoundResult);
        }

        [Test]
        public void GetRounds_ReturnsCollection()
        {
            int expectedNumberOfRounds = 1;
            string workoutName = "Workout Name";
            string workoutDescription = "Description";
            string roundName = "Round 1";
            string roundDescription = "Round description";
            int roundIterations = 1;

            var workout = _workoutFactory.CreateWorkout(workoutName, workoutDescription);
            var round = _roundFactory.CreateRound(roundName, roundDescription, roundIterations);

            workout.AddRound(round);

            Assert.AreEqual(expectedNumberOfRounds, workout.GetRounds().Count);
        }
    }
}
