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
  }
}