using System;

// Copied from my submission comment: To exceed requirements, I encapsulated the journal
// entry from the user within quotation marks as its saved to the .csv file, so that the
// file will work on Excel. I also merged the writing and saving of a prompt into one
// function, and I set a default file save location so a user may immediately begin
// writing OR change the file location. Finally, I added validation for several things,
// like ensuring the file specified from a user's entered filepath exists before changing
// from the default pathing.
class Program
{
	// _attributes here
	private static string _filePath = "journal.csv";

	static void Main(string[] args)
	{
		// Initialize variables
		Journal journal = new Journal();
		Entry entry = new Entry();
		bool repeat = true;

		// Welcomes user, prompts them navigate via menu
		Console.WriteLine("Welcome to the Journal Program!");
		Console.WriteLine("This program allows you to read and write journal entries with a prompt.");
		do
		{
			Console.WriteLine("\nPlease select one of the following options:");
			Console.WriteLine("1. Read past Journal Entries");
			Console.WriteLine("2. Write a new Journal Entry");
			Console.WriteLine("3. Change file location");
			Console.WriteLine("4. Quit");

			Console.Write("\nWhat would you like to do? ");
			int choice;
			while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
			{
				Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
			}
			Console.WriteLine();

			// Switch statement handles user input, exceeds requirements with validation
			switch (choice)
			{
				case 1:
					journal.DisplayJournal(_filePath);
					break;
				case 2:
					entry.WriteEntry(_filePath);
					break;
				case 3:
					// Default location is bin/Debug/net6.0/journal.csv
					// This csv file is excel compatible and exceeds requirements
					Console.WriteLine("Please enter the file path for your journal (e.g., C:\\path\\to\\your\\journal.csv): ");
					string newPath = journal.SetFilePath(_filePath, Console.ReadLine());
					_filePath = newPath;
					break;
				case 4:
					Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
					repeat = false;
					break;
			}
		} while (repeat);
	}
}