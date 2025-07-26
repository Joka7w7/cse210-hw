// ListingActivity.cs
using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public override void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---");

        Console.WriteLine("\nYou may begin in:");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        List<string> responses = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                responses.Add(input);
            }
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
        DisplayEndingMessage();
    }
}
