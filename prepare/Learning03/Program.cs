using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction test1 = new Fraction();
        Console.WriteLine(test1.GetFractionString());
        Console.WriteLine(test1.GetDecimalValue());
        // Expected output is "1/1" and 1

        Fraction test2 = new Fraction(5);
        Console.WriteLine(test2.GetFractionString());
        Console.WriteLine(test2.GetDecimalValue());
        // Expected output is "5/1" and 5

        Fraction test3 = new Fraction(2, 5);
        Console.WriteLine(test3.GetFractionString());
        Console.WriteLine(test3.GetDecimalValue());
        // Expected output is "2/5" and 0.4

        Fraction test4 = new Fraction(100, 15);
        Console.WriteLine(test4.GetFractionString());
        Console.WriteLine(test4.GetDecimalValue());
        // Expected output is "100/15" and 6.6>7

        Fraction test5 = new Fraction(denominator: 5);
        Console.WriteLine(test5.GetFractionString());
        Console.WriteLine(test5.GetDecimalValue());
        // Expected output is "1/5" and 0.2
    }
}