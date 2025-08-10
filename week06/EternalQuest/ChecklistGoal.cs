using System;

public class ChecklistGoal : Goal
{
    private int _amountComplete;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountComplete = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountComplete = amountComplete;
    }

    public override void RecordEvent(ref int score)
    {
        _amountComplete++;
        score += Points;

        if (_amountComplete == _target)
        {
            score += _bonus;
            Console.WriteLine($"Goal completed! Bonus {_bonus} points awarded.");
            Trophy();
        }
        else
        {
            Console.WriteLine($"Progress recorded! {_amountComplete}/{_target} complete.");
        }
    }

    public override bool IsComplete() => _amountComplete >= _target;

    public override string GetDetailsString()
    {
        return $"{ShortName} ({Description}) -- Currently completed {_amountComplete}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName}|{Description}|{Points}|{_target}|{_bonus}|{_amountComplete}";
    }

    private void Trophy()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
    🏆🏆🏆  TROPHY UNLOCKED!  🏆🏆🏆
        ");
        Console.ResetColor();
    }

}
