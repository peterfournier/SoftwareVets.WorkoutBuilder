using System.Collections.Generic;

namespace SV.Builder.Domain
{
    public interface IWorkout
    {
        string Description { get; }
        string Name { get; }
        void AddRound(IRound round);
        List<IRound> GetRounds();
    }
}
