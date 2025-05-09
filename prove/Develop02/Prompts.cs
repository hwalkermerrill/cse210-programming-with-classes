using System;

public class Prompts
{
	public string Prompt()
	{
		// Create Prompt Bank;
		List<string> PromptBank = new List<string>();
		PromptBank.Add("Write about one interesting interaction you had today.");
		PromptBank.Add("Write about how you saw the Lord's hand in your life today.");
		PromptBank.Add("Write about the strongest emotional experience and reaction you had today.");
		PromptBank.Add("Write about something you learned today.");
		PromptBank.Add("Write about something you are grateful for today.");
		PromptBank.Add("Write about something you wish you could've changed about today.");
		PromptBank.Add("Write about something you wish you could tell a family member.");
		PromptBank.Add("Write about today as though you were writing a letter to a friend.");
		PromptBank.Add("Write about the best thing you did or saw today.");

		Random random = new Random();
		int randomIndex = random.Next(PromptBank.Count);
		string randomPrompt = PromptBank[randomIndex];
		return randomPrompt;
	}
}