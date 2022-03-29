using System;
using System.Collections.Generic;

namespace Hangman
{
	class Hangman
	{
		private static Executioner executioner;

		private static string[] dictionary;
		static Random rand = new Random();

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine("Playing hangman...");
			System.Threading.Thread.Sleep(1000);

			while (true)
			{
				StartQuery();

				executioner = new Executioner(GetWord());

				executioner.run();
				Console.Clear();
				Console.Write("One more? Y/N: ");
				if (Console.ReadKey().Key != ConsoleKey.Y )
				{
					break;
				}
			}
		}

		private static void StartQuery()
		{
			Console.Write("\nWould you like to play hangman? Y/N: ");

			ConsoleKeyInfo query = Console.ReadKey();

			if (query.Key == ConsoleKey.Y)
			{
				Console.WriteLine("\n\nGreat! Welcome to the gallows.");
			}
			else
			{
				Console.WriteLine("\n\nWell, if you're being hanged your opinion doesn't really matter.");
			}
			Console.ReadKey(true);
			Console.Clear();
		}

		private static string GetWord()
		{
			return dictionary[rand.Next(dictionary.Length)];
		}
		static Hangman()
		{
			dictionary = new string[]
			{ 
				"accurate",
				"tribe",
				"table",
				"identification",
				"remind",
				"achievement",
				"tell",
				"protest",
				"winter",
				"thinker",
				"exhibition",
				"fashionable",
				"fuss",
				"ridge",
				"practice",
				"mobile",
				"deserve",
				"owner",
				"transition",
				"monkey",
				"criminal",
				"swear",
				"crusade",
				"live",
				"factor",
				"conglomerate",
				"angle"
			};
		}
	}
}
