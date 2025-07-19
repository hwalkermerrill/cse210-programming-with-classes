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

		// constructor here
    public Product(string id, string name, decimal unitPrice, int quantity)
    {
      _id         = id;
      _name       = name;
      _unitPrice  = unitPrice;
      _quantity   = quantity;
    }

		// getters here
		public string GetID() { return _id; }
    public string GetName() { return _name; }
    public decimal GetUnitPrice() { return _unitPrice; }
    public int GetQuantity() { return _quantity; }
    public decimal GetTotalCost() { return _unitPrice * _quantity; }
  }
}