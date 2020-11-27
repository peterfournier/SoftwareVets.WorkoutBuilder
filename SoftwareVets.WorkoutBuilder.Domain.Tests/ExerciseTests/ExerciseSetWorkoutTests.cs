using NUnit.Framework;
using System;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests.ExerciseTests
{
    public class ExerciseSetWorkoutTests
    {
        [Test]
        public void Test_Sets_Workout_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(setRound), "SetRound: round parameter does not allow nulls");

            void setRound()
            {
                var exercise = new Exercise("Exercise 1");
                exercise.SetRound(null);
            }
        }

        [Test]
        public void Test_SetRound__CannotBeSetTwice_Exception()
        {
            Assert.Throws(typeof(Exception), new TestDelegate(setRound), "SetRound: round parameter does not allow nulls");

            void setRound()
            {
                var round = new Round("Round 1");
                var exercise = new Exercise("Exercise 1");
                exercise.SetRound(round);
                exercise.SetRound(round);
            }
        }
    }
}
