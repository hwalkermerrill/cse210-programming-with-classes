using System;

namespace EternalQuest
{
  // Simple, single-instance goals
  public class SimpleGoal : BaseGoal
  {
    // attributes here, following _camelCase naming convention
    private bool _completed;

    // constructors here
    public SimpleGoal(string name, string description, int expValue)
      : base(name, description, expValue) { }

    // methods here
    public override bool IsComplete() { return _completed; }

    public override int RecordEvent()
    {
      if (_completed)
      {
        Console.WriteLine($"\"{GetName()}\" is already complete.");
        return 0;
      }

      _completed = true;
      Console.WriteLine($"You completed \"{GetName()}\"! +{GetExpValue()} exp");
      return GetExpValue();

    }

    public override string DisplayGoal()
    {
      var checkbox = _completed ? "[X]" : "[ ]";
      return $"{checkbox} {GetName()} ({GetDescription()}) – {GetExpValue()} exp";
    }

    internal void Restore(bool completed)
    {
      _completed = completed;
    }
  }
}