﻿using NUnit.Framework;
using SV.Builder.WorkoutManagement;
using SV.Builder.WorkoutManagement.Factories;
using System;
using System.Threading.Tasks;

namespace SV.Builder.WorkoutManagement.Tests.FactoryTests
{
    public class ExerciseSetFactoryTests
    {
        private const int _expectedReps = 10;
        private double _expectedWeight = 135.00;
        private TimeSpan _expectedLength = new TimeSpan(0, 0, 30);
        private ExerciseSetFactory _setFactory;
        private Exercise _exercise;

        [SetUp]
        public void Setup()
        {
            var workout = new Workout("Workout Name");
            var round = new Round(workout.ID, "Round 1");
            _exercise = new Exercise(round.ID, "Exercise Name");
            _setFactory = new ExerciseSetFactory();
        }

        [Test]
        public void CreateSet_WithSetObject_CreatesDefaultExerciseSet()
        {
            var defaultSet = _setFactory.CreateSet(_exercise.ID, new Set());

            Assert.AreEqual(typeof(ExerciseSet), defaultSet?.GetType());
        }

        [Test]
        public void CreateSet_WithWeightSetObject_CreatesStrengthSet()
        {
            bool notTimed = false;
            var set = new Set(_expectedWeight, TimeSpan.MinValue, notTimed);
            var strengthSet = _setFactory.CreateSet(_exercise.ID, set);

            Assert.AreEqual(typeof(StrengthSet), strengthSet?.GetType());
        }

        [Test]
        public void CreateSet_WithDurationSetObject_CreatesEnduranceSet()
        {
            double noWeight = 0;
            bool notTimed = false;
            var set = new Set(noWeight, _expectedLength, notTimed);
            var enduranceSet = _setFactory.CreateSet(_exercise.ID, set);

            Assert.AreEqual(typeof(EnduranceSet), enduranceSet?.GetType());
        }

        [Test]
        public void CreateSet_WithTimedSetObject_CreatesPerformanceSet()
        {
            double noWeight = 0;
            bool timed = true;
            var set = new Set(noWeight, TimeSpan.MinValue, timed);
            var performanceSet = _setFactory.CreateSet(_exercise.ID, set);

            Assert.AreEqual(typeof(PerformanceSet), performanceSet?.GetType());
        }

        [Test]
        public void CreateSet_WithDurationAndWeightSetObject_CreatesIntenseEnduranceSet()
        {
            bool notTimed = false;
            var set = new Set(_expectedWeight, _expectedLength, notTimed);
            var intenseEnduranceSet = _setFactory.CreateSet(_exercise.ID, set);

            Assert.AreEqual(typeof(IntenseEnduranceSet), intenseEnduranceSet?.GetType());
        }

        [Test]
        public void CreateSet_WithWeightAndTimedSetObject_CreatesIntensePerformanceSet()
        {
            bool timed = true;
            var set = new Set(_expectedWeight, TimeSpan.MinValue, timed);
            var intensePerformanceSet = _setFactory.CreateSet(_exercise.ID, set);

            Assert.AreEqual(typeof(IntensePerformanceSet), intensePerformanceSet?.GetType());
        }

        [Test]
        public void CreateSet_WithReps_ReturnsExerciseSet()
        {
            var set = createDefaultSet();

            Assert.IsNotNull(set);
        }

        [Test]
        public void CreateSet_WithInvalidTimes_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(createInvalidSet));
            
            void createInvalidSet()
            {
                var timed = true;
                var set = new Set(duration: _expectedLength, timed: timed);
                var exerciseSet = _setFactory.CreateSet(_exercise.ID, set);
            }
        }


        private ExerciseSet createDefaultSet()
        {
            return _setFactory.CreateSet(_exercise.ID, new Set());
        }

        [Test]
        public void CreateSet_SetReps_ReturnsNumberOfReps()
        {
            var strengthSet = createDefaultStrengthSet(_expectedWeight);

            var numberOfReps = strengthSet.SetReps(_expectedReps);

            Assert.AreEqual(_expectedReps, numberOfReps);
        }

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
                new StrengthSet(_exercise.ID, invalidWeight);
            }
        }

        [Test]
        public void CreateEnduranceSet_WithTime_CreatesEnduranceSetObject()
        {
            var enduranceSet = createDefaultEnduranceSet(_expectedLength);

            Assert.IsTrue(enduranceSet is EnduranceSet);
        }

        [Test]
        public void CreateEnduranceSet_WithTime_AddsLengthToSet()
        {
            var enduranceSet = createDefaultEnduranceSet(_expectedLength) as EnduranceSet;

            Assert.AreEqual(_expectedLength, enduranceSet.Duration);

        }

        [Test]
        public void CreateEnduranceSet_WithInvalidTime_ThrowsException()
        {
            var invalidTimeSpan = new TimeSpan(0, 0, -30);
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(createEnduranceSet), $"Length of: {invalidTimeSpan} is an invalid length");

            void createEnduranceSet()
            {
                new EnduranceSet(_exercise.ID, invalidTimeSpan);
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

        private IntenseEnduranceSet createDefaultIntenseEnduranceSet()
        {
            var set = _setFactory.CreateSet(_exercise.ID, new Set(weight: _expectedWeight,duration: _expectedLength)) as IntenseEnduranceSet;
            return set;
        }

        private IntensePerformanceSet createDefaultIntensePerformanceSet()
        {
            bool timed = true;
            var set = _setFactory.CreateSet(_exercise.ID, new Set(_expectedWeight, TimeSpan.MinValue, timed)) as IntensePerformanceSet;
            return set;
        }

        private PerformanceSet createDefaultPerformanceSetSet()
        {
            bool timed = true;
            return _setFactory.CreateSet(_exercise.ID, new Set(timed: timed)) as PerformanceSet;
        }

        private ExerciseSet createDefaultEnduranceSet(TimeSpan expectedLength)
        {
            return _setFactory.CreateSet(_exercise.ID, new Set(duration: expectedLength));
        }

        private StrengthSet createDefaultStrengthSet(double weight)
        {
            var strengthSet = _setFactory.CreateSet(_exercise.ID, new Set(weight: weight)) as StrengthSet;
            return strengthSet;
        }
    }
}
