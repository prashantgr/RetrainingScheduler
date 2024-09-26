using RetrainingScheduler;

class Program
{
	static void Main(string[] args)
	{
		List<Talk> talks = new List<Talk>
		{
			new Talk("Organising Parents for Academy Improvements", "60min"),
			new Talk("Teaching Innovations in the Pipeline", "45min"),
			new Talk("Teacher Computer Hacks", "30min"),
			new Talk("Making Your Academy Beautiful", "45min"),
			new Talk("Parent Teacher Conferences", "60min"),
			new Talk("Academy Tech Field Repair", "45min"),
			new Talk("Managing Your Dire Allowance", "45min"),
			new Talk("Customer Care", "30min"),
			new Talk("AIMs – 'Managing Up'", "30min"),
			new Talk("Public Works in Your Community", "30min"),


			new Talk("Hiring the Right Cook", "60min"),
			new Talk("Government Policy Changes and New Globe", "60min"),
			new Talk("Talking To Parents About Billing", "30min"),
			new Talk("Two-Streams or Not Two-Streams", "30min"),
			new Talk("Dealing with Problem Teachers", "45min"),
			new Talk("Adjusting to Relocation", "45min"),
			new Talk("Piped Water", "30min"),
			new Talk("So They Say You're a Devil Worshipper", "60min"),
			new Talk("Sync Hard", "lightning"),
			new Talk("Unusual Recruiting", "lightning"),
		};

		ConferenceScheduler scheduler = new ConferenceScheduler(talks);
		scheduler.Schedule();
		scheduler.PrintSchedule();
	}
}


