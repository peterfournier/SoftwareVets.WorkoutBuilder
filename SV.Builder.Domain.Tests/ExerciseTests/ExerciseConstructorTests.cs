using NUnit.Framework;
using System;
using System.Linq;

namespace SV.Builder.Domain.Tests.ExerciseTests
{
    public class ExerciseConstructorTests
    {
        private Workout _workout;
        private Round _round;

        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1");
            _round = new Round("Round 1");
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void TestConstructor_Name_CannotBeNull_Exception(string param)
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Round constructor: exerciseName parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Exercise(param);
            }
        }

        [TestCase("Exercise 1")]
        public void TestConstructor_Name_Is_Set(string param)
        {
            var exercise = new Exercise(param);

            Assert.AreEqual(param, exercise.Name);
        }

        //[TestCase("Exercise Name")]
        //public void TestConstructor_Round_IsNotNull(string param)
        //{
        //    var exercise = new Exercise(param);

        //    Assert.IsNotNull(exercise.Round);
        //}
    }
}
