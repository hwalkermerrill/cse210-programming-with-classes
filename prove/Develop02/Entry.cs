using System;

class Entry
{
  // _attributes here
  private DateTime _today = DateTime.Today;
  private Prompts prompts;
  public Entry()
  {
    // Initialize prompts when this class is first instanced
    prompts = new Prompts();
  }
  public void WriteEntry(string _filePath)
  {
    // Write the journal entries to the CSV file
    string prompt = prompts.GetRandomPrompt();

    Console.WriteLine("\nWrite your journal entry for today while considering the following prompt: " + prompt);
    Console.WriteLine("Press enter when you are finished writing your entry.\n");

    string entry = Console.ReadLine();
    string currentDate = _today.ToString("MM/dd/yyyy");

    using (StreamWriter jEntry = new StreamWriter(_filePath, true))
    {
      jEntry.WriteLine($"\"{entry}\", Prompt: {prompt}, - {currentDate}");
    }
    Console.WriteLine("\nYour entry has been saved.");
  }
}