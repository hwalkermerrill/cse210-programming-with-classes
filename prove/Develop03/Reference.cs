// Reference.cs
using System;
using System.Collections.Generic;
using System.IO;

namespace ScriptureMasterySharp
{
	public class Reference
	{
		// _attributes follow underscore_camelCase.
		private string _filePath;
		private List<string> _lines; // All scripture lines loaded from the CSV (without header)
		private Random _rand;
		private bool _isEmpty = false;

		// Public properties to expose the mastery reference and the parsed scripture passages.
		public string MasteryReference { get; private set; } = string.Empty;
		public List<Scripture> Scriptures { get; private set; } = new List<Scripture>();

		public bool IsEmpty => _isEmpty;

		// The constructor loads the CSV file and removes the header.
		public Reference(string filePath)
		{
			_filePath = filePath;
			if (!File.Exists(_filePath))
			{
				Console.WriteLine("File does not exist.");
				_isEmpty = true;
				return;
			}

			string[] allLines = File.ReadAllLines(_filePath);
			if (allLines.Length < 2)
			{
				Console.WriteLine("The file does not contain any scripture entries.");
				_isEmpty = true;
				return;
			}

			// Remove the header (first line)
			_lines = new List<string>(allLines[1..]);
			_rand = new Random();
		}

		// Returns true if there are still scriptures that have not been used.
		public bool HasMoreScriptures()
		{
			return _lines != null && _lines.Count > 0;
		}

		// Selects a random scripture line from the remaining lines.
		// It sets MasteryReference and instantiates Scripture objects for each verse.
		public bool SelectRandomScripture()
		{
			if (!HasMoreScriptures())
			{
				return false;
			}

			int index = _rand.Next(_lines.Count);
			string selectedLine = _lines[index];
			// Remove the selected line so it won’t be chosen again.
			_lines.RemoveAt(index);

			// CSV expected format: reference, "scripture text"
			int firstComma = selectedLine.IndexOf(',');
			if (firstComma < 0)
			{
				Console.WriteLine("Malformed line in CSV.");
				return false;
			}

			// The mastery reference is in the first column.
			MasteryReference = selectedLine.Substring(0, firstComma).Trim();

			// The scripture text is in the second column.
			string scriptureText = selectedLine.Substring(firstComma + 1).Trim();
			if (scriptureText.StartsWith("\"") && scriptureText.EndsWith("\""))
			{
				scriptureText = scriptureText.Substring(1, scriptureText.Length - 2);
			}

			// Split scriptureText by the "|" character to allow multiple verses.
			string[] scriptureParts = scriptureText.Split('|', StringSplitOptions.RemoveEmptyEntries);

			// Create a new Scripture object for each scripture part.
			Scriptures.Clear();
			foreach (string part in scriptureParts)
			{
				Scriptures.Add(new Scripture(part.Trim()));
			}

			return true;
		}
	}
}