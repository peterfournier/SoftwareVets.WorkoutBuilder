using NUnit.Framework;
using System;
using System.Linq;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests.SetTests
{
    public class SetAddWeightTests
    {
        private Exercise _exercise;
        private int _expectedSeconds = 30;
        private int _expectedReps = 10;
        private decimal _expectedWeight = 100;
        private Round _round;
        private TimeSpan _length;
        private Workout _workout;


        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1");
            _round = new Round("Round 1");
            _exercise = new Exercise("Set 1");
            _length = new TimeSpan(0,0, _expectedSeconds);
        }

        [TestCase(null)]
        public void Test_Add_Weight_GreatThanZero_Exception(decimal param)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(addWeight));

            void addWeight()
            {
                var set = new Set(_exercise, _expectedReps);
                set.AddWeight(param);
            }
        }

        [Test]
        public void Test_Add_Weight_IsSet()
        {
            var set = new Set(_exercise, _expectedReps);
            set.AddWeight(_expectedWeight);

            Assert.AreEqual(_expectedWeight, set.Weight);
        }
    }
}
