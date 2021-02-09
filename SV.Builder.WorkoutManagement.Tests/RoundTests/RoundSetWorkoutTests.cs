using NUnit.Framework;
using System;

namespace SV.Builder.Domain.Tests.RoundTests
{
    public class RoundSetWorkoutTests
    {
        [Test]
        public void Test_Sets_Workout_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(setWorkout), "SetWorkout: Workout parameter does not allow nulls");

            void setWorkout()
            {
                var round = new Round("Round 1");
                round.SetWorkout(null);
            }
        }

        [Test]
        public void Test_Sets_Workout_CannotBeSetTwice_Exception()
        {
            Assert.Throws(typeof(Exception), new TestDelegate(setWorkout), "SetWorkout: Workout cannot be set twice");

            void setWorkout()
            {
                var workout = new Workout("Workout 1");
                var round = new Round("Round 1");
                round.SetWorkout(workout);
                round.SetWorkout(workout);
            }
        }
    }
}
