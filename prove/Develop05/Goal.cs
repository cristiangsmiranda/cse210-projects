using System;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public abstract int RecordEvent();
    public virtual string GetStatus()
    {
        return IsComplete ? $"[X] {Name} ({Description})" : $"[ ] {Name} ({Description})";
    }

    public virtual void SetCompletion(bool isComplete)
    {
        IsComplete = isComplete;
    }
}
