using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuesstimateScoring
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayGameTitle();
            var numberOfPlayers = GetNumberOfPlayers();
            Console.WriteLine();

            var players = GetPlayerNames(numberOfPlayers);
            Console.WriteLine();

            PlayGame(ref players);
            Console.WriteLine();

            DisplayPlayerInformation(players, true);
            Console.WriteLine();

            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static int GetNumberOfPlayers()
        {
            Console.Write("Input the Number of Players: ");
            return GetNumber();
        }

        private static List<Player> GetPlayerNames(int numberOfPlayers)
        {
            List<Player> players = new List<Player>();
            for (int i = 1; i < numberOfPlayers+1; i++)
            {
                var player = new Player(i);
                Console.Write($"Input the Player #{player.Id} name: ");
                player.Name = GetString();
                players.Add(player);
            }
            return players;
        }

        private static void DisplayPlayerInformation(List<Player> players, bool areFinalScores = false)
        {
            DisplayGameTitle();
            string currentOrFinal = areFinalScores ? "final" : "current";
            Console.WriteLine($"The {currentOrFinal} scores are");
            Console.WriteLine($"-----------------------");
            foreach (var player in players.OrderByDescending(x => x.Score).ToList())
            {
                Console.Write($"{player.Name} has {player.Score} points");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void PlayGame(ref List<Player> players)
        {
            int roundNumber = 0;
            ConsoleKeyInfo keyPressed = new ConsoleKeyInfo();
            while (keyPressed.Key != ConsoleKey.N)
            {
                Console.Clear();
                if (keyPressed.Key == ConsoleKey.S)
                {
                    DisplayPlayerInformation(players);
                }
                else
                {
                    roundNumber++;
                    DisplayGameTitle();
                    Console.WriteLine($"------ Ready to round #{roundNumber} ------");
                    Console.WriteLine();

                    Shuffle(ref players);
                    var guesses = GetPlayerGuesses(players);

                    Console.WriteLine();
                    Console.Write("The actual value is: ");
                    int actualValue = GetNumber();
                    Console.WriteLine();

                    CalculateVariances(ref guesses, actualValue);

                    DisplayPlayerGuesses(players, guesses.OrderBy(x => x.PlayerId).ToList());
                    Console.WriteLine();

                    ScoreRound(ref players, guesses);
                }
                Console.WriteLine("Do you want to play another round?");
                Console.WriteLine("[Y] Play Another    [N] to Quit     [S] for Current Scores");
                keyPressed = Console.ReadKey(false);
                Console.WriteLine();
            }
        }

        private static void CalculateVariances(ref List<Guess> guesses, int actualValue)
        {
            foreach (var guess in guesses)
            {
                var difference = Math.Abs(guess.GuessValue - actualValue);
                guesses.Where(x => x.PlayerId == guess.PlayerId).First().OverUnderValue = difference;
            }
        }

        private static void Shuffle(ref List<Player> players)
        {
            Random rng = new Random();
            int n = players.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Player value = players[k];
                players[k] = players[n];
                players[n] = value;
            }
        }

        private static List<Guess> GetPlayerGuesses(List<Player> players)
        {
            List<Guess> guesses = new List<Guess>();
            foreach (var player in players)
            {
                var guess = new Guess(player.Id);
                Console.Write($"What is {player.Name}'s guess? ");
                guess.GuessValue = GetNumber();
                guesses.Add(guess);
            }
            return guesses;
        }

        private static void DisplayPlayerGuesses(List<Player> players, List<Guess>guesses)
        {
            Console.WriteLine("The results of the round were");
            Console.WriteLine("-----------------------------");
            foreach (var guess in guesses)
            {
                var playerName = players.Where(x => x.Id == guess.PlayerId).FirstOrDefault().Name;
                Console.WriteLine($"{playerName}'s guess was {guess.GuessValue} with a difference of {guess.OverUnderValue}");
            }
        }

        private static void ScoreRound(ref List<Player> players, List<Guess> guesses)
        {
            var win = guesses.OrderBy(x => x.OverUnderValue).ToList()[0].PlayerId;
            var place = guesses.OrderBy(x => x.OverUnderValue).ToList()[1].PlayerId;
            var show = guesses.OrderBy(x => x.OverUnderValue).ToList()[2].PlayerId;
            players.Where(x => x.Id == win).First().Score += 5;
            players.Where(x => x.Id == place).First().Score += 3;
            players.Where(x => x.Id == show).First().Score += 1;
        }

        private static void DisplayGameTitle()
        {
            Console.WriteLine("-------------------- Welcome to Guesstimate Scoring --------------------");
            Console.WriteLine();
        }

        private static int GetNumber()
        {
            string value = string.Empty;
            while (value == string.Empty)
            {
                value = Console.ReadLine();
                if (Regex.Replace(value, @"[^\d]", "") == string.Empty) { value = string.Empty; }
            }
            return Convert.ToInt32(value);
        }

        private static string GetString()
        {
            string value = string.Empty;
            while (value == string.Empty)
            {
                value = Console.ReadLine();
            }
            return value;
        }
    }
}
