// As a point of creativity, I decided to create a new game option that allows the user to
// exercise gratitude in their daily lives, so the logic of the game follows pretty much the same pattern,
// but initially you're given motivational phrases to think about and then some phrases of gratitude appear
// and it gradually changes so that the user always has in mind many reasons to be grateful

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing activity");
            Console.WriteLine("2. Start Reflection activity");
            Console.WriteLine("3. Start Listing activity");
            Console.WriteLine("4. Start Gratetude activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new Breathing().StartTheActivity();
                    break;
                case "2":
                    new Reflection().StartTheActivity();
                    break;
                case "3":
                    new Listing().StartTheActivity();
                    break;
                case "4":
                    new Gratitude().StartTheActivity();
                    break;
                case "5":
                    Console.WriteLine("Leaving.");
                    return;
                default:
                    Console.WriteLine("Invalid option! Try again.");
                    Thread.Sleep(3000);
                    break;
            }
        }
    }
}
