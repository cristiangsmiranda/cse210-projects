using System;
using System.Collections.Generic;
using System.Threading;

public class Listing : Activity
{
    private static readonly string[] Prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void StartTheActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Listing activity!");
        Console.WriteLine();
        string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        Console.WriteLine(description);
        this.ShowSpinner(3);

        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            this.ShowSpinner(3);

            Start(duration);

            Console.WriteLine("Well done!!!");
            Console.WriteLine($"You have completed another {duration} seconds of the Listing activity.");
            this.ShowSpinner(5);
        }
        else
        {
            Console.WriteLine("Invalid duration! Returning to menu.");
            Thread.Sleep(2000);
        }
    }

    private void Start(int duration)
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        this.ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine("You may begin in:");
        this.ShowCountdown(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemCount++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You have listed {itemCount} items.");
    }
}
