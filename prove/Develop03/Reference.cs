using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMasterySharp
{
	public class Reference
	{
		// _attributes here, following _camelCase convention.
		private List<string> _masteryIndex; // All scripture lines loaded from the CSV (without header)
		private Random _rand;
		public bool _isEmpty = false;
		public string _masteryReference { get; private set; } = string.Empty;
		public List<Scripture> _scriptures { get; private set; } = new List<Scripture>();

		public Reference(string filePath)
		{
			// This validates the filepath and checks content for the presence of entries.
			if (!File.Exists(filePath))
			{
				Console.WriteLine("File does not exist.");
				_isEmpty = true;
				return;
			}
			string[] allLines = File.ReadAllLines(filePath);
			if (allLines.Length < 2)
			{
				Console.WriteLine("The file does not contain any scripture entries.");
				_isEmpty = true;
				return;
			}

			// Removes the header and initializes
			_masteryIndex = new List<string>(allLines[1..]);
			_rand = new Random();
		}

		// Returns true if there are still scriptures that have not been used.
		public bool HasMoreScriptures()
		{
			return _masteryIndex != null && _masteryIndex.Count > 0;
		}

		// Selects a random scripture mastery from the remaining options.
		public bool SelectRandomScripture()
		{
			// Checks if there are any scriptures left to learn.
			if (!HasMoreScriptures())
			{
				return false;
			}

			// Selects a random index and removes the selected index from future options.
			int index = _rand.Next(_masteryIndex.Count);
			string selectedLine = _masteryIndex[index];
			_masteryIndex.RemoveAt(index);

			// CSV expected format: reference, """ScriptureVerse1"" | ""OptionalVerse2"""
			int firstComma = selectedLine.IndexOf(',');
			if (firstComma < 0)
			{
				Console.WriteLine("The CSV file is written incorrectly and is missing a comma");
				return false;
			}

			// Extracts mastery reference and scripture test, then removes excess quotes.
			_masteryReference = selectedLine.Substring(0, firstComma).Trim();
			string scriptureText = selectedLine.Substring(firstComma + 1).Trim();
			scriptureText = scriptureText.Substring(1, scriptureText.Length - 2);

			// Split scriptureText by the "|" character to allow for multiple verses as different Scripture objects.
			string[] scriptureParts = scriptureText.Split('|', StringSplitOptions.RemoveEmptyEntries);
			_scriptures.Clear();
			foreach (string part in scriptureParts)
			{
				_scriptures.Add(new Scripture(part.Trim()));
			}

			return true;
		}
	}
}