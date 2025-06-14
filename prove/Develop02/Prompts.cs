using System;

class Prompts
{
	private List<string> _promptBank;
	private Random _random;
	public Prompts()
	{
		// Initialize member variables once when the class is instantiated
		_promptBank = new List<string>
				{
						"What is one interesting interaction you had today.",
						"How have you seen the Lord's hand in your life today.",
						"What was the strongest emotional experience and reaction you had today.",
						"What is something you learned today.",
						"What is something you are grateful for today.",
						"What is something you wish you could've changed about today.",
						"What is something you wish you could tell a family member.",
						"Write about today as though you were writing a letter to a friend.",
						"What is the best thing you did or saw today."
				};
		_random = new Random();
	}

	public string GetRandomPrompt()
	{
		int randomIndex = _random.Next(_promptBank.Count);
		return _promptBank[randomIndex];
	}
}
