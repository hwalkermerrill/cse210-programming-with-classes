// Word.cs
using System;
using System.Linq;

namespace ScriptureMasterySharp
{
	public class Word
	{
		// _attributes here are private and following _camelCase convention.
		private string _content;
		private bool _isHidden;

		public Word(string content)
		{
			_content = content;
			_isHidden = false; // Starts visible
		}

		// Returns each word as is, or as letters replaced with underscores if hidden.
		public string GetDisplayContent()
		{
			if (!_isHidden)
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