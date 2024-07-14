public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            CurrentCount++;
            if (CurrentCount >= TargetCount)
            {
                IsComplete = true;
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        if (IsComplete)
            return $"[X] {Name} (Completed {CurrentCount}/{TargetCount} times) ({Description})";
        else
            return $"[ ] {Name} (Completed {CurrentCount}/{TargetCount} times) ({Description})";
    }

    public override void SetCompletion(bool isComplete)
    {
        base.SetCompletion(isComplete);
        if (isComplete)
        {
            CurrentCount = TargetCount; // Set CurrentCount to TargetCount when completed
        }
    }
}
