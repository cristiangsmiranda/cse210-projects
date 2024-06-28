// as a point of creativity I created a new class called restoration and stored it in another.cs file
// this class has the function of restoring the game, so that if the user feels they can't memorize it yet,
// they can go back to the beginning and start again using the "r" key plus "Enter".


using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("2 Nephi", 31, 10, 10);
        Scripture scripture = new Scripture(reference, "And he said unto the children of men: Follow thou me. Wherefore, my beloved brethren, can we follow Jesus save we shall be willing to keep the commandments of the Father?");

        Random random = new Random();
        Restoration restoration = new Restoration(scripture.GetWords());

        string input;

        do
        {
            DisplayScripture(scripture);

            input = Console.ReadLine();
            if (input != null && input.ToLower() == "quit")
                return;
            else if (input != null && input.ToLower() == "r")
            {
                restoration.RestoreAllWords();
                // Reset the scripture to show all words
                scripture.ResetWords();
                // Pause before restarting the loop
                Console.ReadLine();
            }
            else
            {
                // Hide random words when Enter is pressed
                HideRandomWords(scripture, random, 2, 3);
            }

        } while (!AllWordsHidden(scripture));

        // Display the fully hidden scripture one last time
        DisplayScripture(scripture);

        Console.ReadLine(); // Wait for the Enter key to exit
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.Reference);
        foreach (var word in scripture.GetWords())
        {
            Console.Write(word.IsHidden ? new string('_', word.Text.Length) + " " : word.Text + " ");
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue, type 'quit' to finish, or press 'r' + Enter to reveal all hidden words and restart:");
    }

    static void HideRandomWords(Scripture scripture, Random random, int minWords, int maxWords)
    {
        List<Word> words = scripture.GetWords();
        List<int> visibleWordsIndices = new List<int>();

        // Get indices of visible words
        for (int i = 0; i < words.Count; i++)
        {
            if (!words[i].IsHidden)
            {
                visibleWordsIndices.Add(i);
            }
        }

        if (visibleWordsIndices.Count > 0)
        {
            int wordsToHide = random.Next(minWords, Math.Min(maxWords, visibleWordsIndices.Count) + 1);

            for (int i = 0; i < wordsToHide; i++)
            {
                int index = visibleWordsIndices[random.Next(visibleWordsIndices.Count)];
                words[index].Hide();
                visibleWordsIndices.Remove(index);
            }
        }
    }

    static bool AllWordsHidden(Scripture scripture)
    {
        foreach (var word in scripture.GetWords())
        {
            if (!word.IsHidden)
                return false;
        }
        return true;
    }
}

public class Scripture
{
    public Reference Reference { get; }
    private string Text { get; }
    private List<Word> _words;
    private List<Word> _originalWords; // Store original state of words

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Text = text;
        _words = InitializeWords(text);
        _originalWords = new List<Word>(_words); // Store a copy of original words
    }

    private List<Word> InitializeWords(string text)
    {
        List<Word> words = new List<Word>();
        string[] tokens = text.Split(" ");
        foreach (var token in tokens)
        {
            words.Add(new Word(token));
        }
        return words;
    }

    public List<Word> GetWords()
    {
        return _words;
    }

    public void ResetWords()
    {
        // Reset words to original state
        _words = new List<Word>(_originalWords);
    }
}

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_startVerse == _endVerse)
            return $"{_book} {_chapter}: {_startVerse}";
        else
            return $"{_book} {_chapter}: {_startVerse}-{_endVerse}";
    }
}

public class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Restore()
    {
        IsHidden = false;
    }
}
