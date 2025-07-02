using System;

namespace EternalQuest
{
  // These goals must be completed a few times before it's "finished"
  public class ChecklistGoal : BaseGoal
  {
    // attributes here, following _camelCase naming convention
    private int _timesDone;
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
      _targetCount = targetCount;
      _completionBonus = completionBonus;
    }

    public int TimesDone => _timesDone;
    public int TargetCount => _targetCount;
    public int CompletionBonus => _completionBonus;
    public override bool IsComplete => _timesDone >= _targetCount;

    // methods here
    public override int RecordEvent()
    {
      if (IsComplete)
      {
        Console.WriteLine($"\"{Name}\" is already fully completed.");
        return 0;
      }

      _timesDone++;
      if (_timesDone == _targetCount)
      {
        Console.WriteLine($"*** Checklist complete! Bonus +{_completionBonus} pts! ***");
      }

      return PointValue + (IsComplete ? _completionBonus : 0);
    }

    public override string DisplayGoal()
    {
      var checkbox = IsComplete ? "[X]" : "[ ]";
      return $"{checkbox} {Name} ({Description}) – {PointValue} pts each, {_timesDone}/{_targetCount} done, bonus {_completionBonus}";
    }
    internal void RestoreProgress(int timesDone)
    {
      _timesDone = timesDone;
    }

  }
}