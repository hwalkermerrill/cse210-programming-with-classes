using System;

namespace InheritingTabletopEvents
{
  public abstract class Event
  {
    // attributes here, following _camelCase naming convention
    private string   _title;
    private string   _description;
    private DateTime _date;
    private string   _time;
    private Address  _address;

    // constructor here
    public Event(string title, string description, DateTime date, string time, Address address)
    {
      _title       = title;
      _description = description;
      _date        = date;
      _time        = time;
      _address     = address;
    }

    // methods here
    public string GetStandardDetails()
    {
      return
        $"Title: {_title}\n" +
        $"Description: {_description}\n" +
        $"Date: {_date.ToShortDateString()}\n" +
        $"Time: {_time}\n" +
        $"Address:\n{_address.GetFullAddress()}";
    }

		// This is still a method, not a getter, because the subclasses will add more details
		public virtual string GetFullDetails() { return GetStandardDetails(); }

    public string GetShortDescription()
    {
      string eventType = this.GetType().Name;
      return $"{eventType}: {_title} on {_date.ToShortDateString()}";
    }
  }
}