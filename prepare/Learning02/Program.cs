using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");


        Job Job1 = new Job();
        Job1._company = "Disney";
        Job1._jobTitle = "Software Engineer";
        Job1._startYear = 2028;
        Job1._endYear = 2035;

        Job Job2 = new Job();
        Job2._company = "Microsoft";
        Job2._jobTitle = "Software Engineer";
        Job2._startYear = 2035;
        Job2._endYear = 2048;

        Resume myresume = new Resume();
        myresume._name = "Cristian Miranda";

        myresume._Jobs.Add(Job1);
        myresume._Jobs.Add(Job2);

        myresume.DisplayResumeDetails();

    }
}