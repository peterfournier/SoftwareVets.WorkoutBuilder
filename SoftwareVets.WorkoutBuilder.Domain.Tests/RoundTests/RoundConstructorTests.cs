using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests.RoundTests
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
