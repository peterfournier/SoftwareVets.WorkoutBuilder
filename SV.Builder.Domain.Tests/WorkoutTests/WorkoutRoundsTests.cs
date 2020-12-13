using NUnit.Framework;
using System;

namespace SV.Builder.Domain.Tests.WorkoutTests
{
    public class WorkoutRoundsTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("Workout Name")]
        public void AddRound_NewRound_AddsToRoundCollection(string param)
        {
            var workout = new Workout(param);

            workout.AddRound(new Round("Round 1"));

            Assert.AreEqual(1, workout.GetRounds().Count);
        }

        [TestCase("Workout Name")]
        public void AddRound_NewRound_SetsWorkoutProperty(string param)
        {
            var workout = new Workout(param);
            var round = new Round("Round 1");
            workout.AddRound(round);

            Assert.AreEqual(workout, round.Workout);
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