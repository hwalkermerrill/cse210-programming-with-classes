using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EternalQuest
{
  // This class manages the quest csv files, including saving and loading
  public class QuestLog
  {
    // attributes here, following _camelCase naming convention
    private readonly string _masterRecordPath = "MasterQuestRecord.csv";
    private readonly Dictionary<string, DateTime> _masterRecords = new Dictionary<string, DateTime>();
    private string _activeQuestPath;

    // properties here
    public string ActiveQuestPath => _activeQuestPath;
    const string DefaultQuestFile = "MainQuest.csv";

    // methods here
    // Build program on startup
    public void Initialize()
    {
      EnsureMasterRecordExists();
      LoadMasterRecords();
      ChooseActiveQuest();
    }

    // Change active quest file
    public void LoadQuest()
    {
      Console.WriteLine("You have embarked on the following adventures:");
      var quests = _masterRecords.Keys.ToList();
      for (int i = 0; i < quests.Count; i++)
        Console.WriteLine($"{i + 1}. {quests[i]}");

      Console.Write("Choose Your Quest! (Select the corresponding number): ");
      if (int.TryParse(Console.ReadLine(), out int set)
        && set >= 1 && set <= _masterRecords.Count)
      {
        _activeQuestPath = quests[set - 1];
        _masterRecords[_activeQuestPath] = DateTime.UtcNow;
        SaveMasterRecords();
        Console.WriteLine($"Embarking on the {_activeQuestPath} quest...");
      }
      else
      {
        Console.WriteLine("You cannot go that way! Turn Back!!");
      }
    }

    // Create a new quest file
    public void StartNewQuest()
    {
      Console.Write("What shall we call your grand new adventure? : ");
      var name = Console.ReadLine().Trim();
      if (string.IsNullOrEmpty(name))
      {
        Console.WriteLine("You must name your quest! Try again.");
        return;
      }

      if (!name.EndsWith(".csv")) name += ".csv";

      if (!File.Exists(name))
      {
        File.WriteAllText(name, "");
        Console.WriteLine($"Embarking on the {name} quest...");
      }
      else
      {
        Console.WriteLine($"You are already on a quest to {name}, we shall continue!");
      }

      _masterRecords[name] = DateTime.UtcNow;
      _activeQuestPath = name;
      SaveMasterRecords();
    }

    // Loads goals from the active quest CSV
    public List<BaseGoal> LoadQuestGoals(out int totalScore)
    {
      totalScore = 0;
      var goals = new List<BaseGoal>();

      if (!File.Exists(_activeQuestPath))
        return goals;

      // foreach (var line in File.ReadAllLines(_activeQuestPath))
      // {
      //   // TODO: Parse each line into the correct goal type
      // }

      return goals;
    }

    // Updates the active quest CSV with the current goals and total score
    public void SaveQuestGoals(List<BaseGoal> goals, int totalScore)
    {
      using var sw = new StreamWriter(_activeQuestPath, false);
      sw.WriteLine($"Score,{totalScore}");

      foreach (var goal in goals)
      {
        sw.WriteLine(BuildLineForGoal(goal));
      }

      _masterRecords[_activeQuestPath] = DateTime.UtcNow;
      SaveMasterRecords();
    }

    private void EnsureMasterRecordExists()
    {
      if (!File.Exists(_masterRecordPath))
      {
        File.WriteAllText(_masterRecordPath,
          $"{DefaultQuestFile},{DateTime.UtcNow:o}\n");
        File.WriteAllText($"{DefaultQuestFile}", "");
      }
    }

    private void LoadMasterRecords()
    {
      _masterRecords.Clear();
      var lines = File.ReadAllLines(_masterRecordPath);
      foreach (var line in lines.Skip(1)) // Skip header
      {
        var parts = line.Split(',');
        if (parts.Length < 2) continue;

        var fileName = parts[0].Trim();
        var dateText = parts[1].Trim();

        if (DateTime.TryParse(
          dateText,
          null,
          DateTimeStyles.RoundtripKind,
          out DateTime dt))
        {
          _masterRecords[fileName] = dt;
        }
      }
    }

    private void SaveMasterRecords()
    {
      using var sw = new StreamWriter(_masterRecordPath, false);
      sw.WriteLine("fileName,dateTime");
      foreach (var key in _masterRecords)
        sw.WriteLine($"{key.Key},{key.Value:o}");
    }

    // Defaults to most recently accessed quest
    private void ChooseActiveQuest()
    {
      _activeQuestPath = _masterRecords.OrderByDescending(key => key.Value).FirstOrDefault().Key;
    }

    private string BuildLineForGoal(BaseGoal g)
    {
      // TODO: Serialize each goal into a single CSV line;
      return "";
    }
  }
}