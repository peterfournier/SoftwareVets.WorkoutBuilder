using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV.Builder.WorkoutManagement.Tests.ExerciseSetTests
{
    public class EnduranceSetDurationTests
    {
        private TimeSpan _expectedDuration;
        private int _expectedSeconds = 30;
        private Workout _workout;

        [SetUp]
        public void Setup()
        {
            _workout = new Workout("Workout Name");
            _expectedDuration = new TimeSpan(0, 0, _expectedSeconds);
        }

        [Test]
        public void RoundLength_Matches()
        {
            var round = new Round(_workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            exercise.AddSet(set);
            round.AddExercise(exercise);

            Assert.AreEqual(_expectedDuration.TotalSeconds, round.Duration.TotalSeconds);
        }

        private EnduranceSet createDefaultEnduranceSet(Exercise exercise)
        {
            return new EnduranceSet(exercise.ID, _expectedDuration);
        }

        [Test]
        public void RoundLength_Matches_v2()
        {
            var round = new Round(_workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            round.AddExercise(exercise);
            exercise.AddSet(set);

            Assert.AreEqual(_expectedDuration.TotalSeconds, round.Duration.TotalSeconds);
        }

        [Test]
        public void MultipleSets_RoundLength_Matches()
        {
            var round = new Round(_workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);
            var set2 = createDefaultEnduranceSet(exercise);

            exercise.AddSet(set);
            exercise.AddSet(set2);
            round.AddExercise(exercise);

            Assert.AreEqual(_expectedDuration.TotalSeconds * 2, round.Duration.TotalSeconds);
        }

        [Test]
        public void Multiple_RoundLength_Matches_v2()
        {
            var round = new Round(_workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);
            var set2 = createDefaultEnduranceSet(exercise);

            round.AddExercise(exercise);
            exercise.AddSet(set);
            exercise.AddSet(set2);

            Assert.AreEqual(_expectedDuration.TotalSeconds * 2, round.Duration.TotalSeconds);
        }

        [Test]
        public void WorkoutLength_Matches()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            workout.AddRound(round);
            round.AddExercise(exercise);
            exercise.AddSet(set);

            Assert.AreEqual(_expectedDuration.TotalSeconds, workout.Duration.TotalSeconds);
        }

        [Test]
        public void WorkoutLength_Matches_v2()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            workout.AddRound(round);
            exercise.AddSet(set);
            round.AddExercise(exercise);

            Assert.AreEqual(_expectedDuration.TotalSeconds, workout.Duration.TotalSeconds);
        }

        [Test]
        public void WorkoutLength_Matches_v3()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            round.AddExercise(exercise);
            workout.AddRound(round);
            exercise.AddSet(set);

            Assert.AreEqual(_expectedDuration.TotalSeconds, workout.Duration.TotalSeconds);
        }

        [Test]
        public void WorkoutLength_Matches_v4()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            round.AddExercise(exercise);
            exercise.AddSet(set);
            workout.AddRound(round);

            Assert.AreEqual(_expectedDuration.TotalSeconds, workout.Duration.TotalSeconds);
        }

        [Test]
        public void WorkoutLength_Matches_v5()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            exercise.AddSet(set);
            round.AddExercise(exercise);
            workout.AddRound(round);

            Assert.AreEqual(_expectedDuration.TotalSeconds, workout.Duration.TotalSeconds);
        }

        [Test]
        public void WorkoutLength_Matches_v6()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            exercise.AddSet(set);
            workout.AddRound(round);
            round.AddExercise(exercise);

            Assert.AreEqual(_expectedDuration.TotalSeconds, workout.Duration.TotalSeconds);
        }

        [Test]
        public void MultipleSets_WorkoutLength_Matches()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);
            var set2 = createDefaultEnduranceSet(exercise);

            workout.AddRound(round);
            round.AddExercise(exercise);
            exercise.AddSet(set);
            exercise.AddSet(set2);

            Assert.AreEqual(_expectedDuration.TotalSeconds * 2, workout.Duration.TotalSeconds);
        }

        [Test]
        public void MultipleSets_WorkoutLength_Matches_v2()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);
            var set2 = createDefaultEnduranceSet(exercise);

            workout.AddRound(round);
            exercise.AddSet(set);
            exercise.AddSet(set2);
            round.AddExercise(exercise);

            Assert.AreEqual(_expectedDuration.TotalSeconds * 2, workout.Duration.TotalSeconds);
        }

        [Test]
        public void MultipleSets_WorkoutLength_Matches_v3()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);
            var set2 = createDefaultEnduranceSet(exercise);

            round.AddExercise(exercise);
            workout.AddRound(round);
            exercise.AddSet(set);
            exercise.AddSet(set2);

            Assert.AreEqual(_expectedDuration.TotalSeconds * 2, workout.Duration.TotalSeconds);
        }

        [Test]
        public void MultipleSets_WorkoutLength_Matches_v4()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);
            var set2 = createDefaultEnduranceSet(exercise);

            round.AddExercise(exercise);
            exercise.AddSet(set);
            exercise.AddSet(set2);
            workout.AddRound(round);

            Assert.AreEqual(_expectedDuration.TotalSeconds * 2, workout.Duration.TotalSeconds);
        }

        [Test]
        public void MultipleSets_WorkoutLength_Matches_v5()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);
            var set2 = createDefaultEnduranceSet(exercise);

            exercise.AddSet(set);
            exercise.AddSet(set2);
            round.AddExercise(exercise);
            workout.AddRound(round);

            Assert.AreEqual(_expectedDuration.TotalSeconds * 2, workout.Duration.TotalSeconds);
        }

        [Test]
        public void MultipleSets_WorkoutLength_Matches_v6()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);
            var set2 = createDefaultEnduranceSet(exercise);

            exercise.AddSet(set);
            exercise.AddSet(set2);
            workout.AddRound(round);
            round.AddExercise(exercise);

            Assert.AreEqual(_expectedDuration.TotalSeconds * 2, workout.Duration.TotalSeconds);

        }

        [Test]
        public void SetLengthChanged_RoundLength_Matches()
        {
            var round = new Round(_workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            exercise.AddSet(set);
            round.AddExercise(exercise);

            var newTimeLength = new TimeSpan(0, 7, 30);
            set.ChangedDuration(newTimeLength);

            Assert.AreEqual(newTimeLength.TotalSeconds, round.Duration.TotalSeconds);
        }

        [Test]
        public void SetLengthChanged_WorkoutLength_Matches()
        {
            var workout = new Workout("Workout ");
            var round = new Round(workout.ID, "Round 1");
            var exercise = new Exercise(round.ID, "Exercise 1");
            var set = createDefaultEnduranceSet(exercise);

            workout.AddRound(round);
            round.AddExercise(exercise);
            exercise.AddSet(set);

            var newTimeLength = new TimeSpan(0, 7, 30);
            set.ChangedDuration(newTimeLength);

            Assert.AreEqual(newTimeLength.TotalSeconds, workout.Duration.TotalSeconds);
        }

        [Test]
        public void SetLengthChanged_Exception()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), new TestDelegate(changeSetLength));

            void changeSetLength()
            {
                var round = new Round(_workout.ID, "Round 1");
                var exercise = new Exercise(round.ID, "Exercise 1");
                var set = createDefaultEnduranceSet(exercise);

                exercise.AddSet(set);
                round.AddExercise(exercise);

                set.ChangedDuration(new TimeSpan());
            }
        }
    }
}
