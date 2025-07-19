using System;

namespace ZamirasFitnessTracker
{
  public class Swimming : Activity
  {
    // attributes here
    private int _laps;

    // constructor here
    public Swimming(DateTime date, int lengthMinutes, int laps)
      : base(date, lengthMinutes) { _laps = laps; }

    // methods here
    public override double GetDistance()
    {
      // each lap = 50 m; convert to km then to miles
      double meters = _laps * 50.0;
      double kilometers = meters / 1000.0;
      double miles = kilometers * 0.62;
      return miles;
    }

    public override double GetSpeed()
    {
      double distance = GetDistance();
      return distance > 0
        ? (distance / _lengthMinutes) * 60.0
        : 0.0;
    }

    public override double GetPace()
    {
      double distance = GetDistance();
      return distance > 0
        ? _lengthMinutes / distance
        : 0.0;
    }
  }
}