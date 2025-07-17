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

    // getters here
    public int GetTimesDone() { return _timesDone; }
    public int GetTargetCount() { return _targetCount; }
    public int GetCompletionBonus() { return _completionBonus; }
    public override bool IsComplete() { return _timesDone >= _targetCount; }

    // constructors here
    public ChecklistGoal(
        string name,
        string description,
        int expValue,
        int targetCount,
        int completionBonus
    )
    : base(name, description, expValue)
    {
      _targetCount = targetCount;
      _completionBonus = completionBonus;
    }

    // methods here
    public override int RecordEvent()
    {
      if (IsComplete())
      {
        Console.WriteLine($"\"{GetName()}\" is already fully completed.");
        return 0;
      }

      _timesDone++;
      if (_timesDone == _targetCount)
      {
        Console.WriteLine($"*** Checklist complete! Bonus +{GetCompletionBonus()} exp! ***");
      }

      return GetExpValue() + (IsComplete() ? GetCompletionBonus() : 0);
    }

    public override string DisplayGoal()
    {
      var checkbox = IsComplete() ? "[X]" : "[ ]";
      return  $"{checkbox} {GetName()} ({GetDescription()}) – {GetExpValue()} exp each, " +
              $"{ GetTimesDone()}/{GetTargetCount()} done, bonus {GetCompletionBonus()}";
    }

    internal void RestoreProgress(int timesDone)
    {
      _timesDone = timesDone;
    }

  }
}