using NUnit.Framework;
using System;
using SoftwareVets.WorkoutBuilder.Domain;
using System.Linq;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests
{
    public class WorkoutRoundsTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase("Workout Name")]
        public void TestConstructor_Add_Round_Exists(string param)
        {
            var workout = new Workout(param);

            workout.AddRound(new Round(workout, "Round 1"));

            Assert.AreEqual(1, workout.GetRounds().Count);
        }

        [Test]
        public void TestConstructor_AddRound_CannotBeNull_Exception()
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