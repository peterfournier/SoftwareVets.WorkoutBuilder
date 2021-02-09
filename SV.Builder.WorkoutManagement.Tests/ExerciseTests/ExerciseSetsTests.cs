using NUnit.Framework;
using SV.Builder.WorkoutManagement;
using System.Linq;

namespace SV.Builder.WorkoutManagement.Tests.ExerciseTests
{
    public class ExerciseSetsTests
    {
        private Workout _workout;
        private Round _round;

        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1");
            _round = new Round(_workout.ID, "Round 1");
        }

        [Test]
        public void Add_Set_Exists()
        {
            var exercise = new Exercise(_round.ID, "Exercise 1");

            var set = new ExerciseSet(exercise.ID);

            exercise.AddSet(set);

            Assert.AreEqual(1, exercise.ExerciseSets.ToList().Count);
        }
    }
}
