using NUnit.Framework;
using System;
using System.Linq;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests.SetTests
{
    public class SetConstructorTests
    {
        private Exercise _exercise;
        private int _expectedSeconds = 30;
        private int _expectedReps = 10;
        private Round _round;
        private TimeSpan _length;
        private Workout _workout;


        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout 1");
            _round = new Round("Round 1");
            _exercise = new Exercise(_round, "Set 1");
            _length = new TimeSpan(0,0, _expectedSeconds);
        }

        [TestCase(null)]
        public void TestConstructor_Length_CannotBeNull_Exception(TimeSpan param)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(contructWorkoutObject), "Set constructor: Length parameter must be greater than 0 seconds");

            void contructWorkoutObject()
            {
                _ = new Set(_exercise, param);
            }
        }

        [Test]
        public void TestConstructor_Length_CannotBeZero_Exception()
        {
            var timeSpan = new TimeSpan(0,0,0);

            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(contructWorkoutObject), "Set constructor: Length parameter must be greater than 0 seconds");

            void contructWorkoutObject()
            {
                _ = new Set(_exercise, timeSpan);
            }
        }

        [Test]
        public void TestConstructor_Length_Is_Set()
        {            
            var set = new Set(_exercise, _length);

            Assert.AreEqual(_expectedSeconds, set.Length.TotalSeconds);
        }

        //[Test]
        //public void TestContructor_WorkoutLength_Matches()
        //{
        //    var workout2 = new Workout("Workout 2");
        //    var round2 = new Round("Round 1");
        //    var exercise2 = new Exercise(round2, "Exercise 1");
        //    _ = new Set(exercise2, _length);

        //    Assert.AreEqual(_length.TotalSeconds, workout2.Length.TotalSeconds);
        //}

        [Test]
        public void TestContructor_RoundLength_Matches()
        {
            var workout2 = new Workout("Workout 2");
            var round2 = new Round("Round 1");
            var exercise2 = new Exercise(round2, "Exercise 1");
            _ = new Set(exercise2, _length);

            Assert.AreEqual(_length.TotalSeconds, round2.Length.TotalSeconds);
        }

        //[Test]
        //public void TestContructor_WorkoutLength_With_Two_SetsMatches()
        //{
        //    var workout2 = new Workout("Workout 2");
        //    var round2 = new Round("Round 1");
        //    var exercise2 = new Exercise(round2, "Exercise 1");
        //    _ = new Set(exercise2, _length);
        //    _ = new Set(exercise2, _length);

        //    Assert.AreEqual(_length.TotalSeconds * 2, workout2.Length.TotalSeconds);
        //}

        [Test]
        public void TestContructor_RoundLength_With_Two_SetsMatches()
        {
            var workout2 = new Workout("Workout 2");
            var round2 = new Round("Round 1");
            var exercise2 = new Exercise(round2, "Exercise 1");
            _ = new Set(exercise2, _length);
            _ = new Set(exercise2, _length);

            Assert.AreEqual(_length.TotalSeconds * 2, round2.Length.TotalSeconds);
        }

        [Test]
        public void TestConstructor_Exercise_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Set constructor: Exercise parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Set(null, _length);
            }
        }

        [Test]
        public void TestConstructor_Exercise_IsNotNull()
        {
            var set = new Set(_exercise, _length);

            Assert.IsNotNull(set.Exercise);
        }

        [TestCase(0)]
        [TestCase(-123)]
        public void TestConstructor_Reps_CannotBeZero_Exception(int parm)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(contructWorkoutObject), "Set constructor: Reps must be greater than zero");

            void contructWorkoutObject()
            {
                _ = new Set(_exercise, parm);
            }
        }

        [Test]
        public void TestConstructor_Reps_Is_Set()
        {
            var set = new Set(_exercise, _expectedReps);

            Assert.AreEqual(_expectedReps, set.Reps);
        }

        [Test]
        public void Test_Reps_Constructor_Exercise_IsNotNull()
        {
            var set = new Set(_exercise, _expectedReps);

            Assert.IsNotNull(set.Exercise);
        }

        [Test]
        public void Test_Reps_Constructor_Exercise_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(contructWorkoutObject), "Set constructor: Exercise parameter does not allow nulls");

            void contructWorkoutObject()
            {
                _ = new Set(null, _expectedReps);
            }
        }

    }
}
