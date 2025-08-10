using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nMenu Options:");
            Console.ResetColor();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Select a choice: ");
            Console.ResetColor();


            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        UpdateLevel();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nYou have {_score} points. | Level {_level} - {GetTitle()}");
        Console.ResetColor();
    }


    private void UpdateLevel()
    {
        _level = (_score / 500) + 1;
    }

    private string GetTitle()
    {
        if (_level < 3) return "Apprentice";
        if (_level < 5) return "Knight";
        if (_level < 8) return "Champion";
        return "Ninja Unicorn 🦄";
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            string status = goal.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{index}. {status} {goal.GetDetailsString()}");
            index++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();
        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a short description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter the points value: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Enter target completions: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points for completion: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoalDetails();
        Console.Write("Enter the goal number: ");
        int goalNum = int.Parse(Console.ReadLine());

        if (goalNum > 0 && goalNum <= _goals.Count)
        {
            _goals[goalNum - 1].RecordEvent(ref _score);
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] details = parts[1].Split("|");

                if (type == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3])));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                }
                else if (type == "ChecklistGoal")
                {
                    _goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]),
                        int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5])));
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
