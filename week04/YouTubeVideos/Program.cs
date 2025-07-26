using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("How to Make Pasta", "Chef Mario", 300);
        var video2 = new Video("10-Minute Home Workout", "FitLife", 600);
        var video3 = new Video("Top 5 Travel Destinations", "TravelWithMe", 480);
        var video4 = new Video("Understanding C# Classes", "CodeMaster", 540);

        // Add comments
        video1.AddComment(new Comment("Anna", "This made me hungry! 🍝"));
        video1.AddComment(new Comment("Luis", "Thanks for the easy recipe."));
        video1.AddComment(new Comment("Marta", "Love your cooking style!"));

        video2.AddComment(new Comment("James", "I'm sweating already 😅"));
        video2.AddComment(new Comment("Sara", "Perfect morning routine!"));
        video2.AddComment(new Comment("Kyle", "Simple and effective."));

        video3.AddComment(new Comment("Nina", "I've been to #3! Loved it."));
        video3.AddComment(new Comment("Paul", "Adding these to my bucket list."));
        video3.AddComment(new Comment("Lea", "Thanks for the travel inspo! ✈️"));

        video4.AddComment(new Comment("Jake", "So helpful for my assignment!"));
        video4.AddComment(new Comment("Emily", "Finally understood abstraction!"));
        video4.AddComment(new Comment("Ravi", "Your teaching is great!"));

        // Store in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display all video info
        foreach (Video vid in videos)
        {
            vid.DisplayVideoInfo();
        }
    }
}
