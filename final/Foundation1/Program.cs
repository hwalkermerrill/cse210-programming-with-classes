using System;
using System.Collections.Generic;
using System.Diagnostics;


// Exceeds requirements: Not only does this program satisfy the requirements of the task regarding holding the
// videos and comments, and not only did I use real comments and videos, but I also added a menu system and a
// way to open the videos in a web browser. Also, while we did not share code with each other, Michael Loftus
// and I did agree we would both use one of the same videos, and we looked up how to open a video in a web 
// browser together in class, so if your wondering why there may be some similarity (I don't know what his code
// looks like or if he chickened out of the joke), that is why. I also did double the required number of videos.
namespace RickRollAbstraction
{
	public class Program
	{
		public static void Main(string[] args)
		{
			List<Video> videos = InitializeVideos();
			bool exit = false;

			while (!exit)
			{
				Console.Clear();
				Console.WriteLine("🎬 Welcome to Harrison's CSE210 YouTube Music Library!");
				Console.WriteLine("Choose a video to explore and listen to:");
				Console.WriteLine("  1. Diggy Diggy Hole");
				Console.WriteLine("  2. Keyboard Cat! - The Original");
				Console.WriteLine("  3. Greatest Hits of the 80's");
				Console.WriteLine("  4. The Workers Song Community Project");
				Console.WriteLine("  5. Malcolm in the Middle - Candyman");
				Console.WriteLine("  6. How I Met Your Mother: For The Longest Time");
				Console.WriteLine("  7. Quit");
				Console.Write("Select (1-7): ");

				string choice = Console.ReadLine().Trim();
				switch (choice)
				{
					case "1":
					case "2":
					case "3":
					case "4":
					case "5":
					case "6":
						int index = int.Parse(choice) - 1;
						DisplayVideoDetails(videos[index]);
						PlayVideo(choice, videos[index]);
						break;
					case "7":
						exit = true;
						Console.WriteLine("One day you'll realize these songs are in your head forever, rent free. Have a good day!");
						break;
					default:
						Console.WriteLine("You want songs?!? No song for you! On second thought, try again.");
						Pause();
						break;
				}
			}
		}

		static List<Video> InitializeVideos()
		{
			var list = new List<Video>();

			var video1 = new Video("Diggy Diggy Hole", "The Yogscast", 248);
			video1.AddComment(new Comment("@biv_ky", "Born too early to explore the heavens \n Born too far underground to see the glimmer of sunlight \n <b>Born just in time to Diggy Diggy hole</b>"));
			video1.AddComment(new Comment("@saberzane8955", "Came back here from the Wind Rose Cover! Nostalgia is flowing out me eyes"));
			video1.AddComment(new Comment("@Cynidecia", "Elves been real quiet since this dropped."));
			video1.AddComment(new Comment("@NikSwiftDigs", "I am a professional archaeologist. I've lost count of how often I play this on my phone when I'm on an excavation. It genuinely helps with the digging!"));
			list.Add(video1);

			var video2 = new Video("Keyboard Cat! - The Original", "Keyboard Cat!", 54);
			video2.AddComment(new Comment("@triple_trash_bucket6169", "This is literally one of the ancient fragments of the internet"));
			video2.AddComment(new Comment("@breadmold3545", "This video is like wine; the older it is, the better it gets."));
			video2.AddComment(new Comment("@perrytheplatypus42", "YouTube eeds to add an 'Oldest First' option for comments"));
			video2.AddComment(new Comment("@iitzJustKoda", "Me: Scrolls gently down my recommendations \n Youtube: Comes out a dark alleyway and shoots me with a nostalgia gun"));
			list.Add(video2);

			var video3 = new Video("Greatest Hits of the 80's", "Totally Real Records", 213);
			video3.AddComment(new Comment("@YouTube", "can confirm: he never gave us up"));
			video3.AddComment(new Comment("@LK-ht7qz", "Let's put the meme aside, this is actually a banging song."));
			video3.AddComment(new Comment("@SonimodGT", "Petition to make this the national anthem of the internet"));
			list.Add(video3);

			var video4 = new Video("The Workers Song Community Project", "The Longest Johns", 197);
			video4.AddComment(new Comment("@thelongestjohns", "We are now taking submissions for our next community project for the song, Here’s a Health to the Company. Instructions for how to take part can be found here… https://youtu.be/mQJtgIvY_14"));
			video4.AddComment(new Comment("@ChrisJones-qw7bn", "As a guy who has spent a Lifetime doing the backbreaking labors no one else wanted to do. For LONG Days and HARD working conditions. I am so MOVED by this project I can't help but shed a few tears.  THANK YOU SO MUCH!!! And for all my Brothers and Sisters Still out there pushing HARD. And for all the brethren I have lost to time and conditions....THANK YOU!! You ARE appreciated!!"));
			video4.AddComment(new Comment("@johnny--guitar", "I love that there's a few shots of teachers and restaurant staff and retail workers. Modern labor isn't just the factoryman anymore and we all deserve a better world."));
			list.Add(video4);

			var video5 = new Video("Malcolm in the Middle - Candyman", "yy8717", 72);
			video5.AddComment(new Comment("@Mlogan11", "The Francis sub plots in military school and Alaska were separate shows themselves. MiM were two shows that ran together."));
			video5.AddComment(new Comment("@samjadragon", "I love how everyone in Malcolm's family is super talented but their dysfunctional personalities make it hard to see"));
			video5.AddComment(new Comment("@thewarnerchannel7285", "I love how he gets on their case when they're actually perfect, and then dryly sing talks 'You can even eat THE DISHES!'"));
			list.Add(video5);

			var video6 = new Video("How I Met Your Mother: For The Longest Time", "NarutoJoeyYugi", 49);
			video6.AddComment(new Comment("@Idiodyssey87", "Can't wait to clone myself twice... only to remember that none of me can sing. "));
			video6.AddComment(new Comment("@mysti_fay", "it's so beautiful but makes me sad at the same time... after all this was just Ted's imagination, the whole episode was. ah the melancholy"));
			video6.AddComment(new Comment("@FairyBubblePuppy", "'I've been waiting twenty years for this.' I suppose you could say he'd been waiting... for the longest time."));
			list.Add(video6);

			return list;
		}

