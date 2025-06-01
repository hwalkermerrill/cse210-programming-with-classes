// Program.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMasterySharp
{
	class Program
	{
		// _attributes: file path must be specified correctly.
		private string _filePath = "ScriptureMastery.csv";
		private bool _quit = false;
		// Instead of a simple string reference, we now have a Reference object.
		public Reference _referenceObject;

		static void Main(string[] args)
		{
			// Create an instance of Program and run the main loop.
			Program program = new Program();
			program.Run();
		}

		public void Run()
		{
			// Initialize the Reference object. The constructor loads all entries.
			_referenceObject = new Reference(_filePath);

			// If there are no scriptures loaded, exit immediately.
			if (_referenceObject.IsEmpty)
			{
				Console.WriteLine("No scripture entries available.");
				return;
			}

			// At least one scripture must be memorized
			do
			{
				MemorizeScripture();

				// Ask if the user wants to memorize another scripture (if any remain)
				if (!_referenceObject.HasMoreScriptures())
				{
					Console.WriteLine("All scriptures have been memorized. Congratulations!");
					break;
				}

				Console.WriteLine("Would you like to memorize another scripture? (y/n):");
				string userChoice = Console.ReadLine().Trim().ToLower();
				if (userChoice == "y")
				{
					_quit = false; // Reset the quit flag and try again.
				}
				else
				{
					break;
				}
			} while (true);
		}

		private void MemorizeScripture()
		{
			// Ask the reference object to select a random scripture.
			if (!_referenceObject.SelectRandomScripture())
			{
				Console.WriteLine("No scripture could be selected.");
				return;
			}

			// Retrieve the mastery reference and the list of Scripture objects.
			string masteryReference = _referenceObject.MasteryReference;
			List<Scripture> scriptures = _referenceObject.Scriptures;

			// Display the scripture initially as written.
			while (!_quit)
			{
				Console.Clear();
				Console.WriteLine(masteryReference);
				Console.WriteLine();
				foreach (Scripture scripture in scriptures)
				{
					Console.WriteLine(scripture.GetDisplayText());
				}

				Console.WriteLine("\nPress Enter to hide a word, or type 'quit' to finish this scripture:");
				string input = Console.ReadLine();
				if (input.Trim().ToLower() == "quit")
				{
					_quit = true;
					continue;
				}

				// Gather all visible words from all scripture verses.
				List<Word> visibleWords = new List<Word>();
				foreach (Scripture scripture in scriptures)
				{
					visibleWords.AddRange(scripture.Words.Where(word => !word.IsHidden));
				}

				if (visibleWords.Any())
				{
					// Create one Random instance and hide one word.
					Random rand = new Random();
					int index = rand.Next(visibleWords.Count);
					visibleWords[index].IsHidden = true;
				}
				else
				{
					Console.WriteLine("All words are hidden.");
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					break;
				}
			}
			// After finishing one scripture, reset _quit for the next round.
			_quit = false;
		}
	}
}