using System;

class Entry
{
  // _attributes here
  private DateTime _today = DateTime.Today;
  private Prompts _prompts;
  private string _jText;
  private string _jPrompt;
  private DateTime _jDate;
  public Entry()
  {
    // Initialize prompts when this class is first instanced
    _prompts = new Prompts();
  }
  public Entry(string jText, string jPrompt, DateTime jDate)
  {
    _jText = jText;
    _jPrompt = jPrompt;
    _jDate = jDate;
  }
  public void WriteEntry(string _filePath)
  {
    // Write the journal entries to the CSV file
    string prompt = _prompts.GetRandomPrompt();

    Console.WriteLine("\nWrite your journal entry for today while considering the following prompt: " + prompt);
    Console.WriteLine("Press enter when you are finished writing your entry.\n");

    string entry = Console.ReadLine();
    string currentDate = _today.ToString("MM/dd/yyyy");

    using (StreamWriter jEntry = new StreamWriter(_filePath, true))
    {
      jEntry.WriteLine($"\"{entry}\", {prompt}, {currentDate}");
    }
    Console.WriteLine("\nYour entry has been saved.");
  }
  public void DisplayEntry()
  {
    Console.WriteLine($"Date: {_jDate:MM/dd/yyyy}\n");
    Console.WriteLine($"Prompt: {_jPrompt}\n");
    Console.WriteLine($"Entry: {_jText}\n");
  }
}