// Word.cs
using System;
using System.Linq;

namespace ScriptureMasteryApp
{
  public class Word
  {
    private string _content;
    // Boolean flag for hidden state.
    public bool IsHidden { get; set; } = false;

    public Word(string content)
    {
      _content = content;
    }

    // Returns the content as-is if not hidden; otherwise returns underscores for letters.
    public string GetDisplayContent()
    {
      if (!IsHidden)
      {
        return _content;
      }
      else
      {
        char[] displayChars = _content.Select(c => char.IsLetter(c) ? '_' : c).ToArray();
        return new string(displayChars);
      }
    }
  }
}