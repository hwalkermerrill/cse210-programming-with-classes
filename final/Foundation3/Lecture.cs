using System;

namespace InheritingTabletopEvents
{
  public class Lecture : Event
  {
    // attributes here
    private string _speaker;
    private int    _capacity;

    // constructor here
    public Lecture(
      string title,
      string description,
      DateTime date,
      string time,
      Address address,
      string speaker,
      int capacity
    ) : base(title, description, date, time, address)
    {
      _speaker  = speaker;
      _capacity = capacity;
    }

    // methods here
    public override string GetFullDetails()
    {
      return
        $"{GetStandardDetails()}\n" +
        $"Speaker: {_speaker}\n" +
        $"Capacity: {_capacity}";
    }
  }
}