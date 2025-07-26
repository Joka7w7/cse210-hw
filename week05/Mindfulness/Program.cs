// Program.cs
// This program provides a mindfulness app with Breathing, Reflection, and Listing activities.
// Exceeds requirements by logging activity use and saving it to file.

using System;

class Program
{
    static void Main(string[] args)
    {
        string logFile = "activity_log.txt";
        Activity.LoadLog(logFile);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();
            Activity activity = null;

            switch (input)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Activity Log:");
                    foreach (var entry in Activity.ActivityLog)
                        Console.WriteLine($"{entry.Key}: {entry.Value} times");
                    Console.WriteLine("\nPress Enter to return to menu.");
                    Console.ReadLine();
                    continue;
                case "5":
                    Activity.SaveLog(logFile);
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity?.Run();
        }
    }
}
