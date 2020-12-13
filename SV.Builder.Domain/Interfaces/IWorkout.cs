using System.Collections.Generic;

namespace SV.Builder.Domain
{
    public interface IWorkout
    {
        List<IRound> GetRounds();
        string Description { get; set; }
        string Name { get; }
        void AddRound(IRound round);
        void ChangeName(string newName);
    }
}
