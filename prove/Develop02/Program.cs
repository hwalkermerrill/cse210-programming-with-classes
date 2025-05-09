using System;

class Program
{
	static void Main(string[] args)
	{
		// Welcomes user, prompts them to read past entries or write a new one
		Console.WriteLine("Welcome to the Journal Program!");
		Console.WriteLine();

		Console.WriteLine("Would you like to read past entries or write a new one? (r/w): ");
		string choice = Console.ReadLine().ToLower();
		do
		{
			Console.WriteLine();
			if (choice == "r")
			{
				Journal journal = new Journal();
				journal.DisplayJournal();
				choice = "quit"; // Exit after reading entries
			}
			else if (choice == "w")
			{
				Journal journal = new Journal();
				journal.WriteJournal();
				choice = "new"; // Prompt for next action
			}
			else
			{
				Console.WriteLine("Invalid choice. Please enter 'r' or 'w', or 'quit' to exit.");
				choice = Console.ReadLine().ToLower();
			}
		} while (choice != "quit");
		Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
	}
}