/*
===========================================================
Eternal Quest Program - Deluxe Edition
Extra Features Implemented:
Leveling System:Players level up every 500 points.- Levels are displayed alongside the score. Titles Based on Level: - Level 1-2: Apprentice- Level 3-4: Knight- Level 5-7: Champion
    - Level 8+: Ninja Unicorn 🦄
Colorful Interface:- Different colors for menus, celebrations, and trophies.- Level and title displayed in bright colors.
ASCII Trophy Celebrations:- Special ASCII art and bright colors when completing goals.- Unique messages for Simple, Eternal, and Checklist goals.
===========================================================
*/

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "🌟 Eternal Quest Deluxe Edition 🌟";
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
