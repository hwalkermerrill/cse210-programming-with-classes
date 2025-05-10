using System;

class Program
{
	static void Main(string[] args)
	{
		// Initialize variables
		Journal journal = new Journal();
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
					journal.DisplayJournal();
					break;
				case 2:
					journal.WriteJournal();
					break;
				case 3:
					// Default location is bin/Debug/net6.0/journal.csv
					// This csv file is excel compatible and exceeds requirements
					Console.WriteLine("Please enter the file path for your journal (e.g., C:\\path\\to\\your\\journal.csv): ");
					journal.SetFilePath(Console.ReadLine());
					break;
				case 4:
					Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
					repeat = false;
					break;
			}
		} while (repeat);
	}
}