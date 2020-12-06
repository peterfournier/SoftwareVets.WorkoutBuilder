using NUnit.Framework;
using System;

namespace SV.Builder.Domain.Tests.ExerciseTests
{
    public class SetSetExerciseTests
    {
        [Test]
        public void Test_SetExercise_Exercise_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(setExercise), "SetExercise: exercise parameter does not allow nulls");

            void setExercise()
            {
                var set = new Set(10);
                set.SetExercise(null);
            }
        }

        [Test]
        public void Test_SetExercise_Exercise_CannotBeSetTwice_Exception()
        {
            Assert.Throws(typeof(Exception), new TestDelegate(setRound), "SetExercise: exercise cannot be set twice");

            void setRound()
            {
                var exercise = new Exercise("Exercise 1");
                var set = new Set(10);
                set.SetExercise(exercise);
                set.SetExercise(exercise);
            }
        }
    }
}
