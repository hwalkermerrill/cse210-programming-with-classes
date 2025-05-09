using System;
using System.Collections.Generic;
using System.IO;

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
    public void WriteJournal()
    {
        // Create a new journal entry
        DateTime currentDate = DateTime.Today;
    }
}