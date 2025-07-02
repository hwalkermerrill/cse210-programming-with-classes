using System;

namespace EternalQuest
{
  // These goals may be repeated infinitely
  public class EternalGoal : BaseGoal
  {
    // attributes here, following _camelCase naming convention
    private int _timesDone;

    // properties here
    public int TimesDone => _timesDone;
    public EternalGoal(string name, string description, int pointValue)
        : base(name, description, pointValue) { }
    public override bool IsComplete => false; // eternal goals can never be complete

    // methods here
    public override int RecordEvent()
    {
      _timesDone++;
      Console.WriteLine($"Recorded \"{Name}\" ({_timesDone}×)! +{PointValue} pts");
      return PointValue;
    }

    public override string DisplayGoal()
    {
      return $"[∞] {Name} – {PointValue} pts each ({_timesDone}× done)";
    }
    internal void RestoreCount(int count)
    {
      _timesDone = count;
    }
  }
}