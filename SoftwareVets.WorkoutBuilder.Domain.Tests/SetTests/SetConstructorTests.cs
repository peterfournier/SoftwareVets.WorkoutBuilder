using NUnit.Framework;
using System;
using System.Linq;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests.SetTests
{
    public class SetConstructorTests
    {
        private int _expectedSeconds = 30;
        private int _expectedReps = 10;
        private TimeSpan _length;


        [SetUp]
        public void Setup()
        {
            _length = new TimeSpan(0,0, _expectedSeconds);
        }

        [TestCase(null)]
        public void TestConstructor_Length_CannotBeNull_Exception(TimeSpan param)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(contructWorkoutObject), "Set constructor: Length parameter must be greater than 0 seconds");

            void contructWorkoutObject()
            {
                _ = new Set(param);
            }
        }

        [Test]
        public void TestConstructor_Length_CannotBeZero_Exception()
        {
            var timeSpan = new TimeSpan(0,0,0);

            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(contructWorkoutObject), "Set constructor: Length parameter must be greater than 0 seconds");

            void contructWorkoutObject()
            {
                _ = new Set(timeSpan);
            }
        }

        [Test]
        public void TestConstructor_Length_Is_Set()
        {            
            var set = new Set(_length);

            Assert.AreEqual(_expectedSeconds, set.Length.TotalSeconds);
        }       

        [TestCase(0)]
        [TestCase(-123)]
        public void TestConstructor_Reps_CannotBeZero_Exception(int parm)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(contructWorkoutObject), "Set constructor: Reps must be greater than zero");

            void contructWorkoutObject()
            {
                _ = new Set(parm);
            }
        }

        [Test]
        public void TestConstructor_Reps_Is_Set()
        {
            var set = new Set(_expectedReps);

            Assert.AreEqual(_expectedReps, set.Reps);
        }
    }
}
