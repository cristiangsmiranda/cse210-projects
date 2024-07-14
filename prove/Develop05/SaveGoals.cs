public partial class Program
{
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

        savedFiles.Add(new ShowGoalsFilename(filename, DateTime.Now));

        SaveSavedFilesList();

        Console.WriteLine($"Goals saved successfully to {filename}. Press Enter to continue.");
        Console.ReadLine();
    }

    private static void SaveSavedFilesList()
    {
        using (StreamWriter writer = new StreamWriter("saved_files.txt"))
        {
            foreach (var savedFile in savedFiles)
            {
                writer.WriteLine($"{savedFile.Filename};{savedFile.CreatedDate}");
            }
        }
    }
}
