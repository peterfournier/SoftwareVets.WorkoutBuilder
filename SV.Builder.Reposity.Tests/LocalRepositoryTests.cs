using GraniteCore.LocalFileRepository;
using NUnit.Framework;
using SV.Builder.Domain;
using SV.Builder.Domain.EntityModels;
using SV.Builder.Domain.Factories;
using SV.Builder.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SV.Builder.Reposity.IntegrationTests
{
    public class LocalRepositoryTests
    {
        private WorkoutEntity workoutEntityMock;
        private Guid workoutEntityMockIdentity;

        [SetUp]
        public void Setup()
        {
            workoutEntityMockIdentity = Guid.NewGuid();

            workoutEntityMock = new WorkoutEntity()
            {
                Name = "Master Class",
                Description = "You are you own Gym workout",
                ID = workoutEntityMockIdentity
            };
        }

        [Test]
        public async Task Create_WithValidObject_CreatesJsonFile()
        {
            var repository = createDefaultLocalRepo();

            var entity = await repository.Create(workoutEntityMock);
            
            Assert.IsNotNull(entity);
        }

        [Test]
        public void Get_ReturnsObject()
        {
            var repository = createDefaultLocalRepo();

            var result = repository.GetAll().FirstOrDefault();

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Get_WithValidID_ReturnsObject()
        {
            var repository = createDefaultLocalRepo();

            await repository.Create(workoutEntityMock);

            var result = await repository.GetByID(workoutEntityMockIdentity);

            Assert.AreEqual(workoutEntityMockIdentity, result.ID);
        }

        [Test]
        public async Task Update_WithValidObject_UpdatesObject()
        {
            var repository = createDefaultLocalRepo();
            await repository.Create(workoutEntityMock);
            string newWorkoutName = "Basic Class";
            workoutEntityMock.Name = newWorkoutName;

            await repository.Update(workoutEntityMockIdentity, workoutEntityMock);

            var result = await repository.GetByID(workoutEntityMock.ID);
            Assert.AreEqual(newWorkoutName, result.Name);
        }

        [Test]
        public async Task Remove_WithValidObject_UpdatesObject()
        {
            var repository = createDefaultLocalRepo();
            await repository.Create(workoutEntityMock);
            var id = workoutEntityMock.ID;

            await repository.Delete(id);

            var result = await repository.GetByID(id);
            Assert.IsNull(result);
        }

        private LocalFileRepository<WorkoutEntity, Guid> createDefaultLocalRepo()
        {
            return new SVLocalRepository<WorkoutEntity, Guid>();
        }
    }
}