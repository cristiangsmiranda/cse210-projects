using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

        string again = "yes";
        while (again == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);
            int guess = 0;
            int attempts = 0;
            while (guess != number)
            {
                Console.WriteLine("What is your guess between 1 and 100: ");
                guess = int.Parse(Console.ReadLine());
                attempts = attempts + 1;
                if (guess > number)
                {
                    Console.WriteLine($"Smaller!");
                }
                else if (guess < number)
                {
                    Console.WriteLine($"Higher");
                }
            }

            Console.WriteLine($"You got it right. Congratulations");
            Console.WriteLine($"The number of attempts was: {attempts} ");

            Console.Write("Do you want to continue? ");
            again = Console.ReadLine();
        }    
    }
}