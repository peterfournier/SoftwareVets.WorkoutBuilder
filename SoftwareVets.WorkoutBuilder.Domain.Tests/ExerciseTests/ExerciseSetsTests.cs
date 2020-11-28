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
            _round = new Round("Round 1");
        }

        [Test]
        public void Test_Add_Set_Exists()
        {
            var exercise = new Exercise("Exercise 1");

            var set = new Set(1);

            exercise.AddSet(set);

            Assert.AreEqual(1, exercise.GetSets().Count);
        }

        [Test]
        public void Test_AddSet_Sets_Exercise_Property()
        {
            var exercise = new Exercise("Exercise 1");
            var set = new Set(10);

            exercise.AddSet(set);

            Assert.AreEqual(exercise, set.Exercise);
        }
    }
}
