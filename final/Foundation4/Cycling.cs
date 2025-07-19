using System;

namespace ZamirasFitnessTracker
{
  public class Cycling : Activity
  {
    // attributes here, following _camelCase naming convention
    private double _speedMph;

    // constructor here
    public Cycling(DateTime date, int lengthMinutes, double speedMph)
      : base(date, lengthMinutes) { _speedMph = speedMph; }

    // methods here
    public override double GetDistance()
    {
      return (_speedMph * _lengthMinutes) / 60;
    }

    public override double GetSpeed() { return _speedMph; }

    public override double GetPace()
    {
      double distance = GetDistance();
      return distance > 0 ? _lengthMinutes / distance : 0.0;
    }
  }
}