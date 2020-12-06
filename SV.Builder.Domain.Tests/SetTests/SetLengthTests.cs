using NUnit.Framework;
using System;

namespace SV.Builder.Domain.Tests.SetTests
{
    public class SetLengthTests
    {
        private TimeSpan _length;
        private int _expectedSeconds = 30;

        [SetUp]
        public void Setup()
        {
            _length = new TimeSpan(0, 0, _expectedSeconds);
        }

        [Test]
        public void Test_RoundLength_Matches()
        {
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            exercise.AddSet(set);
            round.AddExercise(exercise);

            Assert.AreEqual(_length.TotalSeconds, round.Length.TotalSeconds);
        }

        [Test]
        public void Test_RoundLength_Matches_v2()
        {
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            round.AddExercise(exercise);
            exercise.AddSet(set);

            Assert.AreEqual(_length.TotalSeconds, round.Length.TotalSeconds);
        }

        [Test]
        public void Test_MultipleSets_RoundLength_Matches()
        {
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);
            var set2 = new Set(_length);

            exercise.AddSet(set);
            exercise.AddSet(set2);
            round.AddExercise(exercise);

            Assert.AreEqual(_length.TotalSeconds * 2, round.Length.TotalSeconds);
        }

        [Test]
        public void Test_Multiple_RoundLength_Matches_v2()
        {
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);
            var set2 = new Set(_length);

            round.AddExercise(exercise);
            exercise.AddSet(set);
            exercise.AddSet(set2);

            Assert.AreEqual(_length.TotalSeconds * 2, round.Length.TotalSeconds);
        }

        [Test]
        public void Test_WorkoutLength_Matches()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            workout.AddRound(round);
            round.AddExercise(exercise);
            exercise.AddSet(set);

            Assert.AreEqual(_length.TotalSeconds, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_WorkoutLength_Matches_v2()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            workout.AddRound(round);
            exercise.AddSet(set);
            round.AddExercise(exercise);

            Assert.AreEqual(_length.TotalSeconds, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_WorkoutLength_Matches_v3()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            round.AddExercise(exercise);
            workout.AddRound(round);
            exercise.AddSet(set);

            Assert.AreEqual(_length.TotalSeconds, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_WorkoutLength_Matches_v4()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            round.AddExercise(exercise);
            exercise.AddSet(set);
            workout.AddRound(round);

            Assert.AreEqual(_length.TotalSeconds, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_WorkoutLength_Matches_v5()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            exercise.AddSet(set);
            round.AddExercise(exercise);
            workout.AddRound(round);

            Assert.AreEqual(_length.TotalSeconds, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_WorkoutLength_Matches_v6()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            exercise.AddSet(set);
            workout.AddRound(round);
            round.AddExercise(exercise);

            Assert.AreEqual(_length.TotalSeconds, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_MultipleSets_WorkoutLength_Matches()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);
            var set2 = new Set(_length);

            workout.AddRound(round);
            round.AddExercise(exercise);
            exercise.AddSet(set);
            exercise.AddSet(set2);

            Assert.AreEqual(_length.TotalSeconds * 2, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_MultipleSets_WorkoutLength_Matches_v2()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);
            var set2 = new Set(_length);

            workout.AddRound(round);
            exercise.AddSet(set);
            exercise.AddSet(set2);
            round.AddExercise(exercise);

            Assert.AreEqual(_length.TotalSeconds * 2, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_MultipleSets_WorkoutLength_Matches_v3()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);
            var set2 = new Set(_length);

            round.AddExercise(exercise);
            workout.AddRound(round);
            exercise.AddSet(set);
            exercise.AddSet(set2);

            Assert.AreEqual(_length.TotalSeconds * 2, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_MultipleSets_WorkoutLength_Matches_v4()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);
            var set2 = new Set(_length);

            round.AddExercise(exercise);
            exercise.AddSet(set);
            exercise.AddSet(set2);
            workout.AddRound(round);

            Assert.AreEqual(_length.TotalSeconds * 2, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_MultipleSets_WorkoutLength_Matches_v5()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);
            var set2 = new Set(_length);

            exercise.AddSet(set);
            exercise.AddSet(set2);
            round.AddExercise(exercise);
            workout.AddRound(round);

            Assert.AreEqual(_length.TotalSeconds * 2, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_MultipleSets_WorkoutLength_Matches_v6()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);
            var set2 = new Set(_length);

            exercise.AddSet(set);
            exercise.AddSet(set2);
            workout.AddRound(round);
            round.AddExercise(exercise);

            Assert.AreEqual(_length.TotalSeconds * 2, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_SetLengthChanged_RoundLength_Matches()
        {
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            exercise.AddSet(set);
            round.AddExercise(exercise);

            var newTimeLength = new TimeSpan(0, 7, 30);
            set.ChangedLength(newTimeLength);

            Assert.AreEqual(newTimeLength.TotalSeconds, round.Length.TotalSeconds);
        }

        [Test]
        public void Test_SetLengthChanged_WorkoutLength_Matches()
        {
            var workout = new Workout("Workout ");
            var round = new Round("Round 1");
            var exercise = new Exercise("Exercise 1");
            var set = new Set(_length);

            workout.AddRound(round);
            round.AddExercise(exercise);
            exercise.AddSet(set);

            var newTimeLength = new TimeSpan(0, 7, 30);
            set.ChangedLength(newTimeLength);

            Assert.AreEqual(newTimeLength.TotalSeconds, workout.Length.TotalSeconds);
        }

        [Test]
        public void Test_SetLengthChanged_Exception()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(changeSetLength));

            void changeSetLength()
            {
                var round = new Round("Round 1");
                var exercise = new Exercise("Exercise 1");
                var set = new Set(_length);

                exercise.AddSet(set);
                round.AddExercise(exercise);

                set.ChangedLength(new TimeSpan());
            }
        }
    }
}
