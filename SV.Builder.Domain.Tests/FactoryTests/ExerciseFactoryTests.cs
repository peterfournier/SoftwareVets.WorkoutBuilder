using NUnit.Framework;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain.Tests.FactoryTests
{
    public class ExerciseFactoryTests
    {
        private ExerciseFactory _exerciseFactory;

        [SetUp]
        public void Setup()
        {
            _exerciseFactory = new ExerciseFactory();
        }

        [Test]
        public void CreateExercise_WithValidInput_CreatesExercise()
        {

            var exerciseName = "Sit ups";

            var exercise = _exerciseFactory.CreateExercise(exerciseName);

            Assert.IsNotNull(exercise);
        }

    //    [Test]
    //    public void Test_CreateNewRound_Name_IsEqual()
    //    {
    //        var roundName = "Round 1";
    //        var roundDescription = "Testing description";

    //        var round = _roundFactory.CreateRound(roundName, roundDescription, 0);

    //        Assert.AreEqual(roundName, round.Name);
    //    }

    //    [Test]
    //    public void Test_CreateNewRound_Description_IsEqual()
    //    {
    //        var roundName = "Round 1";
    //        var roundDescription = "Testing description";

    //        var round = _roundFactory.CreateRound(roundName, roundDescription, 0);

    //        Assert.AreEqual(roundDescription, round.Description);
    //    }

    //    [Test]
    //    public void Test_CreateNewRound_Iterations_IsEqual()
    //    {
    //        var roundName = "Round 1";
    //        var roundDescription = "Testing description";
    //        var roundIterations = 2;

    //        var round = _roundFactory.CreateRound(roundName, roundDescription, roundIterations);

    //        Assert.AreEqual(roundIterations, round.Iterations);
    //    }
    }
}
