// Word.cs
using System;
using System.Linq;

namespace ScriptureMasterySharp
{
	public class Word
	{
		// _attributes here, following _camelCase convention.
		private string _content;
		// Boolean flag for hidden state.
		public bool _isHidden { get; set; } = false;

		public Word(string content)
		{
			_content = content;
		}

		// Returns the as is, or as letters replaced with underscores if hidden.
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