namespace GameMastersWebStore
{
  public class Customer
  {
		// attributes here, following _camelCase naming convention
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
      _name = name;
      _address = address;
    }

		// getters here
		public string GetName()
		{
			return _name;
		}

    public Address GetAddress()
    {
      return _address;
    }

    public bool InUSA()
    {
      return _address.IsInUSA();
    }
  }
}