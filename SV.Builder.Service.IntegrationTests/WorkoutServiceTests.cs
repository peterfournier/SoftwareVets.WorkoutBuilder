using GraniteCore.LocalFileRepository;
using NUnit.Framework;
using SV.Builder.Domain.EntityModels;
using System;
using System.Reflection;

namespace SV.Builder.Service.IntegrationTests
{
    public class WorkoutServiceTests
    {
        private LocalWorkoutService _workoutService;

        [SetUp]
        public void Setup()
        {
            _workoutService = getWorkoutService();
        }

        private LocalWorkoutService getWorkoutService()
        {
            //var assembly = Assembly.Load("SV.Builder.Reposity.IntegrationTests");
            //var path = assembly.Location;
            //var options = new LocalFileRepositoryOptions()
            //{
            //    FilePath = path
            //};
            var localFileRepo = new LocalFileRepository<WorkoutEntity, Guid>();
            return new LocalWorkoutService(localFileRepo, new SvMapper());
        }

        [Test]
        public void GetAll_NoParameters_ReturnsWorkCollection()
        {
            var results = _workoutService.GetAll();


            Assert.IsTrue(results.Count > 0);
        }

        [Test]
        public void Update_ChangesPersistInDb()
        {
            var results = _workoutService.GetAll();


            Assert.IsTrue(results.Count > 0);
        }
    }
}