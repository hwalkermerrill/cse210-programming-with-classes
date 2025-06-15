using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMasterySharp
{
	class Program
	{
		// all attributes are private, using _camelCase naming convention.
		private const string _filePath = "ScriptureMastery.csv";
		private static Random _random = new Random();

		static void Main(string[] args)
		{
			// Load every CSV record (skip header) into a list.
			List<string> remainingScriptures = LoadScriptureMastery();
			if (remainingScriptures == null || remainingScriptures.Count == 0) return;

			// Main loop continues until the user quits or completes the CSV file.
			while (remainingScriptures.Count > 0)
			{
				// Pick and remove one random row from the bank.
				int pick = _random.Next(remainingScriptures.Count);
				string picked = remainingScriptures[pick];
				remainingScriptures.RemoveAt(pick);

				// Skip empty lines or whitespace.
				Scripture scripture = BuildScripture(picked);
				if (scripture == null) continue;

				RunMemorizeLoop(scripture);

				// Check if there are any verses left.
				if (remainingScriptures.Count == 0)
				{
					Console.WriteLine(
						"\nYou have mastered every scripture mastery passage!" +
						"\nGo forth as a Disciple of Jesus Christ, the Son of God, commissioned to say and do what He Himself would say and do if he were personally ministering to the people to whom he has sent you.");
					break;
				}

				// Ask if they want another scripture mastery round.
				Console.WriteLine($"\nYou have {remainingScriptures.Count} scripture{(remainingScriptures.Count == 1 ? "" : "s")} left to master.");
				Console.Write(
					"\nWould you like to practice another scripture?" +
					"\n(type 'y' or press [Enter] to continue, or type 'n' to quit): ");
				string choice = Console.ReadLine().Trim().ToLower();
				if (choice == "n") break;
			}
		}

		// Convert the CSV file into a list of scripture mastery entries.
		private static List<string> LoadScriptureMastery()
		{
			if (!File.Exists(_filePath))
			{
				Console.WriteLine("Scripture file not found.");
				return null;
			}

			string[] lines = File.ReadAllLines(_filePath);
			if (lines.Length < 2)
			{
				Console.WriteLine("No scripture entries found.");
				return null;
			}

			// Skip the header line and return the rest as a list.
			return new List<string>(lines[1..]);
		}

		// Convert a CSV line into a Scripture object.
		private static Scripture BuildScripture(string csvLine)
		{
			string[] parts = csvLine.Split(',', 3);
			if (parts.Length < 3)
			{
				Console.WriteLine($"Malformed CSV row:\n{csvLine}");
				return null;
			}
			string book = parts[0].Trim();
			string chapterVerse = parts[1].Trim();
			string scriptureText = parts[2].Trim().Trim('"');

			try
			{
				Reference reference = Reference.ParseReference(book, chapterVerse);
				return new Scripture(reference, scriptureText);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error parsing reference in row:\n{csvLine}\n{ex.Message}");
				return null;
			}
		}

		// Main loop for memorizing a single scripture.
		private static void RunMemorizeLoop(Scripture scripture)
		{
			bool quitThisScripture = false;

			while (!quitThisScripture)
			{
				Console.Clear();
				Console.WriteLine(scripture.GetDisplayText());
				Console.WriteLine("\nPress Enter to hide a word, or type 'quit' to exit this verse:");

				string input = Console.ReadLine();
				if (input.Trim().ToLower() == "quit")
				{
					// leave the verse unfinished, go back to main menu
					quitThisScripture = true;
					continue;
				}

				scripture.HideRandomWord();

				if (scripture.AllWordsHidden())
				{
					Console.Clear();
					Console.WriteLine(scripture.GetDisplayText());
					Console.WriteLine("\nYou have mastered this scripture!");
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					break;
				}
			}
		}
	}
}