using FluentAssertions;
using NUnit.Framework;
using SV.Builder.Core.SharedKernel;

namespace SV.Builder.Core.Tests
{
    public class SetTests
    {
        [Test]
        public void Create_strength_set()
        {
            var setOptions = new SetOptions(Duration.None, reps:10, weight:135, timed:false);

            setOptions.Type.Should().Be(SetType.Strength);
        }

        [Test]
        public void Create_endurance_set()
        {
            var setOptions = new SetOptions(Duration.FiveMinutes, reps: 10, weight: 0, timed: false);

            setOptions.Type.Should().Be(SetType.Endurance);
        }

        [Test]
        public void Create_strength_endurance_set()
        {
            var setOptions = new SetOptions(Duration.FiveMinutes, reps: 10, weight: 135, timed: false);

            setOptions.Type.Should().Be(SetType.StrengthEndurance);
        }

        [Test]
        public void Create_performance_set()
        {
            var setOptions = new SetOptions(Duration.None, reps: 10, weight: 0, timed: true);

            setOptions.Type.Should().Be(SetType.Performance);
        }

        [Test]
        public void Create_strength_performance_set()
        {
            var setOptions = new SetOptions(Duration.None, reps: 10, weight: 135, timed: true);

            setOptions.Type.Should().Be(SetType.StrengthPerformance);
        }

        [Test]
        public void Create_set()
        {
            var setOptions = new SetOptions(Duration.None, reps: 10, weight: 0, timed: false);

            setOptions.Type.Should().Be(SetType.None);
        }
    }
}
