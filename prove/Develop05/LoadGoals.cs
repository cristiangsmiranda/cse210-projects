public partial class Program
{
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
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split(';');
                    if (parts.Length < 5)
                        continue;

                    string type = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    int points;
                    if (!int.TryParse(parts[3], out points))
                    {
                        Console.WriteLine($"Failed to parse points '{parts[3]}'. Skipping goal.");
                        continue;
                    }
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
                            if (parts.Length < 8)
                                continue;
                            int targetCount, currentCount, bonusPoints;
                            if (!int.TryParse(parts[5], out targetCount) ||
                                !int.TryParse(parts[6], out currentCount) ||
                                !int.TryParse(parts[7], out bonusPoints))
                            {
                                Console.WriteLine($"Failed to parse checklist details for goal '{name}'. Skipping goal.");
                                continue;
                            }
                            goal = new ChecklistGoal(name, description, points, targetCount, bonusPoints)
                            {
                                CurrentCount = currentCount,
                                IsComplete = isComplete
                            };
                            break;
                        default:
                            Console.WriteLine($"Unknown goal type '{type}'. Skipping goal.");
                            continue;
                    }

                    goal.SetCompletion(isComplete); // Set completion state

                    goals.Add(goal);
                }

                if (!reader.EndOfStream)
                {
                    string scoreLine = reader.ReadLine();
                    if (!string.IsNullOrEmpty(scoreLine) && int.TryParse(scoreLine, out int loadedScore))
                    {
                        score = loadedScore;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to parse score '{scoreLine}'. Setting score to 0.");
                        score = 0;
                    }
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
}
