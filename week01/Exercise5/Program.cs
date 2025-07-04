using System;

class Program
{
    static void Main(string[] args)
    {
        bool continueRunning = true;

        while (continueRunning)
        {
            DisplayWelcomeMessage();

            string userName = PromptUserName();
            int userNumber = PromptUserNumber();
            string operation = PromptOperation(); // square or cube?

            int result = 0;
            if (operation == "square")
            {
                result = SquareNumber(userNumber);
            }
            else if (operation == "cube")
            {
                result = CubeNumber(userNumber);
            }

            DisplayResult(userName, userNumber, result, operation);

            continueRunning = AskToRunAgain();
        }

        Console.WriteLine("Thanks for using the program. Goodbye!");
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("\nWelcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        int number;
        while (true)
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        return number;
    }

    static string PromptOperation()
    {
        Console.Write("Would you like to square or cube the number? (square/cube): ");
        string choice = Console.ReadLine().ToLower();

        while (choice != "square" && choice != "cube")
        {
            Console.Write("Please enter 'square' or 'cube': ");
            choice = Console.ReadLine().ToLower();
        }

        return choice;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static int CubeNumber(int number)
    {
        return number * number * number;
    }

    static void DisplayResult(string name, int original, int result, string operation)
    {
        Console.WriteLine($"{name}, the {operation} of your number {original} is {result}.");
    }

    static bool AskToRunAgain()
    {
        Console.Write("\nWould you like to try again? (yes/no): ");
        string response = Console.ReadLine().ToLower();
        return response == "yes";
    }
}
