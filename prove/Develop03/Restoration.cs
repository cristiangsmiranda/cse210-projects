using System.Collections.Generic;

public class Restoration
{
    private List<Word> _hiddenWords;

    public Restoration(List<Word> hiddenWords)
    {
        _hiddenWords = hiddenWords;
    }

    public void RestoreAllWords()
    {
        foreach (var word in _hiddenWords)
        {
            word.Restore();
        }
    }
}
