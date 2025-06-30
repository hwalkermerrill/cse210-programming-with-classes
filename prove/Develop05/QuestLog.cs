using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EternalQuest
{
  // This class manages the quest csv files, including saving and loading
  public class QuestLog
  {
    // attributes here, following _camelCase naming convention
    private readonly string _masterRecordPath = "MasterQuestRecord.csv";
    private List<MasterEntry> _masterEntries = new List<MasterEntry>();
    private string _activeQuestPath;

    // properties here
    public string ActiveQuestPath => _activeQuestPath;
    private class MasterEntry
    {
      public string FileName { get; set; }
      public DateTime LastAccess { get; set; }
    }

    // methods here
    // Build program on startup
    public void Initialize()
    {
      EnsureMasterRecordExists();
      LoadAvailableQuests();
      ChooseActiveQuest();
    }

    // Change active quest file
    public void LoadQuest()
    {
      Console.WriteLine("You have embarked on the following adventures:");
      for (int i = 0; i < _masterEntries.Count; i++)
        Console.WriteLine($"{i + 1}. {_masterEntries[i].FileName}");

      Console.Write("Choose Your Quest! (Select the corresponding number): ");
      if (int.TryParse(Console.ReadLine(), out int set)
          && set >= 1 && set <= _masterEntries.Count)
      {
        var entry = _masterEntries[set - 1];
        entry.LastAccess = DateTime.UtcNow;
        _activeQuestPath = entry.FileName;
        UpdateQuestLog();
        Console.WriteLine($"Embarking on the {_activeQuestPath} quest...");
      }
      else
      {
        Console.WriteLine("Invalid selection.");
      }
    }

    // Create a new quest file
    public void StartNewQuest()
    {
      Console.Write("What shall we call your grand new adventure? : ");
      var name = Console.ReadLine().Trim();
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

      var existing = _masterEntries.FirstOrDefault(e => e.FileName == name);
      if (existing != null)
        existing.LastAccess = DateTime.UtcNow;
      else
        _masterEntries.Add(new MasterEntry
        {
          FileName = name,
          LastAccess = DateTime.UtcNow
        });

      _activeQuestPath = name;
      UpdateQuestLog();
    }

    // Loads goals from the active quest CSV
    public List<BaseGoal> LoadQuestGoals(out int totalScore)
    {
      totalScore = 0;
      var goals = new List<BaseGoal>();

      if (!File.Exists(_activeQuestPath))
        return goals;

      foreach (var line in File.ReadAllLines(_activeQuestPath))
      {
        // TODO: Parse each line into one of SimpleGoal/EternalGoal/ChecklistGoal,
        //       extracting point values, completion counts, etc.
        //       Also parse out your saved totalScore if you choose to store it here.
      }

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

      var entry = _masterEntries.First(e => e.FileName == _activeQuestPath);
      entry.LastAccess = DateTime.UtcNow;
      UpdateQuestLog();
    }

    private void EnsureMasterRecordExists()
    {
      if (!File.Exists(_masterRecordPath))
      {
        File.WriteAllText(_masterRecordPath,
          $"MainQuest.csv,{DateTime.UtcNow:o}\n");
        File.WriteAllText("MainQuest.csv", "");
      }
    }

    private void LoadAvailableQuests()
    {
      _masterEntries.Clear();
      foreach (var line in File.ReadAllLines(_masterRecordPath))
      {
        var parts = line.Split(',');
        if (parts.Length < 2) continue;
        if (DateTime.TryParse(parts[1],
              null,
              DateTimeStyles.RoundtripKind,
              out DateTime dt))
        {
          _masterEntries.Add(new MasterEntry
          {
            FileName = parts[0],
            LastAccess = dt
          });
        }
      }
    }

    private void UpdateQuestLog()
    {
      using var sw = new StreamWriter(_masterRecordPath, false);
      foreach (var e in _masterEntries)
        sw.WriteLine($"{e.FileName},{e.LastAccess:o}");
    }

    // Defaults to most recently accessed quest
    private void ChooseActiveQuest()
    {
      var newest = _masterEntries
        .OrderByDescending(e => e.LastAccess)
        .First();
      _activeQuestPath = newest.FileName;
    }

    private string BuildLineForGoal(BaseGoal g)
    {
      // TODO: Serialize each goal into a single CSV line.
      // Example (pseudo‐format): 
      // type|Name|Description|PointValue|timesDone|target|bonus|isComplete
      // return $"{g.GetType().Name}|{g.Name}|{g.Description}|{...}";
      return "";
    }
  }
}