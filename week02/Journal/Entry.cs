public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }
    public string Tag { get; set; }
    public int WordCount { get; set; }

    public Entry(string prompt, string response, string mood, string tag)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
        Mood = mood;
        Tag = tag;
        WordCount = CountWords(response);
    }

    public override string ToString()
    {
        return $"Date: {Date}\nMood: {Mood}\nTag: {Tag}\nWord Count: {WordCount}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Mood}|{Tag}|{WordCount}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        return new Entry(parts[4], parts[5], parts[1], parts[2])
        {
            Date = parts[0],
            WordCount = int.Parse(parts[3])
        };
    }

    private static int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}


