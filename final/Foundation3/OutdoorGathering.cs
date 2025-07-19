using System;

namespace InheritingTabletopEvents
{
  public class OutdoorGathering : Event
  {
    // attributes here
    private string _weatherForecast;

    // constructor here
    public OutdoorGathering(
      string title,
      string description,
      DateTime date,
      string time,
      Address address,
      string weatherForecast
    ) : base(title, description, date, time, address)
    {
      _weatherForecast = weatherForecast;
    }

    // methods here
    public override string GetFullDetails()
    {
      return
        $"{GetStandardDetails()}\n" +
        $"Forecast: {_weatherForecast}";
    }
  }
}