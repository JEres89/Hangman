using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
	class Executioner
	{
		private StringBuilder guesses = new StringBuilder();
		private char[] word;
		private char[] guess;

		public Gallows gallows;

		internal Executioner(string word)
		{
			this.word = word.ToUpper().ToCharArray();
			gallows = new Gallows(this.word.Length);
		}
		internal void run()
		{
			Console.WriteLine("Let's play Hangman!\nPress any button to continue");

			Console.ReadKey(true);

			while (true)
			{
				PrintGame();

				guess = Console.ReadLine().Trim().ToUpper().ToCharArray();

				if (Guess(guess))
				{
					GameOver();
					break;
				}
			}

			Console.ReadKey(true);
		}

		private bool Guess(char c)
		{
			if (guesses.ToString().Contains(c))
			{
				Console.WriteLine("You have already guessed this letter, try again.");
				Console.ReadKey(true);
			}
			else
			{
				guesses.Append(c);

				bool match = false;

				for (int i = 0; i < word.Length; i++)
				{
					if (word[i] == c)
					{
						if (gallows.Success(c, i, false))
						{
							return true;
						}
						match = true;
					}
				}

				if (match == false)
				{
					if(gallows.Fail())
					{
						return true;
					}
				}
			}

			return false;
		}
		private bool Guess(char[] w)
		{
			//Console.WriteLine(w);
			//Console.ReadKey(true);

			if (w.Length == 0)
			{
				Console.WriteLine("No letters found, try again.");
				Console.ReadKey(true);
				return false;
			}
			if(w.Length == 1)
			{
				return Guess(w[0]);
			}

			if(string.Equals(w.ToString(), word.ToString()))
			{
				//guesses.Append(w);
				for (int i = 0; i < w.Length; i++)
				{
					gallows.Success(w[i], i, true);
				}
				return true;
			}
			else
			{
				return gallows.Fail();
			}
		}

		private void PrintGame()
		{
			Console.Clear();
			gallows.PrintGallows();
			gallows.PrintGuess();
			Console.SetCursorPosition(0, 18);
			Console.WriteLine(guesses.ToString());

			Console.Write("\nMake your guess, single letter or whole word: ");
		}
		
		private void GameOver()
		{
			Console.SetCursorPosition(Console.WindowWidth / 2 - 4, 22);
			if (gallows.win)
			{
				gallows.PrintGuess();
				Console.WriteLine("Victory!!\n");
				Console.WriteLine(
					"You took a total of {0} guesses, {1}", 
					guesses.Length, 
					guesses.Length > 6 ? "close call, you can do better!" : "well done!");
			}
			else
			{
				gallows.PrintGallows();
				Console.WriteLine("\nYou are hanged.");
			}
		}
	}
}
