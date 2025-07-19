using System;

namespace GameMastersWebStore
{
  public class Product
  {
    // attributes here, following _camelCase naming convention
    private string _id;
    private string  _name;
    private decimal _unitPrice;
    private int     _quantity;

    public Product(string id, string name, decimal unitPrice, int quantity)
    {
      _id         = id;
      _name       = name;
      _unitPrice  = unitPrice;
      _quantity   = quantity;
    }

		// getters here
		public string GetId() { return _id; }
    public string GetName() { return _name; }
    public decimal GetUnitPrice() { return _unitPrice; }
    public int GetQuantity() { return _quantity; }
    public decimal GetTotalCost() { return _unitPrice * _quantity; }
  }
}