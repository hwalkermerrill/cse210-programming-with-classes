using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
  class Animation
  {
    // Attributes are private using _camelCase naming convention
    private string _animationType;
    public Animation(string animationType)
    {
      _animationType = animationType;
    }

    // Basic spinner animation
    public void ShowSpinner(int duration)
    {
      DateTime endTime = DateTime.Now.AddSeconds(duration);
      while (DateTime.Now < endTime)
      {
        foreach (char ch in new char[] { '/', '-', '\\', '|' })
        {
          Console.Write(ch);
          Thread.Sleep(100);
          Console.Write("\b");
        }
      }
      Console.WriteLine();
    }

    // Countdown animation displaying numbers
    public void ShowCountdown(int seconds)
    {
      for (int i = seconds; i > 0; i--)
      {
        Console.Write(i);
        Thread.Sleep(1000);
        Console.Write("\b \b");
      }
      Console.WriteLine();
    }
  }
}