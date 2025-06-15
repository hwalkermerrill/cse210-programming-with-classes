using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMasterySharp
{
	public class Scripture
	{
		// All attributes are private, using _camelCase naming convention.
		private Reference _reference;
		private List<Word> _words;

		public Scripture(Reference reference, string scriptureText)
		{
			_reference = reference;
			_words = new List<Word>();
			ParseWords(scriptureText);
		}

		// Splits the text into Word objects.
		private void ParseWords(string scriptureText)
		{
			string[] tokens = scriptureText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			foreach (string token in tokens)
			{
				_words.Add(new Word(token));
			}
		}

		//Combines the reference and displayed words into one string.
		public string GetDisplayText()
		{
			string wordsText = string.Join(" ", _words.Select(word => word.GetDisplayContent()));
			return _reference.GetReference() + "\n" + wordsText;

		}

		// Hides one random visible word.
		public void HideRandomWord()
		{
			var visibleWords = _words.Where(word => !word.IsHidden()).ToList();
			if (visibleWords.Any())
			{
				Random rand = new Random();
				int index = rand.Next(visibleWords.Count);
				visibleWords[index].Hide();
			}
		}

		// Returns true if all words have been hidden.
		public bool AllWordsHidden()
		{
			return _words.All(word => word.IsHidden());
		}
	}
}