﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVets.WorkoutBuilder.Domain.Tests.RoundTests
{
    public class RoundTests
    {
        [Test]
        public void Test_Sets_Workout_CannotBeNull_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), new TestDelegate(setWorkout), "SetWorkout: Workout parameter does not allow nulls");

            void setWorkout()
            {
                var round = new Round("Round 1");
                round.SetWorkout(null);
            }
        }

        [Test]
        public void Test_Sets_Workout_CannotBeSetTwice_Exception()
        {
            Assert.Throws(typeof(Exception), new TestDelegate(setWorkout), "SetWorkout: Workout parameter does not allow nulls");

            void setWorkout()
            {
                var workout = new Workout("Workout 1");
                var round = new Round("Round 1");
                round.SetWorkout(workout);
                round.SetWorkout(workout);
            }
        }
    }
}