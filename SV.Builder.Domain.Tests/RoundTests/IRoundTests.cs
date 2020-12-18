using NUnit.Framework;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Builder.Domain.Tests.RoundTests
{
    public class IRoundTests
    {
        private ExerciseFactory _exerciseFactory;
        private RoundFactory _roundFactory;

        [SetUp]
        public void Setup()
        {
            _exerciseFactory = new ExerciseFactory();
            _roundFactory = new RoundFactory();
        }

        [Test]
        public void AddExercise_NewExercise_AddsExerciseToRound()
        {
            string roundName = "Round 1";
            string exerciseName = "Sit ups";
            string roundDescription = null;
            int roundIterations = 0;
            bool successFullyAddedExercise = true;
            var round = _roundFactory.CreateRound(roundName, roundDescription, roundIterations);
            var exercise = _exerciseFactory.CreateExercise(exerciseName);

            var addsRoundSuccess = round.AddExercise(exercise);

            Assert.AreEqual(successFullyAddedExercise, addsRoundSuccess);
        }

        [Test]
        public void GetExercises__ReturnsCollection()
        {
            string roundName = "Round 1";
            string exerciseName = "Sit ups";
            string roundDescription = null;
            int roundIterations = 0;
            int numberOfExpectedExercises = 1;
            var round = _roundFactory.CreateRound(roundName, roundDescription, roundIterations);
            var exercise = _exerciseFactory.CreateExercise(exerciseName);

            round.AddExercise(exercise);

            Assert.AreEqual(numberOfExpectedExercises, round.GetExercises().Count);
        }
    }
}
