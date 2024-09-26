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

	public Track(int trackNumber)
	{
		TrackNumber = trackNumber;
		MorningSession = new Session(180, new DateTime(1, 1, 1, 9, 0, 0));  // 9:00 AM - 12:00 PM
		AfternoonSession = new Session(240, new DateTime(1, 1, 1, 13, 0, 0)); // 1:00 PM - 4:00 PM
	}

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
