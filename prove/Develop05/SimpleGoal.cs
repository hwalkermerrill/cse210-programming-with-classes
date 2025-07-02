using System;

namespace EternalQuest
{
  // Simple, single-instance goals
  public class SimpleGoal : BaseGoal
  {
    // attributes here, following _camelCase naming convention
    private bool _completed;

    // properties here
    public SimpleGoal(string name, string description, int pointValue)
      : base(name, description, pointValue) { }

    public override bool IsComplete => _completed;

    // methods here
    public override int RecordEvent()
    {
      if (_completed)
      {
        Console.WriteLine($"\"{Name}\" is already complete.");
        return 0;
      }

      _completed = true;
      Console.WriteLine($"You completed \"{Name}\"! +{PointValue} pts");
      return PointValue;

    }

    public override string DisplayGoal()
    {
      var checkbox = _completed ? "[X]" : "[ ]";
      return $"{checkbox} {Name} ({Description}) – {PointValue} pts";
    }
    internal void Restore(bool completed)
    => _completed = completed;
  }
}