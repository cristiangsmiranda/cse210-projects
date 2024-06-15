using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        Console.Write("What is your grade? ");
        int grade = int.Parse(Console.ReadLine());

        string letter;
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        
        string sign = "";
        int last_digit = grade % 10;
        if(last_digit >= 7)
        {
            sign = "+";
        }
        else if(last_digit >= 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }
        if (grade >= 93)
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Stay focused and you will get it next time!");
        }
    }
}