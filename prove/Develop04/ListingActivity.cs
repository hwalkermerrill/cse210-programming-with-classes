using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MindfulnessProgram
{
  class ListingActivity : Activity
  {
    // Attributes are private using _camelCase naming convention
    private List<string> _prompts;
    private List<string> _items;
    public ListingActivity()
    // Defaults to 2 minutes
      : base("Listing", "This activity will help you focus on the good things in your life.\nYou'll list items related to the prompt.", 120)
    {
      _prompts = new List<string> {
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

    // Lets the user input items until time is up, with coyote time at the end for grace.
    // Then, counts and displays the listed items.
    public void CountItems()
    {
      Random random = new Random();
      int promptIndex = random.Next(_prompts.Count);
      Console.WriteLine(_prompts[promptIndex]);

      DateTime startTime = DateTime.Now;
      DateTime deadline = startTime.AddSeconds(_duration);

      // Coyote-Time the listing activity, plus a timeout at 1 minute for inactivity.
      while (DateTime.Now < deadline)
      {
        Console.Write("List an item: ");

        Task<string> inputTask = Task.Run(() => Console.ReadLine());
        if (!inputTask.Wait(60000))
        {
          Console.WriteLine("\nNo input received for 1 minute. Timing out.");
          break;
        }
        else
        {
          string userInput = Console.ReadLine()?.Trim();
          if (!string.IsNullOrWhiteSpace(userInput))
          {
            _items.Add(userInput);
          }
        }
      }
      // // Add 3 seconds of coyote time to finish writing.
      // Task<string> finalInput = Task.Run(() => Console.ReadLine());
      // if (!finalInput.Wait(2000))
      // {
      //   Console.WriteLine("\nTime's up, Wile E. Coyote!");
      //   // Wait the remaining 1 second (for a total of 3 seconds)
      //   finalInput.Wait(1000);
      // }

      Console.WriteLine($"\nYou listed {_items.Count} items.");
    }
  }
}