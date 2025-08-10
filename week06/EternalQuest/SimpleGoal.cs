using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent(ref int score)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            score += Points;
            Console.WriteLine($"Congrats! You earned {Points} points.");
            Celebration();
        }
        else
        {
            Console.WriteLine("This goal is already complete!");
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName}|{Description}|{Points}|{_isComplete}";
    }

    private void Celebration()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"
    ★彡  🎉  YOU DID IT!  🎉  彡★
        ");
        Console.ResetColor();
    }

}
