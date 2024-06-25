// as a point of creativity, I added our class to read and store the names
// of the files saved in SaveJournal, so that if the user forgets the name of the journals they saved
// they can look it up using option number 5 and have all the journal names saved in a list

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> JournalEntries = new List<string>();
    static void Main(string[] args)
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What challenges did my face today?",
            "What made my smile today?",
        };

        while (true)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save ");
            Console.WriteLine("5. Display Saved Journal Names");
            Console.WriteLine("6. Quit");
            Console.WriteLine("What would you like to do?");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(prompts);
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    LoadJournal();
                    break;
                case "4":
                    SaveJournal();
                    break;
                case "5":
                    SavedJournalNames.DisplaySavedJournals();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(List<string> prompts)
    {
        Random random = new Random();
        int promptIndex = random.Next(prompts.Count);
        string selectedPrompt = prompts[promptIndex];

        Console.WriteLine(selectedPrompt);
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string entry = $"{date} = Prompt: {selectedPrompt} - Response: {response}";

        JournalEntries.Add(entry);
        File.AppendAllText("Journal.txt", entry + Environment.NewLine);
        Console.WriteLine("Your entry has been saved.");
    }

    static void DisplayJournal()
    {
        if (JournalEntries.Count > 0)
        {
            foreach (string entry in JournalEntries)
            {
                Console.WriteLine(entry);
            }
        }
        else
        {
            Console.WriteLine("No journal entries found.");
        }
    }

    static void SaveJournal()
    {
        Console.WriteLine("What is the file name? ");
        string filename = Console.ReadLine();

        JournalManager.SaveJournal(JournalEntries, filename);
        SavedJournalNames.AddSavedJournal(filename);
    }

    static void LoadJournal()
    {
        Console.WriteLine("What is the filename? ");
        string filename = Console.ReadLine();

        JournalEntries = JournalManager.LoadJournal(filename);
    }
}