		static void DisplayVideoDetails(Video video)
		{
			Console.Clear();
			Console.WriteLine($"Title: {video.GetTitle()}");
			Console.WriteLine($"Author: {video.GetAuthor()}");
			Console.WriteLine($"Length: {video.GetLength()} seconds");
			Console.WriteLine($"Comments ({video.CountComments()}):");
			foreach (Comment comment in video.GetComments())
			{
				Console.WriteLine($" - {comment.GetCommenterName()}: {comment.GetCommentText()}");
			}
			Console.WriteLine();
		}

		static void PlayVideo(string choice, Video video)
		{
			Console.WriteLine($"Would you like to play this {video.GetLength()} second video?");
			Console.WriteLine("  1. Yes");
			Console.WriteLine("  2. No");
			Console.Write("Select: ");

			string response = Console.ReadLine().Trim();
			if (response == "1")
			{
				string url = "";

				switch (choice)
				{
					case "1":
						url = "https://www.youtube.com/watch?v=ytWz0qVvBZ0&list=RDytWz0qVvBZ0&start_radio=1&ab_channel=TheYogscast";
						break;
					case "2":
						url = "https://www.youtube.com/watch?v=J---aiyznGQ";
						break;
					case "3":
						url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
						break;
					case "4":
						url = "https://www.youtube.com/watch?v=GSKeECZ7Cew&list=RDGSKeECZ7Cew&start_radio=1&ab_channel=TheLongestJohns";
						break;
					case "5":
						url = "https://www.youtube.com/watch?v=2ySxSSzJKd0&ab_channel=yy8717";
						break;
					case "6":
						url = "https://www.youtube.com/watch?v=gK5IKEgt7e4&list=RDgK5IKEgt7e4&start_radio=1&ab_channel=NarutoJoeyYugi";
						break;
					default:
						url = "";
						break;
				}

				if (!string.IsNullOrEmpty(url))
				{
					Process.Start(new ProcessStartInfo
					{
						FileName = url,
						UseShellExecute = true
					});
				}
			}

			Pause();
		}

		// helper methods
		static void Pause()
		{
			Console.WriteLine("\nPress Enter to continue...");
			Console.ReadLine();
		}
	}
}