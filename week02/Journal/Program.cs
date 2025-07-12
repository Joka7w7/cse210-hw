/*
Showing Creativity and Exceeding Requirements:
1. Mood Tracking: The user is prompted to record their mood (e.g., Happy, Anxious), helps users reflect emotionally and be more self-aware.
2. Tag/Keyword: User can assign a tag to each entry (e.g., "work", "spiritual"), enables future search, filtering, or organization of entries.
3. Word Count:Program calculates and saves the number of words in the user’s response, helps motivate better reflection and deeper journaling.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("How would you describe your mood today (e.g., Happy, Sad, Anxious)? ");
                    string mood = Console.ReadLine();

                    Console.Write("Enter a tag or keyword for this entry (e.g., work, family, school): ");
                    string tag = Console.ReadLine();

                    journal.AddEntry(new Entry(prompt, response, mood, tag));
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
