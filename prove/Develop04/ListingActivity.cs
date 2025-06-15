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

      //This reserves two lines, one for the timer, and the other for the user.
      Console.WriteLine();
      int timerLine = Console.CursorTop - 1;
      Console.Write("List an item: ");
      int inputLine = Console.CursorTop;

      //This saves the keystrokes until they press enter.
      string inputBuffer = "";

      DateTime startTime = DateTime.Now;
      DateTime deadline = startTime.AddSeconds(_duration);

      while (DateTime.Now < deadline)
      {
        //This forces the timer to remain on the same line.
        TimeSpan remaining = deadline - DateTime.Now;
        Console.SetCursorPosition(0, timerLine);
        Console.Write($"Time remaining: {remaining.Minutes:D2}:{remaining.Seconds:D2}");

        //This allows the user to type in the input line.
        Console.SetCursorPosition(inputBuffer.Length + "List an item: ".Length, inputLine);

        // Workaround to process user input via buffer.
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo keyInfo = Console.ReadKey(true);

          if (keyInfo.Key == ConsoleKey.Enter)
          {
            if (!string.IsNullOrEmpty(inputBuffer))
            {
              _items.Add(inputBuffer);
            }

            ClearLine(inputLine);
            Console.SetCursorPosition(0, inputLine);
            Console.Write("List an item: ");
            inputBuffer = "";
          }
          // Handle backspace to remove the last character.
          else if (keyInfo.Key == ConsoleKey.Backspace)
          {
            if (inputBuffer.Length > 0)
            {
              inputBuffer = inputBuffer.Substring(0, inputBuffer.Length - 1);
              ClearLine(inputLine);
              Console.SetCursorPosition(0, inputLine);
              Console.Write("List an item: " + inputBuffer);
            }
          }
          else
          {
            // Append the character to the buffer.
            inputBuffer += keyInfo.KeyChar;
            Console.Write(keyInfo.KeyChar);
          }

          // This lets the CPU rest
          Thread.Sleep(50);
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
    private void ClearLine(int line)
    {
      int currentLineCursor = Console.CursorTop;
      Console.SetCursorPosition(0, line);
      Console.Write(new string(' ', Console.WindowWidth));
      Console.SetCursorPosition(0, line);
    }
  }
}