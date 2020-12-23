using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain
{
    internal class EnduranceSet : ExerciseSet, IEnduranceSet
    {
        private TimeSpan _length;
        public TimeSpan Length
        {
            get => _length;
            private set
            {
                _length = value;
                //OnLengthChanged?.Invoke(_length);
            }
        }

        public EnduranceSet(TimeSpan setLength)
        {
            Length = setLength.TotalMilliseconds <= 0 ? throw new ArgumentOutOfRangeException(nameof(setLength)) : setLength;
        }
    }
}
