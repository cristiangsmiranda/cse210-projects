using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;
        int total = 0;
        int average = 0;
        int largest = int.MinValue;
        int smallest = int.MaxValue;

        Console.WriteLine("Please enter a list of numbers, type 0 when finished: ");

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        foreach (int num in numbers)
        {
            Console.WriteLine(num);
            total += num;
            if(largest < num)
            {
                largest = num;
            }
            if (num > 0 && smallest > num)
            {
                smallest = num;
            }
        }

        Console.WriteLine($"The sum is: {total}");
        if (numbers.Count > 0)
        {
            average = total / numbers.Count;
        }
        Console.WriteLine($"The average is: {average} ");
        Console.WriteLine($"The largest number is: {largest} ");
        Console.WriteLine($"The smallest number is: {smallest} ");
        numbers.Sort();
        Console.WriteLine($"The sorted list is: ");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}