using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests
{
    public class RoundConstructorTests
    {
        private Workout workout;

        [SetUp]
        public void Setup()
        {
            workout = new Workout("Workout 1");
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void TestConstructor_Name_CannotBeNull_Exception(string param)
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Round constructor: Name parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Round(workout, param);
            }
        }

        [TestCase("Round 1")]
        public void TestConstructor_Name_Is_Set(string param)
        {
            var round = new Round(workout, param);

            Assert.AreEqual(param, round.Name);
        }

        [TestCase("Round Name")]
        public void TestConstructor_Exercises_Has_Default(string param)
        {
            var round = new Round(workout, param);

            Assert.AreEqual(1, round.Exercises.Count);
        }

        [Test]
        public void TestConstructor_Workout_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Round constructor: Workout parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Round(null, "Round 1");
            }
        }

        [TestCase("Round Name")]
        public void TestConstructor_Workout_IsNotNull(string param)
        {
            var round = new Round(workout, param);

            Assert.IsNotNull(round.Workout);
        }
    }
}
