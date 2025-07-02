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
    private Dictionary<string, (DateTime LastAccess, string Description)> _masterRecords = new();
    private string _activeQuestPath;

    // properties here
    public string ActiveQuestPath => _activeQuestPath;
    private const string DefaultQuestFile = "MainQuest.csv";
    private const string MasterHeader = "fileName,dateTime,adventureDescription";
    private const string GoalHeader
      = "goalType,goalName,goalDescription,pointValue,targetCount,timesCompleted,isComplete,completionBonus";

    // methods here
    // Build program on startup
    public void Initialize()
    {
      EnsureMasterRecordExists();
      LoadMasterRecords();
      ChooseActiveQuest();
    }

    // Change active quest file
    public void ResumeQuest()
    {
      Console.WriteLine("You have embarked on the following adventures:");
      var quests = _masterRecords.Keys.ToList();
      for (int i = 0; i < quests.Count; i++)
      {
        var key = quests[i];
        var data = _masterRecords[key];
        Console.WriteLine($"{i + 1}. {key}");
        Console.WriteLine($"{data.Description}\n");
      }

      Console.Write("Choose Your Quest! (Select the corresponding number): ");
      if (int.TryParse(Console.ReadLine(), out int index)
        && index >= 1 && index <= _masterRecords.Count)
      {
        _activeQuestPath = quests[index - 1];
        _masterRecords[_activeQuestPath] = (DateTime.UtcNow, _masterRecords[_activeQuestPath].Description);
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
        using var sw = new StreamWriter(name, false);
        sw.WriteLine(GoalHeader);
        Console.WriteLine($"Embarking on the {name} quest...");
      }
      else
      {
        Console.WriteLine($"You are already on a quest to {name}, we shall continue!");
      }

      Console.Write("Describe this Quest: ");
      var description = Console.ReadLine().Trim();
      _masterRecords[name] = (DateTime.UtcNow, description);

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

      var lines = File.ReadAllLines(_activeQuestPath);

      foreach (var line in lines.Skip(1)) // skip header
      {
        var parts = line.Split(',', 8);
        if (parts.Length < 8) continue;

        var type = parts[0].Trim();
        var name = parts[1].Trim();
        var description = parts[2].Trim().Trim('"');
        var points = int.Parse(parts[3]);
        var targetCount = int.Parse(parts[4]);
        var timesDone = int.Parse(parts[5]);
        var isComplete = bool.Parse(parts[6]);
        var completeBonus = int.Parse(parts[7]);

        BaseGoal goal = type switch
        {
          "Simple" => new SimpleGoal(name, description, points),
          "Eternal" => new EternalGoal(name, description, points),
          "Checklist" => new ChecklistGoal(name, description, points, targetCount, completeBonus),
          _ => null
        };
        if (goal != null)
        {
          // now restore its internal counters & completion flag:
          switch (goal)
          {
            case SimpleGoal sg:
              if (isComplete) sg.RecordEvent(); // or set private field via reflection
              break;
            case EternalGoal eg:
              for (int i = 0; i < timesDone; i++) eg.RecordEvent();
              break;
            case ChecklistGoal cg:
              // update its timesDone and bonus
              // you may need to add a constructor or setter to restore state
              break;
          }
          goals.Add(goal);
        }
      }

      return goals;
    }

    // Updates the active quest CSV with the current goals and total score
    public void SaveQuestGoals(List<BaseGoal> goals, int totalScore)
    {
      using var sw = new StreamWriter(_activeQuestPath, false);
      sw.WriteLine(GoalHeader);

      foreach (var goal in goals)
      {
        var line = goal switch
        {
          SimpleGoal sg => $"Simple,{sg.Name},\"{sg.Description}\",{sg.PointValue},1,{(sg.IsComplete ? 1 : 0)},{sg.IsComplete},{0}",
          EternalGoal eg => $"Eternal,{eg.Name},\"{eg.Description}\",{eg.PointValue},0,{eg.TimesDone},false,0",
          ChecklistGoal cg => $"Checklist,{cg.Name},\"{cg.Description}\",{cg.PointValue},{cg.TargetCount},{cg.TimesDone},{cg.IsComplete},{cg.CompletionBonus}",
          _ => throw new InvalidOperationException("Unknown quests cannot be followed...")
        };
        sw.WriteLine(line);
      }

      var rec = _masterRecords[_activeQuestPath];
      _masterRecords[_activeQuestPath] = (DateTime.UtcNow, rec.Description);
      SaveMasterRecords();
    }

    private void EnsureMasterRecordExists()
    {
      if (!File.Exists(_masterRecordPath))
      {
        File.WriteAllText(_masterRecordPath,
          "fileName,dateTime,adventureDescription\n");
        _masterRecords[DefaultQuestFile] =
          (DateTime.UtcNow, "This main quest demonstrates how to use this program to set up your own goals and quests!");
        SaveMasterRecords();

        File.WriteAllText(DefaultQuestFile, GoalHeader + "\n");
      }

    }

    private void LoadMasterRecords()
    {
      _masterRecords.Clear();
      var lines = File.ReadAllLines(_masterRecordPath);

      foreach (var line in lines.Skip(1)) // Skip header
      {
        var parts = line.Split(',', 3);
        if (parts.Length < 3) continue;

        var fileName = parts[0].Trim();
        var dateText = parts[1].Trim();
        var description = parts[2].Trim().Trim('"');

        if (DateTime.TryParse(
          dateText,
          null,
          DateTimeStyles.RoundtripKind,
          out var dt))
        {
          _masterRecords[fileName] = (dt, description);
        }
      }
    }

    private void SaveMasterRecords()
    {
      using var sw = new StreamWriter(_masterRecordPath, false);
      sw.WriteLine(MasterHeader);

      foreach (var key in _masterRecords)
      {
        var fileName = key.Key;
        var LastAccess = key.Value.LastAccess;
        var description = key.Value.Description.Replace("\"", "\"\""); // Escape quotes
        sw.WriteLine($"{fileName},{LastAccess:o},\"{description}\"");
      }
    }

    // Defaults to most recently accessed quest
    private void ChooseActiveQuest()
    {
      _activeQuestPath = _masterRecords
        .OrderByDescending(key => key.Value.LastAccess)
        .First().Key;
    }
  }
}