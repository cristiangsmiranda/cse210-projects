public partial class Program
{
    private static void RecordEvent()
    {
        Console.Clear();
        ListGoals();
        Console.WriteLine("Enter the goal number to record an event: ");
        int goalNumber;
        if (int.TryParse(Console.ReadLine(), out goalNumber))
        {
            if (goalNumber > 0 && goalNumber <= goals.Count)
            {
                score += goals[goalNumber - 1].RecordEvent();
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        Console.ReadLine();
    }
}
