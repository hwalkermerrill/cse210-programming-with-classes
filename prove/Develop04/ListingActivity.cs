using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
  class ListingActivity : Activity
  {
    // Attributes are private using _camelCase naming convention
    private List<string> _prompt;
    private List<string> _items;
    public ListingActivity()
    // Defaults to 2 minutes
      : base("Listing", "This activity will help you focus on the good things in your life.\nYou'll list items related to the prompt.", 120)
    {
      _prompt = new List<string> {
        "List as many things as you can that you are grateful for:",
        "List as many things as you can that make you happy:",
        "List as many people as you can whom have positively impacted your life:",
        "List as many experiences as you can that have shaped who you are:",
        "List as many places as you can that you would love to visit:",
        "List as many things as you can that you want to achieve in the next year:",
        "List as many qualities as you can that you admire in others:",
        "List as many things as you can that you enjoy doing in your free time:",
      };
      _items = new List<string>();
    }

    // Lets the user input items until time is up; counts and displays them.
    public void CountItems()
    {
      Console.WriteLine(_prompt);
      DateTime startTime = DateTime.Now;
      while ((DateTime.Now - startTime).TotalSeconds < _duration)
      {
        Console.Write("> ");
        string input = Console.ReadLine().Trim();
        if (!string.IsNullOrWhiteSpace(input))
        {
          _items.Add(input);
        }
      }
      Console.WriteLine($"You listed {_items.Count} items.");
    }
  }
}