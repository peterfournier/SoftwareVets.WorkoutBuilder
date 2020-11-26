using NUnit.Framework;
using System;
using System.Linq;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests
{
    public class ExerciseConstructorTests
    {
        private Workout _workout;
        private Round _round;

        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1");
            _round = new Round(_workout, "Round 1");
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void TestConstructor_Name_CannotBeNull_Exception(string param)
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Round constructor: exerciseName parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Exercise(_round, param);
            }
        }

        [TestCase("Exercise 1")]
        public void TestConstructor_Name_Is_Set(string param)
        {
            var exercise = new Exercise(_round, param);

            Assert.AreEqual(param, exercise.Name);
        }

        [TestCase("Exercise")]
        public void TestConstructor_Sets_Has_Default(string param)
        {
            var exercise = new Exercise(_round, param);

            Assert.AreEqual(1, exercise.Sets.Count);
        }

        [Test]
        public void TestConstructor_Round_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Round constructor: round parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Exercise(null, "Exercise 1");
            }
        }

        [TestCase("Exercise Name")]
        public void TestConstructor_Round_IsNotNull(string param)
        {
            var exercise = new Exercise(_round, param);

            Assert.IsNotNull(exercise.Round);
        }
    }
}
