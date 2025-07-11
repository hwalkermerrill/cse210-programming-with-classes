using System;
using System.Diagnostics;
using System.Threading;

class Program
{
	static void Main()
	{
        Console.WriteLine("Hello! Ready for a surprise?");
        System.Threading.Thread.Sleep(2000); // Pause for suspense

        Console.WriteLine("Here we go...");
        System.Threading.Thread.Sleep(1000);

        // Open the Rick Roll video in the default web browser
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
            UseShellExecute = true
        });

        Console.WriteLine("Enjoy the music!");
    }
}
	// {
	// 	int seconds = 30;
	// 	string[] spinner = { "|", "/", "-", "\\" };
	// 	int spinnerIndex = 0;

	// 	Console.CursorVisible = false;
	// 	Console.WriteLine();

	// 	for (int i = seconds; i >= 0; i--)
	// 	{
	// 		for (int j = 0; j < 10; j++) // 10 spinner steps per second
	// 		{
	// 			Console.SetCursorPosition(0, 0);
	// 			Console.Write($"[{spinner[spinnerIndex]}] Countdown: {i:D2}s ");
	// 			spinnerIndex = (spinnerIndex + 1) % spinner.Length;
	// 			Thread.Sleep(100); // 100ms per frame, 10 frames per second
	// 		}
	// 	}

	// 	Console.SetCursorPosition(0, 1);
	// 	Console.WriteLine("Done!");
	// }
