using System;
using System.Threading;


public class Breathing : Activity
{
    public override void StartTheActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Breathing activity!");
        Console.WriteLine();
        string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        Console.WriteLine(description);
        this.ShowSpinner(5);

        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            this.ShowSpinner(3);

            Start(duration);

            Console.WriteLine("Well done!!!");
            Console.WriteLine($"You have completed another {duration} seconds of the Breathing activity.");
            this.ShowSpinner(3);
        }
        else
        {
            Console.WriteLine("Invalid duration! Returning to menu.");
            Thread.Sleep(2000);
        }
    }

    private void Start(int duration)
    {
        int totalTimeInSeconds = duration;

        while (totalTimeInSeconds > 0)
        {
            Console.Clear();

            Console.WriteLine("Breathing in...");
            this.ShowCountdown(3);

            Console.Clear();
            Console.WriteLine("Breathing out...");
            this.ShowCountdown(3);

            totalTimeInSeconds -= 6; // Each breathing cycle takes 6 seconds
        }
    }
}

