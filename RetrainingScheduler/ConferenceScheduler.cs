using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrainingScheduler;


public class ConferenceScheduler
{
	public List<Talk> Talks { get; private set; }
	public List<Track> Tracks { get; private set; }

	public ConferenceScheduler(List<Talk> talks)
	{
		Talks = talks;
		Tracks = new List<Track>();
	}

	public void Schedule()
	{
		int trackNumber = 1;
		while (Talks.Count > 0)
		{
			Track track = new Track(trackNumber);
			FillSession(track.MorningSession);
			FillSession(track.AfternoonSession);
			Tracks.Add(track);
			trackNumber++;
		}
	}

	private void FillSession(Session session)
	{
		List<Talk> scheduledTalks = new List<Talk>();
		foreach (var talk in Talks)
		{
			if (session.AddTalk(talk))
			{
				scheduledTalks.Add(talk);
			}
		}

		foreach (var talk in scheduledTalks)
		{
			Talks.Remove(talk);
		}
	}

	public void PrintSchedule()
	{
		foreach (var track in Tracks)
		{
			track.PrintTrack();
			Console.WriteLine();
		}
	}
}



