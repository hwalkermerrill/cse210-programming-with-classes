using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
  class ReflectionActivity : Activity
  {
    // Attributes are private using _camelCase naming convention
    private List<string> _prompts;
    private List<string> _questions;
    private string _finalQuestion;
    public ReflectionActivity()
    // Defaults to 2 minutes duration, and initializes prompts and questions.
      : base("Reflection", "This activity will help you reflect on meaningful experiences.\nConsider the following prompts and questions.", 120)
    {
      _prompts = new List<string>
        {
          "Think of a time you overcame a significant challenge.",
          "Think about a time when you celebrated something with your family or friends.",
          "Recall a moment when you made a positive impact on someone’s life.",
          "Recall a moment in time when you felt closely connected to Jesus Christ.",
          "Reflect on a personal achievement you are proud of.",
          "Reflect on a time when someone showed you kindness.",
          "Consider a time when you felt happy and fulfilled.",
          "Consider how you felt when you helped someone in need.",
        };

      _questions = new List<string>
        {
          "Who did you share this experience with?",
          "Who can you pay this experience forward to?",
          "What did you learn about yourself?",
          "What emotions did you feel during this experience?",
          "What do you wish to remember most about this experience?",
          "What made this experience unique?",
          "When you think about this experience, what stands out to you?",
          "Where did this experience take place?",
          "Why was this experience meaningful to you?",
          "How did this experience change you? Should it have changed you more?",
          "How is your relationship with Jesus Christ now, compared to then?",
        };
      _finalQuestion = "How can you draw closer to Jesus Christ now, given all you have learned?";

    }

    // Displays a random prompt then shows each question.
    public void ExecuteReflection()
    {
      Random random = new Random();
      int promptIndex = random.Next(_prompts.Count);
      Console.WriteLine("\nReflection Prompt:");
      Console.WriteLine(_prompts[promptIndex]);
      Pause(30);

      Animation spinner = new Animation("spinner");
      foreach (string question in _questions)
      {
        Console.WriteLine("\nReflect: " + question);
        spinner.ShowSpinner(30);
      }
    }
  }
}