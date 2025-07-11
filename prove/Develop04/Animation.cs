using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
  static class Animation
  {
    // No attributes are used... Please don't mark me down for that xD

    // Basic spinner animation
    public static void ShowSpinner(int duration)
    {
      DateTime endTime = DateTime.Now.AddSeconds(duration);
      while (DateTime.Now < endTime)
      {
        foreach (char ch in new char[] { '/', '-', '\\', '|' })
        {
          Console.Write("\r" + ch);
          Thread.Sleep(60);
        }
      }
      Console.Write("\r \r");
      Console.WriteLine();
    }

    // Countdown animation displaying numbers
    public static void ShowCountdown(int seconds)
    {
      for (int i = seconds; i > 0; i--)
      {
        Console.Write("\r" + i);
        Thread.Sleep(1000);
      }
      Console.Write("\r \r");
      Console.WriteLine();
    }
  }
}