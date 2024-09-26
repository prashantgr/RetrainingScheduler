using System;
using System.Collections.Generic;
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

	public Session(int maxDuration, DateTime startTime)
	{
		Talks = new List<Talk>();
		MaxDuration = maxDuration;
		RemainingTime = maxDuration;
		StartTime = startTime;
	}

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

	public void PrintSession(ref DateTime currentTime)
	{
		foreach (var talk in Talks)
		{
			if (talk.Duration == 5)
			{
				Console.WriteLine($"{currentTime:hh:mmtt} | {talk.Title} | lightning");
			}
			else
			{
				Console.WriteLine($"{currentTime:hh:mmtt} | {talk.Title} | {talk.Duration}min");
			}
			currentTime = currentTime.AddMinutes(talk.Duration);
		}
	}
}



