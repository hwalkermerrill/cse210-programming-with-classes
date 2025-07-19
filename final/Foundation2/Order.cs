using System;
using System.Collections.Generic;
using System.Text;

namespace GameMastersWebStore
{
  public class Order
  {
		// attributes here, following _camelCase naming convention
    private Customer _customer;
    private List<Product> _products;
		private List<Product> _catalog;

		// constructor here
		public Order(Customer customer, List<Product> catalog)
		{
			_customer = customer;
			_products = new List<Product>();
			_catalog = catalog;
		}

		// methods here
		public void AddProduct(string productID, int quantity = 1)
		{
			Product product = null;
			foreach (var item in _catalog)
			{
				if (item.GetID() == productID)
				{
					product = item;
					break;
				}
			}
			if (product == null)
			{
				throw new ArgumentException($"You cannot purchase {productID} at your level.");
			}

			var lineItem = new Product(
				product.GetID(),
				product.GetName(),
				product.GetUnitPrice(),
				quantity
      );
      _products.Add(lineItem);
		}

    public decimal GetTotalPrice()
    {
      decimal sum = 0m;
      foreach (var lineCost in _products)
      {
        sum += lineCost.GetTotalCost();
      }

      decimal shipping = _customer.InUSA() ? 5m : 35m;
      return sum + shipping;
    }

    public string GetPackingLabel()
    {
      var sb = new StringBuilder();
      sb.AppendLine("Packing Label:");
      foreach (var product in _products)
      {
        sb.AppendLine($"{product.GetID()} - {product.GetName()} x{product.GetQuantity()}");
      }
      return sb.ToString();
    }

    public string GetShippingLabel()
    {
      var sb = new StringBuilder();
      sb.AppendLine("Shipping Label:");
      sb.AppendLine(_customer.GetName());
      sb.AppendLine(_customer.GetAddress().GetFullAddress());
      return sb.ToString();
    }
  }
}