using NUnit.Framework;
using SV.Builder.Domain.Factories;

namespace SV.Builder.Domain.Tests.FactoryTests
{
    public class ExerciseFactoryTests
    {
        private ExerciseFactory _exerciseFactory;

        [SetUp]
        public void Setup()
        {
            _exerciseFactory = new ExerciseFactory();
        }

        [Test]
        public void CreateExercise_WithValidInput_CreatesExercise()
        {

            var exerciseName = "Sit ups";

            var exercise = _exerciseFactory.CreateExercise(exerciseName);

            Assert.IsNotNull(exercise);
        }
    }
}
