
using System.Collections.Generic;
using System.IO;

public static class ScriptureLoader
{
    public static List<(Reference, string)> LoadFromFile(string path)
    {

        var scriptures = new List<(Reference, string)>();

        if (!File.Exists(path))
            return scriptures;

        foreach (var line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line) || !line.Contains("|")) continue;

            var parts = line.Split('|');
            if (parts.Length != 2) continue;

            var referenceText = parts[0];
            var text = parts[1];

            var refParts = referenceText.Split(' ');
            var book = refParts[0];
            var chapterVerse = refParts[1].Split(':');
            var chapter = int.Parse(chapterVerse[0]);

            Reference reference;
            if (chapterVerse[1].Contains("-"))
            {
                var verses = chapterVerse[1].Split('-');
                reference = new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
            }
            else
            {
                reference = new Reference(book, chapter, int.Parse(chapterVerse[1]));
            }

            scriptures.Add((reference, text));
        }

        return scriptures;
    }
}
