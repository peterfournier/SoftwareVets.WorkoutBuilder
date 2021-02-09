using System.Collections.Generic;

namespace SV.Builder.Domain
{
    public interface IWorkout
    {
        List<IRound> GetRounds();
        string Description { get; set; }
        string Name { get; }
        bool AddRound(IRound round);
        void ChangeName(string newName);
    }
}
