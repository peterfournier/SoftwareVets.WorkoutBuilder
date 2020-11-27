using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests
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
        public void TestConstructor_Add_Exercise_Exists(string param)
        {
            var round = new Round(workout, param);

            round.AddExercise(new Exercise(round, "Exercise 1"));

            Assert.AreEqual(2, round.GetExercises().Count);
        }

        [Test]
        public void TestConstructor_AddExercise_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(addExerciseTest), "AddExercise: Exercise parameter does not allow nulls");

            void addExerciseTest()
            {
                var round = new Round(workout, "Round 1");

                round.AddExercise(null);
            }
        }
    }
}
