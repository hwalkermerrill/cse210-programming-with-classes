using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Please note we could use a do-while loop here instead
        int userNumber = 0;
        do
        {
            Console.Write("Enter number: ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        } while (userNumber != 0);

        // Calculate the sum and max using foreach method.
        int sum = 0;
        int max = numbers[0];
        int min = numbers[0];

        foreach (int number in numbers)
        {
            sum += number;
            if (number > max)
            {
                max = number;
            }
            if (number < min && number > 0)
            {
                min = number;
            }
        }

        // Calculate average at the end to prevent NaN error.
        float average = ((float)sum) / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The max is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");
    }
}