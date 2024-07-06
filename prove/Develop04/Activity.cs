using System;
using System.Threading;

public abstract class Activity
{
    public void ShowSpinner(int durationInSeconds)
    {
        int delay = 500;
        string[] spinner = { "/", "-", "\\", "|" };
        int loops = durationInSeconds * 1000 / delay;

        for (int i = 0; i < loops; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            System.Threading.Thread.Sleep(delay);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }

    public void ShowCountdown(int durationInSeconds)
    {
        for (int i = durationInSeconds; i > 0; i--)
        {
            Console.Write($"\rTime left: {i} seconds");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void StartTheActivity();
}
