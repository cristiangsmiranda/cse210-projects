using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");

        
        DisplayWelcome();
                
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        
        Console.Write("Please enter your favorite number: ");
        int FavoriteNumber = int.Parse(Console.ReadLine());
        int squareNumber = SquareNumber(FavoriteNumber);

        DisplayResult(userName, squareNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }    
    static int SquareNumber(int number)
        {
            int sum = number * number;
            return sum;
        }

        static void DisplayResult(string userName, int squareNumber)
        {
            Console.WriteLine($"{userName}, the square of your number is {squareNumber}");
        }
    }



