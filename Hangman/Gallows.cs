using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
	class Gallows
	{
		private readonly static string[] GallowStates;

		private int progress = 0;
		
		private char[] currentGuess;

		private readonly int lineOfGallows = 1;
		private readonly int lineOfGuess = 16;

		internal bool win = false;
		internal bool easymode;

		internal Gallows(int wordLength, bool easymode)
		{
			currentGuess = new char[wordLength];
			this.easymode = easymode;

			for (int i = 0; i < wordLength; i++)
			{
				currentGuess[i] = '_';
			}
		}

		internal bool SubmitGuess(char guess, int pos, bool wordGuess)
		{
			currentGuess[pos] = guess;

			if (wordGuess)
			{
				Console.CursorLeft = lineOfGuess;
				Console.CursorTop = 0;

				win = true;
				return true;
			}

			if (GuessCompleted())
			{
				win = true;
				return true;
			}
			if(easymode)
			{
				return false;
			}
			return Fail();
		}

		internal bool Fail()
		{
			progress++;
			if (progress == 10)
			{
				return true;
			}
			return false;
		}

		internal bool GuessCompleted()
		{
			foreach (var c in currentGuess)
			{
				if (c == '_')
				{
					return false;
				}
			}
			return true;
		}

		internal void PrintGallows()
		{
			PrintAt(GallowStates[progress], lineOfGallows,false);
		}
		
		internal void PrintGuess()
		{
			StringBuilder s = new StringBuilder();

			foreach (char c in currentGuess)
			{
				s.Append(" ").Append(c);
			}
			PrintAt(s.ToString(), lineOfGuess, win);
		}
		private void PrintAt(string s, int line, bool slow)
		{
			int x = Console.CursorLeft;
			int y = Console.CursorTop;

			Console.CursorLeft = 0;
			Console.CursorTop = line;
			
			if(slow)
			{
				int og_size = Console.CursorSize;
				Console.CursorSize = 100;
				foreach (char c in s)
				{
					Console.Write(c);
					System.Threading.Thread.Sleep(150);
				}
				Console.CursorSize = og_size;
			}
			else
			{
				Console.WriteLine(s);
			}

			Console.SetCursorPosition(x, y);
		}
		static Gallows()
		{
			GallowStates = new string[11];

			GallowStates[0] = "\n\n\n\n\n\n\n\n";
			GallowStates[1] = "\n\n\n\n\n\n         \\\\\n          \\\\\n";
			GallowStates[2] = "\n\n\n\n\n\n //      \\\\\n//        \\\\\n";
			GallowStates[3] = "\n\n\n\n\n\n //      |\\\n//      /|\\\\\n";
			GallowStates[4] = "\n\n\n\n\n\n //      |\\-\\\n//      /|\\\\-\\\n";
			GallowStates[5] = "\n\n\n\n\n  __________\n //      |\\-\\\n//      /|\\\\-\\\n";
			GallowStates[6] = "\n         |\n         |\n         |\n         |\n  _______|__\n //      |\\-\\\n//      /|\\\\-\\\n";
			GallowStates[7] = "     _____\n         |\n         |\n         |\n         |\n  _______|__\n //      |\\-\\\n//      /|\\\\-\\\n";
			GallowStates[8] = "     _____\n     |   |\n     o   |\n         |\n     _   |\n  __|_|__|__\n //      |\\-\\\n//      /|\\\\-\\\n";
			GallowStates[9] = "     _____\n     |   |\n     O   |\n    /|\\  |\n    /_\\  |\n  __|_|__|__\n //      |\\-\\\n//      /|\\\\-\\\n";
			GallowStates[10] = "     _____\n     |   |\n     |   |\n     O   |\n    /|\\  |\n  _ / \\ _|__\n //|   | |\\-\\\n//      /|\\\\-\\\n";


		}
	}
}
