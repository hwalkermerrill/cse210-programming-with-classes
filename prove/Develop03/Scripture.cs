// Scripture.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMasterySharp
{
	public class Scripture
	{
		// _attributes here, following _camelCase convention.
		private string _text;
		public List<Word> _words { get; private set; } = new List<Word>();

		// Constructor receives the verse text.
		public Scripture(string text)
		{
			_text = text;
			ParseWords();
		}

		// Splits the verse into Word objects on spaces.
		private void ParseWords()
		{
			string[] splitWords = _text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			foreach (string word in splitWords)
			{
				_words.Add(new Word(word));
			}
		}

		// Returns the verse's text for display, with hidden words replaced by underscores.
		public string GetDisplayText()
		{
			return string.Join(" ", _words.Select(w => w.GetDisplayContent()));
		}
	}
}