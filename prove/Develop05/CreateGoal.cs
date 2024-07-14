public partial class Program
{
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
}
