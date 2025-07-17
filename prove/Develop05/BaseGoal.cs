using System;

namespace EternalQuest
{
  // abstract for all goals, uses attributes so it cannot be an interface
  public abstract class BaseGoal
  {
    // attributes here, following _camelCase naming convention
    protected string _name;
    protected string _description;
    protected int _expValue;

    // getters here
    public string GetName() { return _name; }
    public string GetDescription() { return _description; }
    public int GetExpValue() { return _expValue; }

    // methods here
    public abstract int RecordEvent();
    public abstract string DisplayGoal();
    public abstract bool IsComplete();
    protected BaseGoal(string name, string description, int expValue)
    {
      _name = name;
      _description = description;
      _expValue = expValue;
    }
  }
}