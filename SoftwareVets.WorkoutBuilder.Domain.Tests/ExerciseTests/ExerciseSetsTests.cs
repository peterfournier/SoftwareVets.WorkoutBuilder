using NUnit.Framework;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests.ExerciseTests
{
    public class ExerciseSetsTests
    {
        private Workout _workout;
        private Round _round;

        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1");
            _round = new Round(_workout, "Round 1");
        }

        [Test]
        public void TestConstructor_Add_Set_Exists()
        {
            var exercise = new Exercise(_round, "Round 1");

            var set = new Set(exercise, 1);

            exercise.AddSet(set);

            Assert.AreEqual(1, exercise.GetSets().Count);
        }
    }
}
