using RetrainingScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrainingSchedulerTests;

public class AllInOneTests
{
    public class ConferenceSchedulerTests
    {
        //skip test

        [Fact]
        public void Schedule_ShouldCreateTracksAndScheduleTalks()
        {
            // Arrange
            var talks = new List<Talk>
            {
                new Talk("Talk 1", "60min"),
                new Talk("Talk 2", "45min"),
                new Talk("Talk 3", "30min"),
                new Talk("Talk 4", "30min"),
                new Talk("Talk 5", "lightning"),
                new Talk("Talk 6", "60min"),
                new Talk("Talk 7", "45min"),
                new Talk("Talk 8", "45min"),
                new Talk("Talk 9", "60min"),
                new Talk("Talk 10", "45min")
            };

            ConferenceScheduler scheduler = new ConferenceScheduler(talks);

            // Act
            scheduler.Schedule();

            // Assert
            Assert.Equal(2, scheduler.Tracks.Count); // Assuming the talks will fit in 2 tracks
            Assert.Equal(0, scheduler.Talks.Count); // Should be empty after scheduling
        }

        [Fact]
        public void Schedule_ShouldNotScheduleMoreTalksThanAvailableTime()
        {
            // Arrange
            var talks = new List<Talk>
            {
                new Talk("Talk 1", "60min"),
                new Talk("Talk 2", "60min"), // This should not fit in a single track
                new Talk("Talk 3", "60min"),
            };

            ConferenceScheduler scheduler = new ConferenceScheduler(talks);

            // Act
            scheduler.Schedule();

            // Assert
            Assert.Single(scheduler.Tracks); // Only one track should be created
            Assert.Empty(scheduler.Talks);   // All talks should have been scheduled
        }
    }

   
    public class SessionTests
    {
        [Fact]
        public void Session_Initialization_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            int maxDuration = 240; // 240 minutes
            DateTime startTime = new DateTime(2024, 9, 25, 9, 0, 0); // 9:00 AM

            // Act
            Session session = new Session(maxDuration, startTime);

            // Assert
            Assert.Equal(maxDuration, session.MaxDuration);
            Assert.Equal(maxDuration, session.RemainingTime);
            Assert.Equal(startTime, session.StartTime);
            Assert.Empty(session.Talks);
        }

        [Fact]
        public void AddTalk_ShouldAddTalk_WhenDurationFits()
        {
            // Arrange
            Session session = new Session(120, DateTime.Now);
            Talk talk = new Talk("Test Talk", "60min"); // 60 minutes

            // Act
            bool result = session.AddTalk(talk);

            // Assert
            Assert.True(result);
            Assert.Single(session.Talks);
            Assert.Equal(60, session.RemainingTime);
        }


        [Fact]
        public void AddTalk_ShouldNotAddTalk_WhenDurationExceedsRemainingTime()
        {
            // Arrange
            Session session = new Session(120, DateTime.Now);
            Talk talk = new Talk("Long Talk", "130min"); // 130 minutes

            // Act
            bool result = session.AddTalk(talk);

            // Assert
            Assert.False(result);
            Assert.Empty(session.Talks); // Should not have added the talk
            Assert.Equal(120, session.RemainingTime);
        }

