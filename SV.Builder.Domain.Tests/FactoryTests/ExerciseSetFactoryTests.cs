using NUnit.Framework;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Builder.Domain.Tests.FactoryTests
{
    public class ExerciseSetFactoryTests
    {
        private double _expectedWeight = 135.00;
        private TimeSpan _expectedLength = new TimeSpan(0, 0, 30);
        private ExerciseSetFactory _setFactory;

        [SetUp]
        public void Setup()
        {
            _setFactory = new ExerciseSetFactory();
        }

        [Test]
        public void CreateSet_SetReps_ReturnsNumberOfReps()
        {
            var expectedReps = 10;
            var strengthSet = createDefaultStrengthSet(_expectedWeight);

            var numberOfReps = strengthSet.SetReps(expectedReps);

            Assert.AreEqual(expectedReps, numberOfReps);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CreateSet_SetReps_ThrowsArgumentOutOfRangeException(int reps)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(setNumberOfReps));

            void setNumberOfReps()
            {
                var strengthSet = createDefaultStrengthSet(_expectedWeight);
                var numberOfReps = strengthSet.SetReps(reps);
            }
        }

        [Test]
        public void CreateStrengthSet_WithWeight_CreatesStrengthSetObject()
        {
            var strengthSet = createDefaultStrengthSet(_expectedWeight);

            Assert.IsTrue(strengthSet is IWeightedSet);
        }

        [Test]
        public void CreateStrengthSet_WithWeight_AddsWeightToSet()
        {
            var expectedWeight = 135.00;
            var strengthSet = createDefaultStrengthSet(_expectedWeight) as IWeightedSet;

            Assert.AreEqual(expectedWeight, strengthSet.Weight);

        }

        [TestCase(-1.00)]
        [TestCase(0.00)]
        public void CreateStrengthSet_WithInvalidWeight_ThrowsException(double invalidWeight)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(createStrengthSet), $"Weight of: {invalidWeight} is an invalid weight");

            void createStrengthSet()
            {
                createDefaultStrengthSet(invalidWeight);
            }
        }

        [Test]
        public void CreateEnduranceSet_WithTime_CreatesEnduranceSetObject()
        {
            var enduranceSet = createDefaultEnduranceSet(_expectedLength);

            Assert.IsTrue(enduranceSet is IEnduranceSet);
        }

        [Test]
        public void CreateEnduranceSet_WithTime_AddsLengthToSet()
        {
            var enduranceSet = createDefaultEnduranceSet(_expectedLength) as IEnduranceSet;

            Assert.AreEqual(_expectedLength, enduranceSet.Duration);

        }

        [Test]
        public void CreateEnduranceSet_WithInvalidTime_ThrowsException()
        {
            var invalidTimeSpan = new TimeSpan(0, 0, -30);
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(createEnduranceSet), $"Length of: {invalidTimeSpan} is an invalid length");

            void createEnduranceSet()
            {
                createDefaultEnduranceSet(invalidTimeSpan);
            }
        }

        [Test]
        public void CreatePerformanceSet_NoTime_CreatesSetObject()
        {
            var performanceSet = createDefaultPerformanceSetSet();

            Assert.IsNotNull(performanceSet);
        }

        [Test]
        public async Task PerformanceSetStart_LogsTime()
        {
            int threeSeconds = 3000;
            var performanceSet = createDefaultPerformanceSetSet();

            performanceSet.Start();
            await Task.Delay(3000);
            performanceSet.Stop();

            Assert.IsTrue(performanceSet.ElapsedTime.TotalMilliseconds > threeSeconds);
        }

        [Test]
        public void PerformanceSetReset_ResetsTheStopwatch()
        {
            int expectedZeroTime = 0;
            var performanceSet = createDefaultPerformanceSetSet();

            performanceSet.Start();
            performanceSet.Stop();

            performanceSet.Reset();

            Assert.AreEqual(expectedZeroTime, performanceSet.ElapsedTime.TotalMilliseconds);
        }

        [Test]
        public void CreateIntensePerformanceSet_NoTime_CreatesSetObject()
        {
            var intensePerformanceSet = createDefaultIntensePerformanceSet();

            Assert.IsNotNull(intensePerformanceSet);
        }

        [Test]
        public void CreateIntenseEnduranceSet_WithTime_CreatesSetObject()
        {
            var intenseEnduranceSet = createDefaultIntenseEnduranceSet();

            Assert.IsNotNull(intenseEnduranceSet);
        }

        private object createDefaultIntenseEnduranceSet()
        {
            var set = _setFactory.CreateSet(_expectedWeight, _expectedLength) as IIntenseEnduranceSet;
            return set;
        }

        private IIntensePerformanceSet createDefaultIntensePerformanceSet()
        {
            bool timed = true;
            var set = _setFactory.CreateSet(_expectedWeight, timed) as IIntensePerformanceSet;
            return set;
        }

        private IPerformanceSet createDefaultPerformanceSetSet()
        {
            return _setFactory.CreateSet() as PerformanceSet;
        }

        private IExerciseSet createDefaultEnduranceSet(TimeSpan expectedLength)
        {
            return _setFactory.CreateSet(expectedLength);
        }

        private IExerciseSet createDefaultStrengthSet(double weight)
        {
            var strengthSet = _setFactory.CreateSet(weight);
            return strengthSet;
        }
    }
}
