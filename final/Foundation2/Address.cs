using System;

namespace GameMastersWebStore
{
  public class Address
  {
		// attributes here, following _camelCase naming convention
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
      _street = street;
      _city = city;
      _state = stateProvince;
      _country = country;
    }

		// getters here
		public string GetFullAddress() { return $"{_street}\n{_city}, {_state}\n{_country}"; }
    public bool IsInUSA() { return _country.Equals("USA", StringComparison.OrdinalIgnoreCase); }
  }
}