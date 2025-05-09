using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class Journal
{
	public void DisplayJournal(string filePath = "journal.csv")
	{
		// Check if the journal file exists
		if (!File.Exists(filePath))
		{
			Console.WriteLine("No journal entries found.");
			return;
		}

		Console.WriteLine("Here are your past journal entries:");
		Console.WriteLine();
		// Read the journal entries from the CSV file
		using (StreamReader jEntry = new StreamReader(filePath))
		{
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
	public void WriteJournal(string filePath = "journal.csv")
	{
		// Write the journal entries to the CSV file
		Prompts prompts = new Prompts();
		string prompt = prompts.Prompt();
		Console.WriteLine("Write your journal entry for today while considering the following prompt: " + prompt);
		Console.WriteLine("Press enter when you are finished writing your entry.");
		Console.WriteLine();
		string entry = Console.ReadLine();
		DateTime todayDate = DateTime.Today;
		string currentDate = todayDate.ToString("MM/dd/yyyy");

		using (StreamWriter jEntry = new StreamWriter(filePath, true))
		{
			jEntry.WriteLine($"{currentDate},{prompt},\"{entry}\"");
		}
		Console.WriteLine();
		Console.WriteLine("Your entry has been saved.");
	}
}