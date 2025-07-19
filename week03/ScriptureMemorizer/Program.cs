/* Added exceeding requirements
1. Feauture to let the program know how many words per round should hide, based on user input.
2. The scriptures are load from a Library of txt as a file, randomly.
*/
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<(Reference, string)> scriptureLibrary = ScriptureLoader.LoadFromFile("scriptures.txt");

        if (scriptureLibrary.Count == 0)
        {
            Console.WriteLine("No scriptures found.");
            return;
        }

        var rnd = new Random();
        var (reference, text) = scriptureLibrary[rnd.Next(scriptureLibrary.Count)];
        var scripture = new Scripture(reference, text);

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("How many words would you like to hide per round? (e.g., 3): ");
        int hideCount = int.TryParse(Console.ReadLine(), out int result) ? result : 3;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter to continue, type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
                break;

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are now hidden. Great job!");
                break;
            }

            scripture.HideRandomWords(hideCount);
        }
    }
}

