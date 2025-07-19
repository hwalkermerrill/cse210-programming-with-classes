using System;

namespace InheritingTabletopEvents
{
	public class Address
	{
		// attributes here, following _camelCase naming convention
		private string _street;
		private string _city;
		private string _stateProvince;
		private string _country;

		// constructor here
		public Address(string street, string city, string stateProvince, string country)
		{
			_street = street;
			_city = city;
			_stateProvince = stateProvince;
			_country = country;
		}

		// methods here
		public string GetFullAddress()
		{
			return
				$"{_street}\n" +
				$"{_city}, {_stateProvince}\n" +
				$"{_country}";
		}
	}
}