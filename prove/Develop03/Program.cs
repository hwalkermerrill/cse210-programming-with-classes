using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMasterySharp
{
	class Program
	{
		// _attributes here, following _camelCase convention.
		private string _filePath = "ScriptureMastery.csv";
		private bool _quit = false;
		public Reference _referenceObject;

		static void Main(string[] args)
		{
			Program program = new Program();
			if (!program.ValidateReference())
			{
				Console.WriteLine("Exiting the program due to validation failure.");
				return;
			}
			else
			{
				do // Run at least once
				{
					program.MemorizeScripture();

					// Fun congratulations message for memorizing all of the scripturesA
					if (!program._referenceObject.HasMoreScriptures())
					{
						Console.WriteLine("You have mastered this! Go forth as a Disciple of Jesus Christ, the Son of God, commissioned to say and do what He Himself would say and do if He personally were ministering to the very people to whom He has sent you!");
						break;
					}

					// This loops allows the user to move on to a new scripture, if desired.
					Console.WriteLine("Would you like to practice memorizing another scripture? (y/n):");
					string userChoice = Console.ReadLine().Trim().ToLower();
					if (userChoice == "y")
					{
						program._quit = false; // Reset the quit flag and try again.
					}
					else { break; }
				} while (true);
			}
			;
		}

		public bool ValidateReference()
		{
			// This constructor loads all entries for the _referenceObject.
			_referenceObject = new Reference(_filePath);

			// Registers if file validation fails.
			if (_referenceObject._isEmpty)
			{
				Console.WriteLine("There are no scriptures to master.");
				return false;
			}
			else { return true; }
		}

		private void MemorizeScripture()
		{
			// Displays error if no random scripture can be selected.
			if (!_referenceObject.SelectRandomScripture())
			{
				Console.WriteLine("No scripture could be selected.");
				return;
			}

			// Retrieve the mastery reference and the list of Scripture objects.
			string masteryReference = _referenceObject._masteryReference;
			List<Scripture> scriptures = _referenceObject._scriptures;

			// Display the scripture in full on first load.
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

				// Gathers all visible words.
				List<Word> visibleWords = new List<Word>();
				foreach (Scripture scripture in scriptures)
				{
					visibleWords.AddRange(scripture._words.Where(word => !word._isHidden));
				}

				if (visibleWords.Any())
				{
					// Create one Random instance and hide one word.
					Random rand = new Random();
					int index = rand.Next(visibleWords.Count);
					visibleWords[index]._isHidden = true;
				}
				else
				{
					Console.WriteLine("You have mastered this scripture!");
					Console.WriteLine("Press Enter to continue.");
					Console.ReadLine();
					break;
				}
			}
			// After finishing the scripture, reset _quit flag.
			_quit = false;
		}
	}
}