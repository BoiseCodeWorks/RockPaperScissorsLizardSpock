using System;
using System.Collections.Generic;

namespace rps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("I want to play a game...");
            bool playing = true;
            Random random = new Random();
            List<string> choices = new List<string>() { "rock", "paper", "scissors" };
            string compChoice;
            string playerChoice;
            int wins = 0;
            int games = 0;
            Dictionary<string, List<string>> winningCondition = new Dictionary<string, List<string>>(){
                {"rock", new List<string>(){"scissors", "lizard"}},
                {"paper", new List<string>(){"rock", "spock"}},
                {"scissors", new List<string>(){"paper", "lizard"}},
                {"lizard", new List<string>(){"spock", "paper"}},
                {"spock", new List<string>(){"scissors", "rock"}}
            };
            while (playing)
            {
                //generate a random computer choice
                compChoice = choices[random.Next(choices.Count)];
                //get player choice
                Console.Write("Make your choice: ");
                foreach (var choice in winningCondition)
                {
                    Console.Write(" " + choice.Key);
                }
                System.Console.WriteLine("");
                playerChoice = Console.ReadLine().ToLower();
                if (winningCondition.ContainsKey(playerChoice))
                {
                    System.Console.WriteLine("you chose " + playerChoice);
                    System.Console.WriteLine("comp chose " + compChoice);
                    //compare choices to determine winner
                    if (playerChoice == compChoice)
                    {
                        System.Console.WriteLine("TIE");
                    }
                    else if (winningCondition[playerChoice].Contains(compChoice))
                    {
                        System.Console.WriteLine("you win");
                        wins++;
                    }
                    else
                    {
                        System.Console.WriteLine("you lose");
                    }
                    //play again?
                }
                else
                {
                    Console.WriteLine("Cheater");
                }
                games++;
                System.Console.WriteLine("play again? (press 'q' to quit or any other key to play again)");
                ConsoleKeyInfo response = Console.ReadKey();
                if (response.KeyChar == 'q')
                {
                    playing = false;
                }
                Console.Clear();
                System.Console.WriteLine($"You have won {wins} of {games} games");
            }

        }
    }
}
