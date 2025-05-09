using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

public class Journal
{
	public void DisplayJournal()
	{
		// Read the journal entries from the CSV file
		using (StreamReader jEntry = new StreamReader("journal.csv"))
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
	// public void WriteJournal()
	// {
	//     // Write the journal entries to the CSV file
	//     public string _prompt;
	//     DateTime currentDate = DateTime.Today;
	//     public string _entry;

	//     using (StreamWriter jEntry = new StreamWriter("journal.csv", true))
	//     {
	//         jEntry.WriteLine($"{currentDate},{_prompt},{_entry}");
	//     }

	// }
}