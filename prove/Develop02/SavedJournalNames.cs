using System;
using System.Collections.Generic;

public static class SavedJournalNames
{
    private static List<string> savedNames = new List<string>();

    public static void AddSavedJournal(string filename)
    {
        savedNames.Add(filename);
    }

    public static void DisplaySavedJournals()
    {
        Console.WriteLine("List of saved journals:");
        foreach (var name in savedNames)
        {
            Console.WriteLine(name);
        }
    }
}
