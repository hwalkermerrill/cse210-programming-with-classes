using System;
using System.Collections.Generic;

namespace RickRollAbstraction
{
	public class Video
	{
		// attributes here, following _camelCase naming convention
		private string _title;
		private string _author;
		private int _lengthSeconds;
		private List<Comment> _comments = new List<Comment>();

		// constructor here
		public Video(string title, string author, int lengthSeconds)
		{
			_title = title;
			_author = author;
			_lengthSeconds = lengthSeconds;
		}

		// getters here
		public string GetTitle()
		{
			return _title;
		}

		public string GetAuthor()
		{
			return _author;
		}

		public int GetLength()
		{
			return _lengthSeconds;
		}

		public List<Comment> GetComments()
		{
			return _comments;
		}

		public int CountComments()
		{
			return _comments.Count;
		}

		// methods here
		public void AddComment(Comment comment)
		{
			_comments.Add(comment);
		}
	}
}