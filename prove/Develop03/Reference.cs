using System;

namespace ScriptureMasterySharp
{
	public class Reference
	{
		// All attributes are private, using _camelCase naming convention.
		// Some attributes use ? to allow null values for optional reference portions.
		private string _book;
		private int _chapter;
		private int _startVerse;
		private int? _endVerse;
		private int? _addStartVerse;
		private int? _addEndVerse;

		public Reference(
			string book,
			int chapter,
			int startVerse,
			int? endVerse,
			int? addStartVerse,
			int? addEndVerse)
		{
			_book = book.Trim();
			_chapter = chapter;
			_startVerse = startVerse;
			_endVerse = endVerse;
			_addStartVerse = addStartVerse;
			_addEndVerse = addEndVerse;
		}

		// Returns the reference as a formatted string.
		// If the verse contains an additional segments, it's joined with a "&" character.
		public string GetReference()
		{
			string verseRange = _endVerse.HasValue
					? $"{_chapter}:{_startVerse}-{_endVerse.Value}"
					: $"{_chapter}:{_startVerse}";

			// If there's no additional range, return the verse range with the book.
			if (!_addStartVerse.HasValue)
				return $"{_book} {verseRange}";

			// Process the additional range.
			string additionalRange = _addEndVerse.HasValue
					? $"{_chapter}:{_addStartVerse.Value}-{_addEndVerse.Value}"
					: $"{_chapter}:{_addStartVerse.Value}";

			// Output lower verse first.
			if (_addStartVerse.Value < _startVerse)
				return $"{_book} {additionalRange} & {verseRange}";
			else
				return $"{_book} {verseRange} & {additionalRange}";
		}

		// Parses the reference from CSV fields.
		public static Reference ParseReference(string book, string chapterVerse)
		{
			if (string.IsNullOrWhiteSpace(book) || string.IsNullOrWhiteSpace(chapterVerse))
				throw new FormatException("Book and chapter:verse must not be empty.");

			book = book.Trim();
			chapterVerse = chapterVerse.Trim();

			// Split the chapter and verse on the ":".
			string[] parts = chapterVerse.Split(':');
			if (parts.Length != 2)
				throw new FormatException("Chapter:verse field is not in the correct format.");
			if (!int.TryParse(parts[0].Trim(), out int chapter))
				throw new FormatException("Invalid chapter number.");
			string versePart = parts[1].Trim();

			// Check if an "&" is present in the verse range set.
			if (versePart.Contains("&"))
			{
				// Parse the verse references separately, split on the "&" character.
				string[] segments = versePart.Split('&');
				if (segments.Length != 2)
					throw new FormatException("Invalid verse format with multiple ampersands.");

				(int startVerse, int? endVerse) = ParseVerseSegment(segments[0]);
				(int addStartVerse, int? addEndVerse) = ParseVerseSegment(segments[1]);

				return new Reference(book, chapter, startVerse, endVerse, addStartVerse, addEndVerse);
			}
			else
			{
				// No splitting necessary.
				(int startVerse, int? endVerse) = ParseVerseSegment(versePart);
				return new Reference(book, chapter, startVerse, endVerse, null, null);
			}
		}

		// This method parses verse range segments, and is separated for readability.
		private static (int start, int? end) ParseVerseSegment(string segment)
		{
			segment = segment.Trim();
			if (segment.Contains("-"))
			{
				// A range is provided.
				string[] rangeParts = segment.Split('-');
				if (rangeParts.Length != 2 ||
						!int.TryParse(rangeParts[0].Trim(), out int start) ||
						!int.TryParse(rangeParts[1].Trim(), out int end))
				{
					throw new FormatException("Invalid verse range.");
				}
				return (start, end);
			}
			else
			{
				// No range delimiter; treat as a single verse.
				if (!int.TryParse(segment, out int verse))
					throw new FormatException("Invalid verse number.");
				return (verse, null);
			}
		}
	}
}
