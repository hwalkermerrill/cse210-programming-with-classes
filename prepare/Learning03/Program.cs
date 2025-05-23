using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction test1 = new Fraction();
        Console.WriteLine(test1.GetFractionString());
        Console.WriteLine(test1.GetDecimalValue());
        // Expected output is "1/1" and 1.0

        Fraction test2 = new Fraction(5);
        Console.WriteLine(test1.GetFractionString());
        Console.WriteLine(test1.GetDecimalValue());
        // Expected output is "5/1" and 5.0

        Fraction test3 = new Fraction(1, 5);
        Console.WriteLine(test1.GetFractionString());
        Console.WriteLine(test1.GetDecimalValue());
        // Expected output is "1/5" and 0.2

        Fraction test4 = new Fraction(100, 15);
        Console.WriteLine(test1.GetFractionString());
        Console.WriteLine(test1.GetDecimalValue());
        // Expected output is "100/15" and 6.6>7
    }
}