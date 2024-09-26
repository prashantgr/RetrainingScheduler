using System;
using System.Collections.Generic;

namespace RetrainingScheduler;

public class Talk
{
	public string Title { get; set; }
	public int Duration { get; set; }  // Duration in minutes

	public Talk(string title, string duration)
	{
		Title = title;
		Duration = ParseDuration(duration);
	}

	private int ParseDuration(string duration)
	{
		if (duration.Equals("lightning", StringComparison.OrdinalIgnoreCase))
		{
			return 5; // 5 minutes for lightning talks
		}

		if (duration.EndsWith("min"))
		{
			// Check for valid integer before parsing
			if (int.TryParse(duration.Replace("min", ""), out int time))
			{
				return time;
			}
		}

		throw new ArgumentException("Invalid duration format.");
	}

	public override string ToString()
	{
		return $"{Title} ({Duration}min)";
	}
}
