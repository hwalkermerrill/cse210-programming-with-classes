using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
  abstract class Activity
  {
    // attributes are protected for access in derived classes, using _camelCase naming convention
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
      _name = name;
      _description = description;
      _duration = duration;
    }

    //Allows the user to change the activity's duration.
    public void SetDuration(int seconds)
    {
      if (seconds <= 0)
      {
        Console.WriteLine($"Invalid duration, setting activity duration to 1 minute.");
        _duration = 60;
        return;
      }
      _duration = seconds;
    }

    // Displays the start message for each activity.
    public virtual void DisplayStartMessage()
    {
      Console.Clear();
      Console.WriteLine($"Welcome to the {_name} Activity!\n");
      Console.WriteLine(_description);
      Console.WriteLine($"You will have {_duration / 60} minutes for this activity.");
      Pause(3);
    }

    // Displays the end message (includes the activity's name).
    public virtual void DisplayEndMessage()
    {
      Console.WriteLine($"Well done! You have completed this {_name} Activity.");
      Pause(3);
    }

    // Displays a pause. Uses Animation for showing spinner.
    public virtual void Pause(int seconds)
    {
      Animation spinner = new Animation("spinner");
      spinner.ShowSpinner(seconds);
    }

    // Check if the user wants to quit the activity; returns true if quitting.
    public virtual bool Quit()
    {
      Console.Write("Type 'Q' to quit the activity or press Enter to continue: ");
      string input = Console.ReadLine().Trim().ToLower();
      return input == "q";
    }
  }
}