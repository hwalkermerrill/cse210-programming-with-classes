using System;

class Program
{
	static void Main(string[] args)
	{
		Console.Write("What is your grade percentage? ");
		string userPercentage = Console.ReadLine();

		// Declaring variables here so they're all in one block
		int gradePercentage = int.Parse(userPercentage);
		bool isPassing = gradePercentage >= 70;
		int gradeRemainder = gradePercentage % 10;
		string letterGrade = "";
		string letterRemainder = "";

		if (isPassing)
		{
			if (gradePercentage >= 90)
			{ letterGrade = "A"; }
			else if (gradePercentage >= 80)
			{ letterGrade = "B"; }
			else
			{ letterGrade = "C"; }
		}
		else
		{
			if (gradePercentage >= 60)
			{ letterGrade = "D"; }
			else
			{ letterGrade = "F"; }
		}

		if (gradePercentage >= 60)
		{
			if (gradePercentage < 90 && gradeRemainder >= 7)
			{ letterRemainder = "+"; }
			else if (gradeRemainder <= 2)
			{ letterRemainder = "-"; }
		}

		Console.WriteLine(""); // Blank Line added for readability
		Console.WriteLine($"Your letter grade is {letterGrade}{letterRemainder}");

		if (isPassing)
		{ Console.WriteLine("Congratulations! You passed the course!"); }
		else
		{
			Console.WriteLine("Sorry, you are not currently passing this course.");
			Console.WriteLine("You may wish to contact a tutor or your instructor for assistance.");
		}
	}
}