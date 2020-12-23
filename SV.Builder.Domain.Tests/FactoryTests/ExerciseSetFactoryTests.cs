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

            Assert.AreEqual(_expectedLength, enduranceSet.Length);

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



        private IExerciseSet createDefaultEnduranceSet(TimeSpan expectedLength)
        {
            return _setFactory.CreateSet(0, expectedLength);
        }

        private IExerciseSet createDefaultStrengthSet(double weight)
        {
            var strengthSet = _setFactory.CreateSet(weight, new TimeSpan());
            return strengthSet;
        }
    }
}
