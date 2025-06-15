using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
  class BreathingActivity : Activity
  {
    // attributes are private using _camelCase naming convention
    private int _interval = 5;
    public BreathingActivity()
    // Defaults to 1 minute duration.
      : base("Breathing", "This activity will help you relax by guiding your breathing.\nFollow the prompts for inhaling and exhaling.", 60)
    { }

    // Alternates between "Breathe in" and "Breathe out" until duration expires.
    public void BreathingCycle()
    {
      DateTime startTime = DateTime.Now;
      string lastBreath = "out";
      while ((DateTime.Now - startTime).TotalSeconds < _duration)
      {
        Console.WriteLine("Breathe in...");
        lastBreath = "in";
        Pause(_interval * 2);

        if ((DateTime.Now - startTime).TotalSeconds >= _duration)
          break;

        Console.WriteLine("Breathe out...");
        lastBreath = "out";
        Pause(_interval);
      }

      if (lastBreath == "in")
      {
        Console.WriteLine("And... Breathe out.");
        Pause(3);
      }
    }
  }
}