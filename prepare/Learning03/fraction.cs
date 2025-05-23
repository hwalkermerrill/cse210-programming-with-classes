using System;

class Fraction
{
  private int _numerator;
  private int _denominator;

  public Fraction(int numerator = 1, int denominator = 1)
  {
    _numerator = numerator;
    _denominator = denominator;
  }

  public double GetDecimalValue()
  {
    return (double)_numerator / _denominator;
  }

  public string GetFractionString()
  {
    string fractionString = $"{_numerator}/{_denominator}";
    return fractionString;
  }
}