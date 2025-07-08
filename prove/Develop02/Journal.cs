using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
	// _attributes here
	private List<Entry> _entries = new List<Entry>();
	public string SetFilePath(string currentPath, string newPath)
	{
		// Set a new filepath for the journal, with validation
		if (string.IsNullOrWhiteSpace(newPath))
		{
			Console.WriteLine("Invalid file path. Keeping the current path.");
			return currentPath;
		}
		else
		{
			Console.WriteLine($"File path set to: {newPath}");
			return newPath;
		}
	}
	public void DisplayJournal(string _filePath)
	{
		_entries.Clear();

		// Check if the journal file exists
		if (!File.Exists(_filePath))
		{
			Console.WriteLine("No journal entries found.");
			return;
		}

		// Read the journal entries from the CSV file
		using (StreamReader jEntry = new StreamReader(_filePath))
		{
			jEntry.ReadLine(); // Skip the header line
			while (!jEntry.EndOfStream)
			{
				string line = jEntry.ReadLine();
				int quoteEnd = line.IndexOf("\",", 1);
				if (quoteEnd < 0) quoteEnd = line.Length;

				string jText = line.Substring(1, quoteEnd - 1);
				string remainder = line.Substring(quoteEnd + 2);

				var jParts = remainder.Split(',', 2);
				var jPrompt = jParts[0].Trim();
				var jDate = DateTime.Parse(jParts[1].Trim());

				_entries.Add(new Entry(jText, jPrompt, jDate));
			}

			Console.WriteLine("Here are your past journal entries:\n");
			foreach (var entry in _entries)
			{
				entry.DisplayEntry();
				Console.WriteLine("----------NEXT ENTRY----------\n");
			}
		}
	}
}