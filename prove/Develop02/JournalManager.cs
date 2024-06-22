using System;
using System.Collections.Generic;
using System.IO;

public static class JournalManager
{
    public static void SaveJournal(List<string> entries, string filename)
    {
        try
        {
            File.WriteAllLines(filename, entries);
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}");
        }
    }

    public static List<string> LoadJournal(string filename)
    {
        List<string> loadedEntries = new List<string>();

        try
        {
            if (File.Exists(filename))
            {
                loadedEntries = new List<string>(File.ReadAllLines(filename));
                Console.WriteLine("Journal loaded successfully");
            }
            else
            {
                Console.WriteLine("The specified file does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }

        return loadedEntries;
    }
}
