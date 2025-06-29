using System;
using System.Collections.Generic;

namespace EternalQuest
{
	class Program
	{
		// attributes here, following _camelCase naming convention
		private static int _totalScore = 0;
		private static List<BaseGoal> _goals = new List<BaseGoal>();

		static void Main(string[] args)
		{
			bool exit = false;
			while (!exit)
			{
				Console.Clear();
				DisplayScore();
				Console.WriteLine("1. Add New Goal");
				Console.WriteLine("2. Record Event");
				Console.WriteLine("3. Show All Goals");
				Console.WriteLine("4. Save to File");
				Console.WriteLine("5. Load from File");
				Console.WriteLine("6. Quit");
				Console.Write("Select: ");
				var choice = Console.ReadLine();

				switch (choice)
				{
					case "1": AddGoal(); break;
					case "2": RecordEvent(); break;
					case "3": ShowGoals(); break;
					case "4": SaveGoals(); break;
					case "5": LoadGoals(); break;
					case "6": exit = true; break;
					default: Console.WriteLine("Invalid."); break;
				}

				if (!exit)
				{
					Console.WriteLine("\n(press Enter to continue)");
					Console.ReadLine();
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
				Console.WriteLine("No goals defined yet.");
				return;
			}

			for (int i = 0; i < _goals.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {_goals[i].DisplayGoal()}");
			}
		}

		static void AddGoal()
		{
			Console.WriteLine("Choose goal type: 1) Simple  2) Eternal  3) Checklist");
			var type = Console.ReadLine();

			Console.Write("Name: ");
			var name = Console.ReadLine();
			Console.Write("Description: ");
			var desc = Console.ReadLine();
			Console.Write("Point value: ");
			var pts = int.Parse(Console.ReadLine());

			switch (type)
			{
				case "1":
					_goals.Add(new SimpleGoal(name, desc, pts));
					break;

				case "2":
					_goals.Add(new EternalGoal(name, desc, pts));
					break;

				case "3":
					Console.Write("How many times needed? ");
					var target = int.Parse(Console.ReadLine());
					Console.Write("Bonus on completion: ");
					var bonus = int.Parse(Console.ReadLine());
					_goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
					break;

				default:
					Console.WriteLine("Invalid type.");
					break;
			}
		}

		static void RecordEvent()
		{
			ShowGoals();
			if (_goals.Count == 0) return;

			Console.Write("Which goal number did you accomplish? ");
			if (int.TryParse(Console.ReadLine(), out int index)
					&& index > 0 && index <= _goals.Count)
			{
				_goals[index - 1].RecordEvent();
			}
			else
			{
				Console.WriteLine("Invalid selection.");
			}
		}

		static void SaveGoals()
		{
			Console.WriteLine("SaveGoals() not implemented yet.");
		}

		static void LoadGoals()
		{
			Console.WriteLine("LoadGoals() not implemented yet.");
		}
	}
}