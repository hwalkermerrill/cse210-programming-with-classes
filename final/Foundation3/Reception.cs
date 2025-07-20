using System;

namespace InheritingTabletopEvents
{
  public class Reception : Event
  {
    // attributes here
    private string _rsvpEmail;

    // constructor here
    public Reception(
      string title,
      string description,
      DateTime date,
      string time,
      Address address,
      string rsvpEmail
    ) : base(title, description, date, time, address)
    {
      _rsvpEmail = rsvpEmail;
    }

    // methods here
    public override string GetFullDetails()
    {
      return
        $"{GetStandardDetails()}\n" +
        $"RSVP by emailing us at {_rsvpEmail}";
    }
  }
}