using System;

class Program
{
	static void Main(string[] args)
	{
		// Initialize variables
		string filePath = "journal.csv"; // Default file path
		bool repeat = true;
		Journal journal = new Journal();

		// Welcomes user, prompts them navigate via menu
		Console.WriteLine("Welcome to the Journal Program!");
		Console.WriteLine("This program allows you to read and write journal entries with a prompt.");
		do
		{
			Console.WriteLine();
			Console.WriteLine("Please select one of the following options:");
			Console.WriteLine("1. Read past Journal Entries");
			Console.WriteLine("2. Write a new Journal Entry");
			Console.WriteLine("3. Change file location");
			Console.WriteLine("4. Quit");
			Console.WriteLine();
			Console.Write("What would you like to do? ");
			int choice = int.Parse(Console.ReadLine());
			Console.WriteLine();

			// Switch statement handles user input
			switch (choice)
			{
				case 1:
					journal.DisplayJournal(filePath);
					break;
				case 2:
					journal.WriteJournal(filePath);
					break;
				case 3:
					Console.WriteLine("Please enter the file path for your journal (e.g., C:\\path\\to\\your\\journal.csv): ");
					filePath = Console.ReadLine();
					Console.WriteLine($"Your journal will be saved to: {filePath}");
					break;
				case 4:
					Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
					repeat = false;
					return;
				default:
					Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
					break;
			}
		} while (repeat == true);
	}
}