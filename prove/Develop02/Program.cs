using System;

class Program
{
	static void Main(string[] args)
	{
		// Welcomes user, prompts them to read past entries or write a new one
		Console.WriteLine("Welcome to the Journal Program!");
		Console.WriteLine("This program allows you to write journal entries and read past entries.");
		Console.WriteLine();

		string filePath = "journal.csv"; // Default file path
		Console.WriteLine("Would you like to select a file location for your journal?");
		Console.WriteLine("Type 'yes' to select a file location, or anything else to use the default location.");
		if (Console.ReadLine().ToLower() == "yes")
		{
			Console.WriteLine("Please enter the file path for your journal (e.g., C:\\path\\to\\your\\journal.csv): ");
			filePath = Console.ReadLine();
			Console.WriteLine($"Your journal will be saved to: {filePath}");
		}
		else
		{
			Console.WriteLine("Using default file location: journal.csv");
		}

		Console.WriteLine("Would you like to read past entries or write a new one? (r/w): ");
		string choice = Console.ReadLine().ToLower();
		do
		{
			Console.WriteLine();
			if (choice == "r")
			{
				Journal journal = new Journal();
				journal.DisplayJournal(filePath);
				choice = "new"; // Prompt for next action
			}
			else if (choice == "w")
			{
				Journal journal = new Journal();
				journal.WriteJournal(filePath);
				choice = "new"; // Prompt for next action
			}
			else
			{
				Console.WriteLine("Would you like to run this program again? Please enter 'r' or 'w', or 'quit' to exit.");
				choice = Console.ReadLine().ToLower();
			}
		} while (choice != "quit");
		Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
	}
}