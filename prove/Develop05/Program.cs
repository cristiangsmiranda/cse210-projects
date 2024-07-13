using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public abstract int RecordEvent();
    public virtual string GetStatus()
    {
        return IsComplete ? $"[X] {Name} ({Description})" : $"[ ] {Name} ({Description})";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] {Name} ({Description})" : $"[ ] {Name} ({Description})";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetStatus()
    {
        return $"[∞] {Name} ({Description})";
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            CurrentCount++;
            if (CurrentCount >= TargetCount)
            {
                IsComplete = true;
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        if (IsComplete)
            return $"[X] {Name} (Completed {CurrentCount}/{TargetCount} times) ({Description})";
        else
            return $"[ ] {Name} (Completed {CurrentCount}/{TargetCount} times) ({Description})";
    }
}

public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Current score: {score}");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals (e.g., goals.txt)");
            Console.WriteLine("4. Load Goals (e.g., goals.txt)");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Leaving.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static void LoadGoals()
    {
        Console.Clear();
        Console.WriteLine("Enter the filename to load goals from (e.g., goals.txt):");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            goals.Clear();
            score = 0;

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    Goal goal;
                    switch (type)
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal(name, description, points);
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal(name, description, points);
                            break;
                        case "ChecklistGoal":
                            int targetCount = int.Parse(parts[5]);
                            int currentCount = int.Parse(parts[6]);
                            int bonusPoints = int.Parse(parts[7]);
                            goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints)
                            {
                                CurrentCount = currentCount,
                                IsComplete = isComplete
                            };
                            break;
                        default:
                            continue;
                    }

                    goals.Add(goal);
                }

                if (int.TryParse(reader.ReadLine(), out int loadedScore))
                {
                    score = loadedScore;
                }
            }

            Console.WriteLine($"Goals loaded successfully from {filename}. Press Enter to continue.");
        }
        else
        {
            Console.WriteLine($"File '{filename}' not found. Press Enter to continue.");
        }

        Console.ReadLine();
    }
    private static void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create?");
        string choice = Console.ReadLine();

        Goal newGoal;
        switch (choice)
        {
            case "1":
                newGoal = CreateSimpleGoal();
                break;
            case "2":
                newGoal = CreateEternalGoal();
                break;
            case "3":
                newGoal = CreateChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadLine();
                return;
        }

        goals.Add(newGoal);
        Console.WriteLine("Goal created successfully. Press Enter to continue.");
        Console.ReadLine();
    }

    private static Goal CreateSimpleGoal()
    {
        Console.WriteLine("Creating a new Simple Goal:");
        Console.WriteLine("What is the name of your goal?");
        string name = Console.ReadLine();
        Console.WriteLine("What is a short description of it?");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal?");
        int points = int.Parse(Console.ReadLine());
        return new SimpleGoal(name, description, points);
    }

    private static Goal CreateEternalGoal()
    {
        Console.WriteLine("Creating a new Eternal Goal:");
        Console.WriteLine("What is the name of your goal?");
        string name = Console.ReadLine();
        Console.WriteLine("What is a short description of it?");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal?");
        int points = int.Parse(Console.ReadLine());
        return new EternalGoal(name, description, points);
    }

    private static Goal CreateChecklistGoal()
    {
        Console.WriteLine("Creating a new Checklist Goal:");
        Console.WriteLine("What is the name of your goal?");
        string name = Console.ReadLine();
        Console.WriteLine("What is a short description of it?");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points per record associated with this goal?");
        int pointsPerRecord = int.Parse(Console.ReadLine());
        Console.Write("Enter total count required: ");
        int totalCount = int.Parse(Console.ReadLine());
        Console.Write("Enter bonus points upon completion: ");
        int bonusPoints = int.Parse(Console.ReadLine());
        return new ChecklistGoal(name, description, pointsPerRecord, totalCount, bonusPoints);
    }

    private static void RecordEvent()
    {
        Console.Clear();
        ListGoals();
        Console.WriteLine("Enter the goal number to record an event: ");
        int goalNumber;
        if (int.TryParse(Console.ReadLine(), out goalNumber))
        {
            if (goalNumber > 0 && goalNumber <= goals.Count)
            {
                score += goals[goalNumber - 1].RecordEvent();
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    private static void ListGoals()
    {
        Console.Clear();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
            }
        }
        Console.ReadLine();
    }

    private static void SaveGoals()
    {
        Console.Clear();
        Console.WriteLine("Enter the filename to save goals to (e.g., goals.txt):");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name};{goal.Name};{goal.Description};{goal.Points};{goal.IsComplete}");

                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.TargetCount};{checklistGoal.CurrentCount};{checklistGoal.BonusPoints}");
                }
                else
                {
                    writer.WriteLine(";;;;"); // Empty placeholders for non-checklist goals
                }
            }

            writer.WriteLine(score); // Write score at the end
        }

        Console.WriteLine($"Goals saved successfully to {filename}. Press Enter to continue.");
        Console.ReadLine();
    }
}