        //[Fact(Skip = "specific reason")]
        [Fact]
        public void PrintSession_ShouldPrintCorrectly_WhenTalksAdded()
        {
            // Arrange
            var session = new Session(180, new DateTime(1, 1, 1, 9, 0, 0));
            session.AddTalk(new Talk("Talk 1", "60min"));
            session.AddTalk(new Talk("Talk 2", "45min"));
            session.AddTalk(new Talk("Talk 3", "30min"));

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                var currentTime = session.StartTime;
                session.PrintSession(ref currentTime);

                // Assert
                var expectedOutput = "09:00AM | Talk 1 | 60min\r\n" +
                                     "10:00AM | Talk 2 | 45min\r\n" +
                                     "10:45AM | Talk 3 | 30min\r\n";
                Assert.Equal(expectedOutput, sw.ToString());
            }

        }

        [Fact]
        public void AddTalk_ShouldNotAddLightningTalk_WhenDurationExceedsRemainingTime()
        {
            // Arrange
            Session session = new Session(5, DateTime.Now);
            Talk talk = new Talk("Too Long Lightning Talk", "lightning"); // 5 minutes

            // Act
            bool result = session.AddTalk(talk);

            // Assert
            Assert.True(result);
            Assert.Single(session.Talks);
            Assert.Equal(0, session.RemainingTime); // Remaining time should be 0
        }
    }

    public class TalkTests
    {
        [Fact]
        public void Talk_Initialization_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string expectedTitle = "Organising Parents for Academy Improvements";
            string expectedDuration = "60min";
            int expectedDurationInMinutes = 60; // Expected parsed duration

            // Act
            Talk talk = new Talk(expectedTitle, expectedDuration);

            // Assert
            Assert.Equal(expectedTitle, talk.Title);
            Assert.Equal(expectedDurationInMinutes, talk.Duration);
        }

        [Fact]
        public void Talk_Initialization_WithLightning_ShouldSetDurationToFiveMinutes()
        {
            // Arrange
            string expectedTitle = "Sync Hard";
            string expectedDuration = "lightning";
            int expectedDurationInMinutes = 5; // Expected parsed duration

            // Act
            Talk talk = new Talk(expectedTitle, expectedDuration);

            // Assert
            Assert.Equal(expectedTitle, talk.Title);
            Assert.Equal(expectedDurationInMinutes, talk.Duration);
        }

        [Theory]
        [InlineData("30min", 30)]
        [InlineData("45min", 45)]
        [InlineData("60min", 60)]
        public void Talk_Initialization_ShouldParseStandardDurationsCorrectly(string durationInput, int expectedDuration)
        {
            // Arrange
            string title = "Test Talk";

            // Act
            Talk talk = new Talk(title, durationInput);

            // Assert
            Assert.Equal(expectedDuration, talk.Duration);
        }

        [Fact]
        public void Talk_Initialization_WithInvalidDuration_ShouldThrowArgumentException()
        {
            // Arrange
            string title = "Invalid Talk";
            string invalidDuration = "invalid";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Talk(title, invalidDuration));
            Assert.Equal("Invalid duration format.", exception.Message);
        }
    }

    [CollectionDefinition("Non-Parallel Collection", DisableParallelization = true)]
    public class TrackTests
    {
        [Fact]
        public void Track_Initialization_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            int trackNumber = 1;

            // Act
            Track track = new Track(trackNumber);

            // Assert
            Assert.Equal(trackNumber, track.TrackNumber);
            Assert.NotNull(track.MorningSession);
            Assert.NotNull(track.AfternoonSession);
            Assert.Equal(180, track.MorningSession.MaxDuration);
            Assert.Equal(new DateTime(1, 1, 1, 9, 0, 0), track.MorningSession.StartTime); // 9:00 AM
            Assert.Equal(240, track.AfternoonSession.MaxDuration);
            Assert.Equal(new DateTime(1, 1, 1, 13, 0, 0), track.AfternoonSession.StartTime); // 1:00 PM
        }

        [Fact]
        public void PrintTrack_ShouldPrintCorrectly_WhenSessionsAdded()
        {
            // Arrange
            var track = new Track(1);
            track.MorningSession.AddTalk(new Talk("Morning Talk 1", "60min"));
            track.AfternoonSession.AddTalk(new Talk("Afternoon Talk 1", "60min"));
            Thread.Sleep(1000);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                track.PrintTrack();

                // Assert
                var expectedOutput = "Track 1\r\n" +
                                     "09:00AM | Morning Talk 1 | 60min\r\n" +
                                     "12:00PM | Lunch |\r\n" +
                                     "01:00PM | Afternoon Talk 1 | 60min\r\n" +
                                     "05:00PM | Sharing Session |\r\n";

                Assert.Equal(expectedOutput, sw.ToString());
            }
        }

        [Fact]
        public void PrintTrack_ShouldPrintEmptySessions_WhenNoTalksAdded()
        {
            // Arrange
            Track track = new Track(1);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                track.PrintTrack();

                // Assert
                string expectedOutput = "Track 1" + Environment.NewLine +
                                        "12:00PM | Lunch |" + Environment.NewLine +
                                        "05:00PM | Sharing Session |" + Environment.NewLine;
                Assert.Equal(expectedOutput, sw.ToString());
            }
        }
    }
}
