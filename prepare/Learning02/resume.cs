using System;
using System.Collections.Generic;
public class Resume
{
    public string _name;
    public List<Job> _Jobs;
    public Resume()
    {
        _Jobs = new List<Job>();
            
    }

    public void DisplayResumeDetails()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs: ");

        foreach (var Job in _Jobs)
        {
            Job.DisplayJobDetails();
            Console.WriteLine();
        }
    }
}

