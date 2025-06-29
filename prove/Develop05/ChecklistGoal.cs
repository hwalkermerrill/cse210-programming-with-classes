using System;

namespace EternalQuest
{
  // These goals must be completed a few times before it's "finished"
  public class ChecklistGoal : BaseGoal
  {
    // attributes here, following _camelCase naming convention
    private int _completeCount;
    private readonly int _targetCount;
    private readonly int _completionBonus;

    // properties here
    public ChecklistGoal(
        string name,
        string description,
        int pointValue,
        int targetCount,
        int completionBonus
    )
    : base(name, description, pointValue)
    {
      _completeCount = 0;
      _targetCount = targetCount;
      _completionBonus = completionBonus;
    }

    public override bool IsComplete => _completeCount >= _targetCount;

    // methods here
    public override int RecordEvent()
    {
      if (IsComplete)
      {
        Console.WriteLine($"\"{Name}\" is already fully completed.");
        return 0;
      }

      _completeCount++;
      var exp = PointValue;
      Console.WriteLine($"Progress on \"{Name}\": {_completeCount}/{_targetCount} (+{PointValue} pts)");

      if (_completeCount == _targetCount)
      {
        exp += _completionBonus;
        Console.WriteLine($"*** Checklist complete! Bonus +{_completionBonus} pts! ***");
      }

      return exp;
    }

    public override string DisplayGoal()
    {
      var checkbox = IsComplete ? "[X]" : "[ ]";
      return $"{checkbox} {Name} ({Description}) – {PointValue} pts each, {_completeCount}/{_targetCount} done, bonus {_completionBonus}";
    }
  }
}