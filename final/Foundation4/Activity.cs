using System;

namespace ZamirasFitnessTracker
{
  public abstract class Activity
  {
    // attributes here, following _camelCase naming convention
    protected DateTime _date;
    protected int _lengthMinutes;

    // constructor here
    public Activity(DateTime date, int lengthMinutes)
    {
      _date = date;
      _lengthMinutes = lengthMinutes;
    }

    // methods here
    public virtual double GetDistance() { return 0.0; }
    public virtual double GetSpeed() { return 0.0; }
    public virtual double GetPace() { return 0.0; }

    public string GetSummary()
    {
      string dateStr      = _date.ToString("dd MMM yyyy");
      string activityType = this.GetType().Name;
      double distance     = GetDistance();
      double speed        = GetSpeed();
      double pace         = GetPace();

      return
        $"{dateStr} {activityType} ({_lengthMinutes} min) - " +
        $"Distance: {distance:F1} miles, " +
        $"Speed: {speed:F1} mph, " +
        $"Pace: {pace:F1} min per mile";
    }
  }
}