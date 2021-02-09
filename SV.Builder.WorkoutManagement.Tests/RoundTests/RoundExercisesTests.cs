using NUnit.Framework;
using SV.Builder.WorkoutManagement;
using System;
using System.Linq;

namespace SV.Builder.WorkoutManagement.Tests.RoundTests
{
    public class RoundExercisesTests
    {
        private Workout workout;

        [SetUp]
        public void Setup()
        {
            workout = new Workout("Workout 1");
        }

        [TestCase("Round 1")]
        public void AddExercise_Exists(string param)
        {
            var round = new Round(workout.ID, param);

            round.AddExercise(new Exercise(round.ID, "Exercise 1"));

            Assert.AreEqual(1, round.Exercises.ToList().Count);
        }

        [Test]
        public void AddExercise_CannotBeNull_ThrowsException()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(addExerciseTest), "AddExercise: Exercise parameter does not allow nulls");

            void addExerciseTest()
            {
                var round = new Round(workout.ID, "Round 1");

                round.AddExercise(null);
            }
        }
    }
}
