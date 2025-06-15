using System;

namespace ScriptureMasterySharp
{
	public class Reference
	{
		// All attributes are private, using _camelCase naming convention.
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

		// Returns the reference as a formatted string.
		public string GetReference()
		{
			if (_startVerse == _endVerse)
				return $"{_book} {_chapter}:{_startVerse}";
			else
				return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
		}

		// Parses reference from CSV fields.
		// Includes exceptions for invalid formats.
		public static Reference ParseReference(string book, string chapterVerse)
		{
			if (string.IsNullOrWhiteSpace(book) || string.IsNullOrWhiteSpace(chapterVerse))
			{
				throw new FormatException("Book and chapter:verse must not be empty.");
			}

			book = book.Trim();
			chapterVerse = chapterVerse.Trim();

			// Split the chapter and verse(s) by the colon.
			string[] parts = chapterVerse.Split(':');
			if (parts.Length != 2)
			{
				throw new FormatException("Chapter:verse field is not in the correct format.");
			}
			if (!int.TryParse(parts[0].Trim(), out int chapter))
			{
				throw new FormatException("Invalid chapter number.");
			}

			// Process the verse range.
			string versePart = parts[1].Trim();
			int startVerse, endVerse;
			if (versePart.Contains("-"))
			{
				string[] verses = versePart.Split('-');
				if (verses.Length != 2 ||
						!int.TryParse(verses[0].Trim(), out startVerse) ||
						!int.TryParse(verses[1].Trim(), out endVerse))
				{
					throw new FormatException("Invalid verse range.");
				}
			}
			else
			{
				if (!int.TryParse(versePart, out startVerse))
				{
					throw new FormatException("Invalid verse number.");
				}
				endVerse = startVerse;
			}

			// Saves information as a new reference object.
			return new Reference(book, chapter, startVerse, endVerse);
		}
	}
}