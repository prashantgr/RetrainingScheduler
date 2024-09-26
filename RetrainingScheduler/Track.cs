using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrainingScheduler;

public class Track
{
	public int TrackNumber { get; private set; }
	public Session MorningSession { get; private set; }
	public Session AfternoonSession { get; private set; }

	// Constructor
	public Track(int trackNumber)
	{
		TrackNumber = trackNumber;
		// Morning session is 180 minutes (3 hours)
		MorningSession = new Session(180, new DateTime(1, 1, 1, 9, 0, 0));  // 9:00 AM - 12:00 PM
		// Afternoon session is 240 minutes (4 hours)
		AfternoonSession = new Session(240, new DateTime(1, 1, 1, 13, 0, 0)); // 1:00 PM - 5:00 PM
	}

	// Add talk to track
	public void PrintTrack()
	{
		Console.WriteLine($"Track {TrackNumber}");

		DateTime currentTime = MorningSession.StartTime;
		MorningSession.PrintSession(ref currentTime);

		Console.WriteLine("12:00PM | Lunch |");

		currentTime = AfternoonSession.StartTime;
		AfternoonSession.PrintSession(ref currentTime);

		Console.WriteLine("05:00PM | Sharing Session |");
	}

}
