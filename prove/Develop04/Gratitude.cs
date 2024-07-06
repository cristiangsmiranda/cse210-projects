using System;
using System.Collections.Generic;
using System.Threading;

public class Gratitude : Activity
{
    private static readonly string[] Prompts = new string[]
    {
        "Remember that every day is a new opportunity!",
        "Remember those people who really love you because they know who you are!",
        "Remember that there is a Heavenly Father who wants you by his side and loves you unconditionally!",
        "Remember that even though you can't choose the consequences, you can make every day a new opportunity!",
        "Remember your childhood and who you are becoming!",
        "Remember that serving others is serving God!"
    };

    private static readonly string[] Grateful = new string[]
    {
        "Thank you for another day",
        "I am grateful for my health",
        "I am grateful for my family",
        "I am grateful for the friends I have",
        "I'm grateful for my job",
        "I'm grateful for the food on the table",
        "I'm grateful for the love I receive",
        "I'm grateful for the opportunity to learn",
        "I'm grateful for being able to help others",
        "I'm grateful for the nature around me",
        "I'm grateful for the little things",
        "I am grateful for peace and tranquillity",
        "I'm grateful for every new beginning",
        "I'm grateful for music that inspires me",
        "I am grateful for moments of joy",
        "I am grateful for the comfort of my home",
        "I am grateful for the lessons I learn",
        "I'm grateful for the sun that shines",
        "I am grateful for the rain that falls",
        "I am grateful to be alive today"
    };

    public override void StartTheActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the Gratitude activity!");
        Console.WriteLine();
        string description = "This activity will help you reflect on the things we should be grateful for but often forget, making you think of some reasons why it's important to be grateful.";
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
            Console.WriteLine($"You have completed another {duration} seconds of the Gratitude activity.");
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

        int totalTimeInSeconds = duration;
        int gratefulIndex = 0;

        while (totalTimeInSeconds > 0 && gratefulIndex < Grateful.Length)
        {
            Console.Clear();
            Random random1 = new Random();
            string grateful = Grateful[random.Next(Grateful.Length)];
            Console.WriteLine(Grateful[gratefulIndex]);
            this.ShowSpinner(5);
            totalTimeInSeconds -= 5;
            gratefulIndex++;
        }
    }
}
