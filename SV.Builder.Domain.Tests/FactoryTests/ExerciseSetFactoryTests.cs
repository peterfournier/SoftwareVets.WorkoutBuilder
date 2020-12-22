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
        private ExerciseSetFactory _setFactory;

        [SetUp]
        public void Setup()
        {
            _setFactory = new ExerciseSetFactory();
        }

        [Test]
        public void CreateSet_WithWeight_CreatesStrengthSetObject()
        {
            var strengthSet = createDefaultStrengthSet(_expectedWeight);

            Assert.IsTrue(strengthSet is IWeightedSet);
        }

        [Test]
        public void CreateSet_WithWeight_AddsWeightToSet()
        {
            var expectedWeight = 135.00;
            var strengthSet = createDefaultStrengthSet(_expectedWeight) as IWeightedSet;

            Assert.AreEqual(expectedWeight, strengthSet.Weight);

        }

        [TestCase(-1.00)]
        public void CreateSet_WithInvalidWeight_ThrowsException(double invalidWeight)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(createStrengthSet), $"Weight of: {invalidWeight} is an invalid weight");

            void createStrengthSet()
            {
                createDefaultStrengthSet(invalidWeight);
            }
        }

        private IExerciseSet createDefaultStrengthSet(double weight)
        {
            var strengthSet = _setFactory.CreateSet(weight);
            return strengthSet;
        }
    }
}
