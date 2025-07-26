// Activity.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    protected int _duration;
    public static Dictionary<string, int> ActivityLog = new Dictionary<string, int>();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}!");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nGood job! You completed {_duration} seconds of the {_name}!");
        ShowSpinner(3);
        LogActivity();
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private void LogActivity()
    {
        if (ActivityLog.ContainsKey(_name))
            ActivityLog[_name]++;
        else
            ActivityLog[_name] = 1;
    }

    public static void SaveLog(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in ActivityLog)
                sw.WriteLine($"{entry.Key}:{entry.Value}");
        }
    }

    public static void LoadLog(string filename)
    {
        if (File.Exists(filename))
        {
            ActivityLog.Clear();
            foreach (var line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                    ActivityLog[parts[0]] = count;
            }
        }
    }

    public int GetDuration() => _duration;

    public abstract void Run();
}
