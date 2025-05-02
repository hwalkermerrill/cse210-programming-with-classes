using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int guess = 0;
        int attempts = 0;
        bool isCorrect = false;

        Console.WriteLine("Welcome to the Magic Number Game!");
        Console.WriteLine("I have selected a magic number between 1 and 100. Can you guess what it is?");

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            attempts++;

            if (guess == magicNumber)
            {
                isCorrect = true;
                Console.WriteLine($"Congratulations! You guessed the magic number {magicNumber} in {attempts} attempts.");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher! Try again.");
            }
            else
            {
                Console.WriteLine("Lower! Try again.");
            }
        } while (!isCorrect);
    }
}