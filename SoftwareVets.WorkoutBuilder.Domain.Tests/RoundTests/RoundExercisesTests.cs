using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests.RoundTests
{
    public class RoundExercisesTests
    {
        private Workout workout;

        [SetUp]
        public void Setup()
        {
            workout = new Workout("Workout 1");
        }

        [TestCase("Round 1")]
        public void Test_Add_Exercise_Exists(string param)
        {
            var round = new Round(param);

            round.AddExercise(new Exercise("Exercise 1"));

            Assert.AreEqual(1, round.GetExercises().Count);
        }

        [Test]
        public void Test_Add_Exercise_Sets_Round_Property()
        {
            var workout = new Workout("Workout 1");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");

            workout.AddRound(round);
            round.AddExercise(exercise);

            Assert.AreEqual(round, exercise.Round);
        }

        [Test]
        public void Test_AddExercise_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(addExerciseTest), "AddExercise: Exercise parameter does not allow nulls");

            void addExerciseTest()
            {
                var round = new Round("Round 1");

                round.AddExercise(null);
            }
        }
    }
}
