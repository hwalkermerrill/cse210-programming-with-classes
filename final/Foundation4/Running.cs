using System;

namespace ZamirasFitnessTracker
{
  public class Running : Activity
  {
    // attributes here, following _camelCase naming convention
    private double _distanceMiles;

    // constructor here
    public Running(DateTime date, int lengthMinutes, double distanceMiles)
      : base(date, lengthMinutes)
    {
      _distanceMiles = distanceMiles;
    }

    // methods here
    public override double GetDistance() { return _distanceMiles; }

    public override double GetSpeed()
    {
      return (_distanceMiles / _lengthMinutes) * 60;
    }

    public override double GetPace()
    {
      return _lengthMinutes / _distanceMiles;
    }
  }
}