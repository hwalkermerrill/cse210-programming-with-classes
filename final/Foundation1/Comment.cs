using System;

namespace RickRollAbstraction
{
	public class Comment
	{
		// attributes here, following _camelCase naming convention
		private string _commenterName;
		private string _commentText;

		// constructor here
		public Comment(string commenterName, string commentText)
		{
			_commenterName = commenterName;
			_commentText = commentText;
		}

		// getters here
		public string GetCommenterName() { return _commenterName; }
		public string GetCommentText() { return _commentText; }
	}
}