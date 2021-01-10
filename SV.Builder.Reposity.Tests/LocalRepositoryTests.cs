using NUnit.Framework;
using SV.Builder.Domain;
using SV.Builder.Domain.Factories;
using SV.Builder.Repository;
using SV.Builder.Repository.IntegrationTests.Models;
using System;
using System.Linq;

namespace SV.Builder.Reposity.IntegrationTests
{
    public class LocalRepositoryTests
    {
        private WorkoutEntityMock workoutEntityMock;
        private int workoutEntityMockIdentity;

        [SetUp]
        public void Setup()
        {
            workoutEntityMockIdentity = Guid.NewGuid().GetHashCode();
            if (workoutEntityMockIdentity < 0)
                workoutEntityMockIdentity = workoutEntityMockIdentity * -1;

            workoutEntityMock = new WorkoutEntityMock()
            {
                Name = "Master Class",
                Description = "You are you own Gym workout",
                ID = workoutEntityMockIdentity
            };
        }

        [Test]
        public void Create_WithValidObject_CreatesJsonFile()
        {
            var repository = createDefaultLocalRepo();

            var success = repository.Create(workoutEntityMock);
            
            Assert.IsTrue(success);
        }

        [Test]
        public void Get_ReturnsObject()
        {
            var repository = createDefaultLocalRepo();

            var result = repository.Get<WorkoutEntityMock>()
                                   .FirstOrDefault();

            Assert.IsNotNull(result);
        }

        [Test]
        public void Get_WithValidID_ReturnsObject()
        {
            var repository = createDefaultLocalRepo();

            repository.Create(workoutEntityMock);

            var result = repository.Get<WorkoutEntityMock>(workoutEntityMockIdentity);
            Assert.AreEqual(workoutEntityMockIdentity, result.ID);
        }

        [Test]
        public void Update_WithValidObject_UpdatesObject()
        {
            var repository = createDefaultLocalRepo();
            repository.Create(workoutEntityMock);
            string newWorkoutName = "Basic Class";
            workoutEntityMock.Name = newWorkoutName;

            var updatedEntity = repository.Update(workoutEntityMock);

            var result = repository.Get<WorkoutEntityMock>(workoutEntityMock.ID);
            Assert.AreEqual(newWorkoutName, result.Name);
        }

        [Test]
        public void Remove_WithValidObject_UpdatesObject()
        {
            var repository = createDefaultLocalRepo();
            repository.Create(workoutEntityMock);

            bool success = repository.Remove(workoutEntityMock);

            var result = repository.Get<WorkoutEntityMock>(workoutEntityMock.ID);
            Assert.IsNull(result);
        }

        private static LocalFileRepository createDefaultLocalRepo()
        {
            return new LocalFileRepository();
        }
    }
}