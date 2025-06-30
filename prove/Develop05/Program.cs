using System;
using System.Collections.Generic;

namespace EternalQuest
{
	class Program
	{
		// attributes here, following _camelCase naming convention
		private static QuestLog _questLog = new QuestLog();
		private static List<BaseGoal> _goals = new List<BaseGoal>();
		private static int _totalScore = 0;

		// main program
		static void Main(string[] args)
		{
			_questLog.Initialize();
			_goals = _questLog.LoadQuestGoals(out _totalScore);

			bool exit = false;
			while (!exit)
			{
				Console.Clear();
				DisplayScore();
				Console.WriteLine("1. Add New Goal");
				Console.WriteLine("2. Record Event");
				Console.WriteLine("3. Show All Goals");
				Console.WriteLine("4. Start a New Quest");
				Console.WriteLine("5. Resume an Existing Quest");
				Console.WriteLine("6. Quit");
				Console.Write("Select: ");
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1": AddGoal(); break;
					case "2": RecordEvent(); break;
					case "3": ShowGoals(); break;
					case "4":
						_questLog.StartNewQuest();
						_goals.Clear();
						_totalScore = 0;
						break;
					case "5":
						_questLog.LoadQuest();
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

		static void DisplayScore()
		{
			Console.WriteLine($"=== Total Score: {_totalScore} pts ===\n");
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
			Console.Write("Point value (aim for 400 per day): ");
			var points = int.Parse(Console.ReadLine());

			switch (type)
			{
				case "1":
					_goals.Add(new SimpleGoal(name, description, points));
					break;
				case "2":
					_goals.Add(new EternalGoal(name, description, points));
					break;
				case "3":
					Console.Write("Times Required to Complete: ");
					var target = int.Parse(Console.ReadLine());
					Console.Write("Completion Bonus: ");
					var bonus = int.Parse(Console.ReadLine());
					_goals.Add(new ChecklistGoal(name, description, points, target, bonus));
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

			Console.Write("Which did you accomplish? (select the number): ");
			if (int.TryParse(Console.ReadLine(), out int index)
					&& index > 0 && index <= _goals.Count)
			{
				_goals[index - 1].RecordEvent();
			}
			else
			{
				Console.WriteLine("You cannot complete part of this quest, yet.");
			}
		}
	}
}