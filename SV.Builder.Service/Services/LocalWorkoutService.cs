using GraniteCore;
using SV.Builder.Domain;
using SV.Builder.Domain.EntityModels;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SV.Builder.Service
{
    public class LocalWorkoutService : BaseService<WorkoutEntity, WorkoutEntity, Guid>
    {
        public LocalWorkoutService(IBaseRepository<WorkoutEntity, 
            Guid> repository, 
            IGraniteMapper mapper) 
            : base(repository, mapper)
        {

        }

        public new List<IWorkout> GetAll()
        {
            var workoutFactory = new WorkoutFactory();
            var entities = Repository.GetAll();
            var workouts = new List<IWorkout>();
            foreach (var entity in entities)
            {
                workouts.Add(workoutFactory.CreateWorkout(entity.Name, entity.Description));
            }
            return workouts;
        }
    }
}
