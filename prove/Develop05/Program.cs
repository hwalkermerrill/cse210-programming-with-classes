using System;
using System.Collections.Generic;

namespace EternalQuest
{
	// Exceeds requirements: I added a helper class to manage what I called the quest log.
	// This quest log interfaces with a master csv file that tracks all quests, and allows
	// the user to load an existing quest. I also added a default quest to show the user
	// how the program works. Additionally, I added automatic saving and default loading,
	// and I added a level system that tracks the user's progress along their quest.
	// To ensure the user progresses at roughly the right speed based on effort, I also
	// instructed them that they should aim for 400 points per day when they create a goal.
	class Program
	{
		// attributes here, following _camelCase naming convention
		private static QuestLog _questLog = new QuestLog();
		private static List<BaseGoal> _goals = new List<BaseGoal>();
		private static int _totalScore = 0;
		private static int _levelNumber = 1;
		private static string _levelTitle = "Novice Adventurer - Fledgling";

		// I used two arrays to store levels and thresholds
		private static readonly int[] _levelThresholds = {
			0, // Level 1
			2000, // Level 2
			5000, // Level 3
			9000, // Level 4
			15000, // Level 5
			23000, // Level 6
			35000, // Level 7
			51000, // Level 8
			75000, // Level 9
			105000, // Level 10
			155000, // Level 11
			220000, // Level 12
			315000, // Level 13
			445000, // Level 14
			635000, // Level 15
			890000, // Level 16
			1300000, // Level 17
			1800000, // Level 18
			2550000, // Level 19
			3600000  // Level 20
		};
		private static readonly string[] _levelTitles = {
			"Novice Adventurer - Fledgling",
			"Novice Adventurer - Green",
			"Novice Adventurer - Aspirant",
			"Novice Adventurer - Amateur",
			"Apprentice Adventurer",
			"Apprentice Adventurer - Capable",
			"Apprentice Adventurer - Adept",
			"Apprentice Adventurer - Accomplished",
			"Apprentice Adventurer - Senior",
			"Journeyman Adventurer",
			"Journeyman Adventurer - Veteran",
			"Journeyman Adventurer - Knight",
			"Journeyman Adventurer - Ace",
			"Journeyman Adventurer - Commander",
			"Expert Adventurer",
			"Expert Adventurer - Exemplar",
			"Expert Adventurer - Hero",
			"Expert Adventurer - Champion",
			"Expert Adventurer - Lord",
			"Master Adventurer"
		};

		// main program
		static void Main(string[] args)
		{
			_questLog.Initialize();
			_goals = _questLog.LoadQuestGoals(out _totalScore);

			bool exit = false;
			while (!exit)
			{
				Console.Clear();
				DisplayExp();
				Console.WriteLine("1. Show All Quest Goals");
				Console.WriteLine("2. Add New Quest Goal");
				Console.WriteLine("3. Record Quest Event");
				Console.WriteLine("4. Start a New Quest");
				Console.WriteLine("5. Resume an Existing Quest");
				Console.WriteLine("6. Quit");
				Console.Write("Select: ");
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1": ShowGoals(); break;
					case "2": AddGoal(); Persist(); break;
					case "3": RecordEvent(); Persist(); break;
					case "4":
						_questLog.StartNewQuest();
						_goals.Clear();
						_totalScore = 0;
						break;
					case "5":
						_questLog.ResumeQuest();
						_goals = _questLog.LoadQuestGoals(out _totalScore);
						break;
					case "6": exit = true; break;
					default: Console.WriteLine("Your quest awaits! Try again!"); break;
				}

				if (!exit)
				{
					Console.WriteLine("\nFarewell, and Good Luck, Adventurer! \nPress Enter to continue...");
				}
			}
		}

		// My creative method, displays current level for the user
		static void DisplayExp()
		{
			bool levelUp = UpdateLevel();

			if (levelUp)
			{
				Console.WriteLine($"=== LEVEL UP! === \n === You have been promoted to {_levelTitle}! ===\n");
			}

			Console.WriteLine($"=== Level {_levelNumber}: {_levelTitle} ===");

			if (_levelNumber < _levelThresholds.Length)
			{
				int nextThreshold = _levelThresholds[_levelNumber];
				Console.WriteLine($"=== Exp {_totalScore} / {nextThreshold} ===\n");
			}
			else
			{
				Console.WriteLine($"=== Exp {_totalScore} / MASTERED ===\n");
			}
		}

		static void ShowGoals()
		{
			if (_goals.Count == 0)
			{
				Console.WriteLine("No goals have been defined yet for this quest.");
				return;
			}

			for (int i = 0; i < _goals.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {_goals[i].DisplayGoal()}");
			}
		}

		static void AddGoal()
		{
			Console.WriteLine("Choose a goal type: 1) Simple  2) Eternal  3) Checklist");
			var type = Console.ReadLine();

			Console.Write("Name: ");
			var name = Console.ReadLine();
			Console.Write("Description: ");
			var description = Console.ReadLine();
			Console.Write("Exp value (aim for 400/day): ");
			int exp = int.TryParse(Console.ReadLine(), out int tryExp) ? tryExp : 0;

			switch (type)
			{
				case "1":
					_goals.Add(new SimpleGoal(name, description, exp));
					break;
				case "2":
					_goals.Add(new EternalGoal(name, description, exp));
					break;
				case "3":
					Console.Write("Times Required to Complete: ");
					int target = int.TryParse(Console.ReadLine(), out int tar) ? tar : 1;
					Console.Write("Completion bonus: ");
					int bonus = int.TryParse(Console.ReadLine(), out int bon) ? bon : 0;
					_goals.Add(new ChecklistGoal(name, description, exp, target, bonus));
					break;
				default:
					Console.WriteLine("You are not yet strong enough for this quest.");
					break;
			}
		}

		static void RecordEvent()
		{
			ShowGoals();
			if (_goals.Count == 0) return;

			Console.Write("Which goal you achieve? (select number): ");
			if (int.TryParse(Console.ReadLine(), out int index)
				&& index > 0 && index <= _goals.Count)
			{
				int earned = _goals[index - 1].RecordEvent();
				_totalScore += earned;
			}
			else
			{
				Console.WriteLine("You cannot complete part of this quest, yet.");
			}
		}

		// Helper method to save quest state
		static void Persist()
		{
			_questLog.SaveQuestGoals(_goals, _totalScore);
		}

		// Helper method for updating user's level
		private static bool UpdateLevel()
		{
			int previousLevel = _levelNumber;

			for (int i = _levelThresholds.Length - 1; i >= 0; i--)
			{
				if (_totalScore >= _levelThresholds[i])
				{
					_levelNumber = i + 1;
					_levelTitle = _levelTitles[i];
					break;
				}
			}

			return _levelNumber != previousLevel;
		}
	}
}