using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class Journal
{
	public string _filePath = "journal.csv";
	public void SetFilePath(string newPath)
	{
		// Set a new filepath for the journal, with validation
		if (string.IsNullOrWhiteSpace(newPath))
		{
			Console.WriteLine("Invalid file path. Keeping the current path.");
			return;
		}
		else
		{
			_filePath = newPath;
			Console.WriteLine($"File path set to: {_filePath}");
		}
	}
	public void DisplayJournal()
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
	public void WriteJournal()
	{
		// Write the journal entries to the CSV file
		Prompts prompts = new Prompts();
		string prompt = prompts.Prompt();

		Console.WriteLine("\nWrite your journal entry for today while considering the following prompt: " + prompt);
		Console.WriteLine("Press enter when you are finished writing your entry.\n");
		string entry = Console.ReadLine();
		DateTime todayDate = DateTime.Today;
		string currentDate = todayDate.ToString("MM/dd/yyyy");

		using (StreamWriter jEntry = new StreamWriter(_filePath, true))
		{
			jEntry.WriteLine($"\"{entry}\", Prompt: {prompt}, - {currentDate}");
		}
		Console.WriteLine("\nYour entry has been saved.");
	}
}