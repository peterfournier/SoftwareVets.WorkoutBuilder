using System;

namespace SV.Builder.Domain.Factories
{
    public class RoundFactory
    {
        public IRound CreateRound(
            string name, 
            string description,
            int iterations,
            TimeSpan length
            )
        {

            var round = new Round(name);
            round.Description = description;
            round.Iterations = iterations;
            round.Length = length;

            return round;
        }
    }
}
