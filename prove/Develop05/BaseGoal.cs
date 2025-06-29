using System;

namespace EternalQuest
{
  // abstract for all goals, uses attributes so it cannot be an interface
  public abstract class BaseGoal
  {
    // attributes here, following _camelCase naming convention
    protected string _name;
    protected string _description;
    protected int _pointValue;

    // properties here
    public string Name => _name;
    public string Description => _description;
    public int PointValue => _pointValue;
    public abstract bool IsComplete { get; } // eternal is always false

    // methods here
    public abstract int RecordEvent();
    public abstract string DisplayGoal();
    protected BaseGoal(string name, string description, int pointValue)
    {
      _name = name;
      _description = description;
      _pointValue = pointValue;
    }
  }
}