using System;

public class Prompts
{
	public string Prompt()
	{
		// Create Prompt Bank;
		List<string> PromptBank = new List<string>
		{
		"What is one interesting interaction you had today.",
		"How have you seen the Lord's hand in your life today.",
		"What was the strongest emotional experience and reaction you had today.",
		"What is something you learned today.",
		"What is something you are grateful for today.",
		"What is something you wish you could've changed about today.",
		"What is something you wish you could tell a family member.",
		"Write about today as though you were writing a letter to a friend.",
		"What is the best thing you did or saw today.",
		};

		Random random = new Random();
		int randomIndex = random.Next(PromptBank.Count);
		string randomPrompt = PromptBank[randomIndex];
		return randomPrompt;
	}
}