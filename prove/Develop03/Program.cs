using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMasterySharp
{
	class Program
	{
		// All attributes are private, using _camelCase naming convention.
		private string _filePath = "ScriptureMastery.csv";
		private bool _quit = false;

		static void Main(string[] args)
		{
			Program program = new Program();
			Scripture scripture = program.GetRandomScripture();
			if (scripture == null)
			{
				Console.WriteLine("No scripture available.");
				return;
			}

			// Main loop: the scripture is shown and one word is hidden with each Enter.
			while (!program._quit)
			{
				Console.Clear();
				Console.WriteLine(scripture.GetDisplayText());
				Console.WriteLine("\nPress Enter to hide a word, or type 'quit' to finish:");
				string input = Console.ReadLine();
				if (input.Trim().ToLower() == "quit")
				{
					program._quit = true;
				}
				else
				{
					scripture.HideRandomWord();
					if (scripture.AllWordsHidden())
					{
						Console.WriteLine("\nYou have mastered this scripture!");
						Console.WriteLine("Press Enter to exit.");
						Console.ReadLine();
						break;
					}
				}
			}
		}

		// Reads the CSV file, selects a random scripture line.
		// Then create a Scripture object (which holds both the reference book, number, and text).
		private Scripture GetRandomScripture()
		{
			if (!File.Exists(_filePath))
			{
				Console.WriteLine("Scripture file not found.");
				return null;
			}

			string[] allLines = File.ReadAllLines(_filePath);
			if (allLines.Length < 2)
			{
				Console.WriteLine("No scripture entries found.");
				return null;
			}

			// Skip the header line.
			List<string> scriptureLines = new List<string>(allLines[1..]);
			Random rand = new Random();
			int index = rand.Next(scriptureLines.Count);
			string selectedLine = scriptureLines[index];

			// Break the CSV row into three parts based on the first two commas.
			string[] parts = selectedLine.Split(new char[] { ',' }, 3);
			if (parts.Length < 3)
			{
				Console.WriteLine("CSV format error: Expected 3 fields (book, chapter:verse, scripture text).");
				return null;
			}

			// Retrieve each field.
			string book = parts[0].Trim();
			string chapterVerse = parts[1].Trim();
			string scriptureText = parts[2].Trim();

			// Remove any extraneous quotes from scriptureText.
			scriptureText = scriptureText.Trim('"');

			try
			{
				Reference reference = Reference.ParseReference(book, chapterVerse);
				return new Scripture(reference, scriptureText);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error parsing reference: " + ex.Message);
				return null;
			}
		}
	}
}