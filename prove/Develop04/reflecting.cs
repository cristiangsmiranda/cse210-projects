using System;
using System.Threading;

public class Reflection : Activity
{
    private static readonly string[] Prompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void StartTheActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Reflection activity!");
        Console.WriteLine();
        string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
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
            Console.WriteLine($"You have completed another {duration} seconds of the Reflection activity.");
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
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        this.ShowCountdown(5);

        int totalTimeInSeconds = duration;
        int questionIndex = 0;

        while (totalTimeInSeconds > 0 && questionIndex < Questions.Length)
        {
            Console.Clear();
            Console.WriteLine(Questions[questionIndex]);
            this.ShowSpinner(5);
            totalTimeInSeconds -= 5;
            questionIndex++;    
        }
    }
}
