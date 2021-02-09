using NUnit.Framework;

namespace SV.Builder.Domain.Tests.ExerciseTests
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
        public void Add_Set_Exists()
        {
            var exercise = new Exercise("Exercise 1");

            var set = new ExerciseSet();

            exercise.AddSet(set);

            Assert.AreEqual(1, exercise.GetSets().Count);
        }

        [Test]
        public void AddSet_Sets_Exercise_Property()
        {
            var exercise = new Exercise("Exercise 1");
            var set = new ExerciseSet();

            exercise.AddSet(set);

            Assert.AreEqual(exercise, set.Exercise);
        }
    }
}
