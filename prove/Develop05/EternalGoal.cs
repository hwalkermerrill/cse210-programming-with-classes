using System;

namespace EternalQuest
{
  // These goals may be repeated infinitely
  public class EternalGoal : BaseGoal
  {
    // attributes here, following _camelCase naming convention
    private int _timesDone;

    // getters here
    public int GetTimesDone() { return _timesDone; }
    public override bool IsComplete() { return false; } // eternal goals can never be complete

    // constructors here
    public EternalGoal(string name, string description, int expValue)
        : base(name, description, expValue) { }

    // methods here
    public override int RecordEvent()
    {
      _timesDone++;
      Console.WriteLine($"Recorded \"{GetName()}\" ({_timesDone}×)! +{GetExpValue()} exp");
      return GetExpValue();
    }

    public override string DisplayGoal()
    {
      return $"[∞] {GetName()} – {GetExpValue()} exp each ({_timesDone}× done)";
    }

    internal void RestoreCount(int count)
    {
      _timesDone = count;
    }
  }
}