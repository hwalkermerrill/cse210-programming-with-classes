using System;
using System.Collections.Generic;

namespace ZamirasFitnessTracker
{
	// Meets requirements: I realized I don't need to exceed requirements on this rubric... so I didn't. But If I'm wrong, let me know.
  public class Program
	{
		// methods here
		public static void Main(string[] args)
		{
			var activities = InitializeActivities();

			Console.WriteLine("!!!BARBARIAN STRONG!!!   !!!WORKOUT SUMMARY!!!\n");
			DisplaySummaries(activities);
		}

		static void DisplaySummaries(List<Activity> activities)
		{
			foreach (var activity in activities)
			{
				Console.WriteLine(activity.GetSummary());
				Console.WriteLine(new string('=', 32));
			}
		}

		static List<Activity> InitializeActivities()
		{
			return new List<Activity>
			{
        // one of each activity for output proof purposes
        new Running(
					new DateTime(2025, 7, 24),
					60,
					8.0
				),

				new Cycling(
					new DateTime(2025, 7, 24),
					45,
					15.5
				),

				new Swimming(
					new DateTime(2025, 7, 24),
					20,
					20
				)
			};
		}
	}
}