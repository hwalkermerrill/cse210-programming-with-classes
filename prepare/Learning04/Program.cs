using System;

class Program
{
	// Attributes
	// None
	static void Main(string[] args)
	{
		// Part 1
		Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
		Console.WriteLine(a1.GetSummary());

		// Part 2
		MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
		Console.WriteLine(a2.GetSummary());
		Console.WriteLine(a2.GetHomeworkList());
		WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
		Console.WriteLine(a3.GetSummary());
		Console.WriteLine(a3.GetWritingInformation());
	}
}