using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Journal
{
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
		// Check if the journal file exists
		if (!File.Exists(_filePath))
		{
			Console.WriteLine("No journal entries found.");
			return;
		}

		Console.WriteLine("Here are your past journal entries:\n");

		// Read the journal entries from the CSV file
		using (StreamReader jEntry = new StreamReader(_filePath))
		{
			jEntry.ReadLine(); // Skip the header line
			while (!jEntry.EndOfStream)
			{
				string line = jEntry.ReadLine();
				string[] values = line.Split(',');
				List<string> lists = new List<string>(values);

				foreach (string value in lists)
				{
					Console.Write($"{value} ");
				}
				Console.WriteLine();
			}
		}
	}
}