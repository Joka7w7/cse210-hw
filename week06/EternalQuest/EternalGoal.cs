using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent(ref int score)
    {
        score += Points;
        Console.WriteLine($"Well done! You earned {Points} points.");
        Celebration();
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{ShortName}|{Description}|{Points}";
    }

    private void Celebration()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
    ★彡  🌟  KEEP GOING!  🌟  彡★
        ");
        Console.ResetColor();
    }

}
