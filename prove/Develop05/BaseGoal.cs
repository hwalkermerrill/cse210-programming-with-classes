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

    // getters here
    public string GetName() { return _name; }
    public string GetDescription() { return _description; }
    public int GetPointValue() { return _pointValue; }

    // methods here
    public abstract int RecordEvent();
    public abstract string DisplayGoal();
    public abstract bool IsComplete();
    protected BaseGoal(string name, string description, int pointValue)
    {
      _name = name;
      _description = description;
      _pointValue = pointValue;
    }
  }
}