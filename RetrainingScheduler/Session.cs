using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetrainingScheduler;

public class Session
{
	public List<Talk> Talks { get; private set; }
	public int MaxDuration { get; private set; }
	public int RemainingTime { get; private set; }
	public DateTime StartTime { get; private set; }

	// Constructor
	public Session(int maxDuration, DateTime startTime)
	{
		Talks = new List<Talk>();
		MaxDuration = maxDuration;
		RemainingTime = maxDuration;
		StartTime = startTime;
	}

	// Add talk to session
	public bool AddTalk(Talk talk)
	{
		if (talk.Duration <= RemainingTime)
		{
			Talks.Add(talk);
			RemainingTime -= talk.Duration;
			return true;
		}
		return false;
	}

	// Check if session is full
	public void PrintSession(ref DateTime currentTime)
	{
		foreach (var talk in Talks)
		{
			if (talk.Duration == 5)
			{
				Console.WriteLine($"{currentTime.ToString("hh:mmtt", CultureInfo.InvariantCulture).ToUpper()} | {talk.Title} | lightning");
			}
			else
			{
				Console.WriteLine($"{currentTime.ToString("hh:mmtt", CultureInfo.InvariantCulture).ToUpper()} | {talk.Title} | {talk.Duration}min");
			}
			currentTime = currentTime.AddMinutes(talk.Duration);
		}
	}
  
}



