using System;
using System.Collections.Generic;

public partial class Program
{
    private static void ShowSavedFiles()
    {
        Console.Clear();
        if (savedFiles.Count == 0)
        {
            Console.WriteLine("No files saved yet.");
        }
        else
        {
            Console.WriteLine("Saved Files:");
            foreach (var file in savedFiles)
            {
                Console.WriteLine($"{file.Filename} - Created on {file.CreatedDate}");
            }
        }
        Console.ReadLine();
    }
}

public class ShowGoalsFilename
{
    public string Filename { get; set; }
    public DateTime CreatedDate { get; set; }

    public ShowGoalsFilename(string filename, DateTime createdDate)
    {
        Filename = filename;
        CreatedDate = createdDate;
    }
}
