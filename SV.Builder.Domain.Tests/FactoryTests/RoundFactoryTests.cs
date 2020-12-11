using NUnit.Framework;
using SV.Builder.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SV.Builder.Domain.Tests.FactoryTests
{
    public class RoundFactoryTests
    {
        private RoundFactory _roundFactory;

        [SetUp]
        public void Setup()
        {
            _roundFactory = new RoundFactory();
        }

        [Test]
        public void Test_CreateNewRound()
        {

            var roundName = "Round 1";
            var roundDescription = "Testing description";

            var round = _roundFactory.CreateRound(roundName, roundDescription, 0, new TimeSpan());

            Assert.IsNotNull(round);
        }

        [Test]
        public void Test_CreateNewRound_Name_IsEqual()
        {
            var roundName = "Round 1";
            var roundDescription = "Testing description";

            var round = _roundFactory.CreateRound(roundName, roundDescription, 0, new TimeSpan());

            Assert.AreEqual(roundName, round.Name);
        }

        [Test]
        public void Test_CreateNewRound_Description_IsEqual()
        {
            var roundName = "Round 1";
            var roundDescription = "Testing description";

            var round = _roundFactory.CreateRound(roundName, roundDescription, 0, new TimeSpan());

            Assert.AreEqual(roundDescription, round.Description);
        }

        [Test]
        public void Test_CreateNewRound_Iterations_IsEqual()
        {
            var roundName = "Round 1";
            var roundDescription = "Testing description";
            var roundIterations = 2;

            var round = _roundFactory.CreateRound(roundName, roundDescription, roundIterations, new TimeSpan());

            Assert.AreEqual(roundIterations, round.Iterations);
        }

        [Test]
        public void Test_CreateNewRound_Length_IsEqual()
        {
            var roundName = "Round 1";
            var roundDescription = "Testing description";
            var roundIterations = 2;
            var roundLength = new TimeSpan(0, 0, 30);

            var round = _roundFactory.CreateRound(roundName, roundDescription, roundIterations, roundLength);

            Assert.AreEqual(roundLength.TotalSeconds, round.Length.TotalSeconds);
        }
    }
}
