using System;
using System.Collections.Generic;

namespace GameMastersWebStore
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// methods here
			var customers = InitializeCustomers();

			Console.WriteLine("Welcome to the Game Masters Web Store!\n");
			foreach (var character in customers)
			{
				Console.WriteLine($"Name    : {character.GetName()}");
				Console.WriteLine($"Address : {character.GetAddress().GetFullAddress()}");
				Console.WriteLine($"In USA? : " + (character.InUSA() ? "Yes" : "No"));
				Console.WriteLine(new string('=', 32));
			}
		}

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
        new Product("WPN01", "Simple Weapon", 10, 1),
				new Product("WPN02", "Martial Weapon", 50, 1),
				new Product("WPN03", "Exotic Weapon", 250, 1),
				new Product("AMM01", "Ammo (20)", 10, 1),

        // Armor
        new Product("SHD01", "Light Shield", 25, 1),
				new Product("SHD02", "Heavy Shield", 100, 1),
				new Product("ARM01", "Light Armor", 100, 1),
				new Product("ARM02", "Medium Armor", 500, 1),
				new Product("ARM03", "Heavy Armor", 2000, 1),

        // Enchantments
        new Product("ENR01", "Armor +1 Enchantment", 1000, 1),
				new Product("ENR02", "Armor +2 Enchantment", 4000, 1),
				new Product("ENR03", "Armor +3 Enchantment", 16000, 1),
        new Product("ENW01", "Weapon +1 Enchantment", 2000, 1),
				new Product("ENW02", "Weapon +2 Enchantment", 8000, 1),
				new Product("ENW03", "Weapon +3 Enchantment", 32000, 1),

        // Wands
        new Product("WND01", "Wand of Cure Light Wounds", 450, 1),
				new Product("WND02", "Wand of Cure Moderate Wounds", 2700, 1),
				new Product("WND03", "Wand of Cure Serious Wounds", 6750, 1),

        // Random magic items
        new Product("RDM01","Random Discount Magic Item (maybe cursed)", 50, 1),
				new Product("RDM02","Random Discount Magic Item (totally not cursed)",5000, 1),
			};
		}
  }
}