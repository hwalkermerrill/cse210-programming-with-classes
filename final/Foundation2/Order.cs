using System;
using System.Collections.Generic;
using System.Text;

namespace GameMastersWebStore
{
  public class Order
  {
		// attributes here, following _camelCase naming convention
    private Customer _customer;
    private List<Product>      _products;

    public Order(Customer customer)
    {
      _customer = customer;
      _products = new List<Product>();
    }

		// methods here
		public void AddProduct(Product product)
		{
			_products.Add(product);
		}

    public decimal GetTotalPrice()
    {
      decimal sum = 0m;
      foreach (var prod in _products)
      {
        sum += prod.GetTotalCost();
      }

      // $5 domestic, $35 international
      decimal shipping = _customer.InUSA() ? 5m : 35m;
      return sum + shipping;
    }

    public string GetPackingLabel()
    {
      var sb = new StringBuilder();
      sb.AppendLine("Packing Label:");
      foreach (var prod in _products)
      {
        sb.AppendLine($"{prod.GetId()} - {prod.GetName()}");
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