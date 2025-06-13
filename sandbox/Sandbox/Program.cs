using System;
using System.Threading;

class Program
{
	static void Main()
	{
		int seconds = 30;
		string[] spinner = { "|", "/", "-", "\\" };
		int spinnerIndex = 0;

		Console.CursorVisible = false;
		Console.WriteLine();

		for (int i = seconds; i >= 0; i--)
		{
			for (int j = 0; j < 10; j++) // 10 spinner steps per second
			{
				Console.SetCursorPosition(0, 0);
				Console.Write($"[{spinner[spinnerIndex]}] Countdown: {i:D2}s ");
				spinnerIndex = (spinnerIndex + 1) % spinner.Length;
				Thread.Sleep(100); // 100ms per frame, 10 frames per second
			}
		}

		Console.SetCursorPosition(0, 1);
		Console.WriteLine("Done!");
	}
}