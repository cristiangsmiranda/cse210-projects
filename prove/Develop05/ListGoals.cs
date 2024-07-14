public partial class Program
{
    private static void ListGoals()
    {
        Console.Clear();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
        }
        else
        {
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
            }
        }
        Console.ReadLine();
    }
}
