using System;
using System.Collections.Generic;

namespace GameMastersWebStore
{
	// Exceeds expectations, though only slightly. I hardcoded a list of customers and products for proof purposes,
	// but I did not use external csv files this time. Instead, I simply created the lists in the Program.cs file.
	// But I did create far more products and customers than required for the assignment, I kept them to a similar
	// theme, and I set up the ordering to allow the program to either put in the order quantity or default to 1.
	public class Program
	{
		public static void Main(string[] args)
		{
			// main program here
			var customers = InitializeCustomers();
			var products = InitializeProducts();

			Console.WriteLine("== Customer Roster ==");
			foreach (var character in customers)
			{
				Console.WriteLine($"Name    : {character.GetName()}");
				Console.WriteLine("Address :\n" + character.GetAddress().GetFullAddress());
				Console.WriteLine($"In USA? : {(character.InUSA() ? "Yes" : "No")}");
				Console.WriteLine(new string('-', 32));
			}

			Console.WriteLine("\n== Product Catalog ==");
			foreach (var item in products)
			{
				Console.WriteLine(
					$"ID: {item.GetID()}  |  " +
					$"Name: {item.GetName()}  |  " +
					$"Unit Price: {item.GetUnitPrice():C}"
				);
			}

			// 1) Ballin the Dwarf Cleric orders:
			var ballinOrder = new Order(customers[0], products);
			ballinOrder.AddProduct("WPN03");
			ballinOrder.AddProduct("SHD02");
			ballinOrder.AddProduct("WND01");

			// 2) Rogar the Orc Guard orders:
			var rogarOrder = new Order(customers[1], products);
			rogarOrder.AddProduct("WPN02", 8);
			rogarOrder.AddProduct("ARM01");
			rogarOrder.AddProduct("ENR01");

			// 3) Wizbolt the Human Wizard orders:
			var wizboltOrder = new Order(customers[2], products);
			wizboltOrder.AddProduct("RDM01", 25);

			// 4) Normal the NPC orders:
			var normalOrder = new Order(customers[9], products);
			normalOrder.AddProduct("WPN01");
			normalOrder.AddProduct("ARM01");
			normalOrder.AddProduct("SHD01");

			PrintOrder("Ballin’s Order", ballinOrder);
			PrintOrder("Rogar’s Order", rogarOrder);
			PrintOrder("Wizbolt’s Order", wizboltOrder);
			PrintOrder("Normal’s Order", normalOrder);
		}

		// methods here
		static void PrintOrder(string title, Order order)
		{
			Console.WriteLine($"\n<<< {title} >>>");
			Console.WriteLine(order.GetPackingLabel());
			Console.WriteLine(order.GetShippingLabel());
			Console.WriteLine($"Total Price: {order.GetTotalPrice():C}");
		}

		// Hardcoded customer and product lists for testing/ class prove reasons
		static List<Customer> InitializeCustomers()
		{
			return new List<Customer>
			{
				new Customer("Ballin the Dwarf",
					new Address("12 Granite Way", "Erabor", "Iron Peaks", "Middle-Earth")),

				new Customer("Rogar the Orc Guard",
					new Address("Orc Camp Road", "Orc Camp", "Bloodfang", "Ogrimmar")),

				new Customer("Wizbolt the Wizard",
					new Address("100 Arcane Ave", "Mystic Falls", "Maryland", "USA")),

				new Customer("Elthira the Elf",
					new Address("33 Elmsong Blvd", "Silvermoon", "Eriador", "Middle-Earth")),

				new Customer("Morgrim the Grim Rogue",
					new Address("1559 Grimdark Lane", "Gloomhaven", "Blackrock", "Dark Blades")),

				new Customer("Silver the Paladin",
					new Address("88 Celestial Kingdom", "Delvehaven", "Worldwound", "Golarion")),

				new Customer("Ulfric the Stormlord",
					new Address("70 Kings Way", "Winterhold", "Skyrim", "Nurn")),

				new Customer("Guy the Fighter",
					new Address("23 Mission Street", "Provo", "Utah", "USA")),

				new Customer("Lina the Lunar Mage",
					new Address("42 Demon Gate", "Irilith", "Crater 91", "Azlant")),

				new Customer("Normal the NPC",
					new Address("19 Wildwood Trail", "Greenfield", "Indiana", "USA")),
			};
		}

		static List<Product> InitializeProducts()
		{
			return new List<Product>
			{
        // Weapons
        new Product("WPN01", "Simple Weapon", 10m, 1),
				new Product("WPN02", "Martial Weapon", 50m, 1),
				new Product("WPN03", "Exotic Weapon", 250m, 1),
				new Product("AMM01", "Ammo (20)", 10m, 1),

        // Armor
        new Product("SHD01", "Light Shield", 25m, 1),
				new Product("SHD02", "Heavy Shield", 100m, 1),
				new Product("ARM01", "Light Armor", 100m, 1),
				new Product("ARM02", "Medium Armor", 500m, 1),
				new Product("ARM03", "Heavy Armor", 2000m, 1),

        // Enchantments
        new Product("ENR01", "Armor +1 Enchantment", 1000m, 1),
				new Product("ENR02", "Armor +2 Enchantment", 4000m, 1),
				new Product("ENR03", "Armor +3 Enchantment", 16000m, 1),
				new Product("ENW01", "Weapon +1 Enchantment", 2000m, 1),
				new Product("ENW02", "Weapon +2 Enchantment", 8000m, 1),
				new Product("ENW03", "Weapon +3 Enchantment", 32000m, 1),

        // Wands
        new Product("WND01", "Wand of Cure Light Wounds", 450m, 1),
				new Product("WND02", "Wand of Cure Moderate Wounds", 2700m, 1),
				new Product("WND03", "Wand of Cure Serious Wounds", 6750m, 1),

        // Random magic items
        new Product("RDM01","Random Discount Magic Item (maybe cursed)", 50m, 1),
				new Product("RDM02","Random Discount Magic Item (totally not cursed)",5000m, 1),
			};
		}
	}
}