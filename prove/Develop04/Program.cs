using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
	class Program
	{
		private List<Activity> _activities;

		static void Main(string[] args)
		{
			Program program = new Program();
			program.Run();
		}

		public Program()
		{
			// Initialize the list of activities.
			_activities = new List<Activity>
				{
					new BreathingActivity(),
					new ReflectionActivity(),
					new ListingActivity()
				};
		}

		public void Run()
		{
			bool exitProgram = false;
			while (!exitProgram)
			{
				DisplayMenu();
				Console.Write("Select an activity by number (or 'q' to quit): ");
				string input = Console.ReadLine().Trim().ToLower();
				if (input == "q") break;

				if (int.TryParse(input, out int selection) && selection > 0 && selection <= _activities.Count)
				{
					Activity selectedActivity = _activities[selection - 1];

					// Determine default duration (in minutes) based on type.
					int defaultDuration = (selectedActivity is BreathingActivity) ? 1 : 2;
					Console.Write($"Enter duration in minutes for this activity (max 5, default {defaultDuration}): ");
					string durationInput = Console.ReadLine().Trim();
					double durationMinutes;
					if (string.IsNullOrEmpty(durationInput))
					{
						durationMinutes = defaultDuration;
					}
					else if (double.TryParse(durationInput, out durationMinutes))
					{
						if (durationMinutes > 5)
						{
							Console.WriteLine("Duration exceeds 5 minutes. Reverting down to 5 minutes.");
							durationMinutes = 5;
						}
					}
					else
					{
						durationMinutes = defaultDuration;
					}

					int seconds = (int)Math.Ceiling(durationMinutes * 60);
					selectedActivity.SetDuration(seconds);

					Console.WriteLine($"{selectedActivity} will begin in... ");
					Animation.ShowCountdown(3);
					RunActivity(selectedActivity);
				}

				else
				{
					Console.WriteLine("Invalid selection. Press Enter to try again...");
					Console.ReadLine();
				}
			}
		}

		public void DisplayMenu()
		{
			Console.Clear();
			Console.WriteLine("Mindfulness Program Activities:");
			for (int i = 0; i < _activities.Count; i++)
			{
				// Use _name inherited by derived classes.
				Console.WriteLine($"{i + 1}. {GetActivityName(_activities[i])}");
			}
			Console.WriteLine();
		}

		private string GetActivityName(Activity activity)
		{
			// Since _name is a protected field, this helper uses reflection or you 
			// can declare a public getter in Activity. For a jumping-off point, we'll
			// assume each derived constructor sets the _name appropriately.
			// Here, we simply extract the type name.
			return activity.GetType().Name.Replace("Activity", "");
		}

		public void RunActivity(Activity selectedActivity)
		{
			selectedActivity.DisplayStartMessage();
			if (selectedActivity is BreathingActivity breathing)
			{
				breathing.BreathingCycle();
			}
			else if (selectedActivity is ReflectionActivity reflection)
			{
				reflection.ExecuteReflection();
			}
			else if (selectedActivity is ListingActivity listing)
			{
				listing.CountItems();
			}
			selectedActivity.DisplayEndMessage();

			Console.WriteLine("Press Enter to return to the main menu.");
			Console.ReadLine();
		}
	}
}