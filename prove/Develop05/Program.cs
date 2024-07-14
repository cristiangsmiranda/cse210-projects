// as a point of creativity I created another option for the main menu
// that shows the name of the meta file that was saved,
// as well as showing the exact date when that file was made

using System;
using System.Collections.Generic;
using System.IO;

public partial class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static List<ShowGoalsFilename> savedFiles = new List<ShowGoalsFilename>();
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
            Console.WriteLine("6. Show Saved Files");
            Console.WriteLine("7. Quit");
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
                    ShowSavedFiles();
                    break;
                case "7":
                    Console.WriteLine("Leaving.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
