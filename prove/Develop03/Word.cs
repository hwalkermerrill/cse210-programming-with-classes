using System;
using System.Linq;

namespace ScriptureMasterySharp
{
	public class Word
	{
		// All attributes are private, using _camelCase naming convention.
		private string _content;
		private bool _isHidden;

		public Word(string content)
		{
			_content = content;
			_isHidden = false;
		}
		public void Hide()
		{
			_isHidden = true;
		}
		public bool IsHidden()
		{
			return _isHidden;
		}
		// Returns the original word if it's not hidden,
		// otherwise returns a version with letters replaced by underscores.
		public string GetDisplayContent()
		{
			if (!_isHidden)
				return _content;
			else
				return new string(_content.Select(c => char.IsLetter(c) ? '_' : c).ToArray());
		}
	}
}