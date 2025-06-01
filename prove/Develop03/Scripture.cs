// Scripture.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMasterySharp
{
	public class Scripture
	{
		private string _text;
		// Expose the Words so that Program.cs can update hidden state.
		public List<Word> Words { get; private set; } = new List<Word>();

		// Constructor receives the verse text.
		public Scripture(string text)
		{
			_text = text;
			ParseWords();
		}

		// Splits the verse into words (naively on space), producing Word objects.
		private void ParseWords()
		{
			string[] splitWords = _text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			foreach (string word in splitWords)
			{
				Words.Add(new Word(word));
			}
		}

		// Returns the verse's text for display—with hidden words replaced by underscores.
		public string GetDisplayText()
		{
			return string.Join(" ", Words.Select(w => w.GetDisplayContent()));
		}
	}
}