using System;
using System.Collections.Generic;

namespace InheritingTabletopEvents
{
	// Meets requirements: I did what the assignment requested, but I didn't really do anything to go above and beyond.
	// Honestly, I can't really think of how I would do that without adding a lot of time-consuming complexity.
  public class Program
	{
		// methods here
		public static void Main(string[] args)
		{
			var events = InitializeEvents();

			foreach (var evt in events)
			{
				DisplayEvent(evt);
				Console.WriteLine();
				Console.WriteLine(new string('=', 32));
				Console.WriteLine();
			}
		}

		static void DisplayEvent(Event evt)
		{
			Console.WriteLine("----- Standard Details -----");
			Console.WriteLine(evt.GetStandardDetails());
			Console.WriteLine();

			Console.WriteLine("----- Full Details -----");
			Console.WriteLine(evt.GetFullDetails());
			Console.WriteLine();

			Console.WriteLine("----- Short Description -----");
			Console.WriteLine(evt.GetShortDescription());
		}

		static List<Event> InitializeEvents()
		{
			return new List<Event>
			{
				new Lecture(
					"Magical Schools 202",
					"A comparison of specialty schools in the magical world by dedicated universalist, Sir Percival, the Hero of Delvehaven.",
					new DateTime(2025, 8, 25),
					"2:00 PM",
					new Address("#8 Kithrodian Academy, Room #717", "Oppara", "Taldor", "Golarion"),
					"Sir Percival, the Hero of Delvehaven",
					500
				),

				new Reception(
					"Rogue Networking Mixer",
					"Join us for drinks and conversation with industry leaders.",
					new DateTime(2025, 9, 5),
					"6:30 PM",
					new Address("456 Elm Street", "Allbanner", "Taldor", "Golarion"),
					"rsvp@poison.com"
				),

				new OutdoorGathering(
					"Midsummer Festival and Tournament",
					"Celebrate the summer with music, food, and no-lethal sporting! Can you take home the prize?",
					new DateTime(2025, 7, 30),
					"8:00 AM",
					new Address("717 Birdsong Avenue", "Meratt", "Taldor", "Golarion"),
					"Sunny with a light breeze and occasional gusts"
				)
			};
		}
	}
}