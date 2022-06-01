using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpApps
{
    internal class RockPaperScissors_v2
    {
        public void RunApp()
        {
            Console.Write("Running Rock, Paper Scissors...");
            Console.WriteLine();
            Console.WriteLine();

            do
            {
                Console.WriteLine();
                Console.WriteLine();

                RPSType? player1Value = GetPlayer1Value();
                RPSType player2Value = GetPlayer2Value();

                // should we exit the app
                if (player1Value == null) return;

                // find out who won
                string winner = GetWinner(player1Value.Value, player2Value);

                Console.WriteLine("Player 1 chose " + player1Value.Value + ", Player 2 chose " + player2Value);
                Console.WriteLine(winner);

            } while (true);
        }

        private string GetWinner(RPSType player1Value, RPSType player2Value)
        {
            const string player1Wins = "The winner is Player 1";
            const string player2Wins = "The winner is Player 2";
            const string itsADraw = "It's a draw!";

            if (player1Value == RPSType.Rock && player2Value == RPSType.Rock) return itsADraw;
            if (player1Value == RPSType.Rock && player2Value == RPSType.Paper) return player2Wins;
            if (player1Value == RPSType.Rock && player2Value == RPSType.Scissors) return player1Wins;

            if (player1Value == RPSType.Paper && player2Value == RPSType.Rock) return player1Wins;
            if (player1Value == RPSType.Paper && player2Value == RPSType.Paper) return itsADraw;
            if (player1Value == RPSType.Paper && player2Value == RPSType.Scissors) return player2Wins;

            if (player1Value == RPSType.Scissors && player2Value == RPSType.Rock) return player2Wins;
            if (player1Value == RPSType.Scissors && player2Value == RPSType.Paper) return player1Wins;
            if (player1Value == RPSType.Scissors && player2Value == RPSType.Scissors) return itsADraw;

            return "";
        }

        private RPSType? GetPlayer1Value()
        {
            do
            {
                Console.WriteLine("Player 1, select (r)ock, (p)aper or (s)cissors");

                string? playerChoice = Console.ReadLine();

                bool isPlayerChoiceValid = playerChoice == "r" || playerChoice == "p" || playerChoice == "s" || playerChoice == "exit";

                if (isPlayerChoiceValid)
                {
                    switch (playerChoice)
                    {
                        case "r": return RPSType.Rock;
                        case "p": return RPSType.Paper;
                        case "s": return RPSType.Scissors;
                        case "exit": return null;
                    }
                }
                else
                {
                    Console.WriteLine("INVALID SELECTION!! Try again.");
                    Console.WriteLine();
                }
            } while (true);
        }

        private RPSType GetPlayer2Value()
        {
            Random rnd = new();
            int computerChoice = rnd.Next(1, 4);

            switch (computerChoice)
            {
                case 1: return RPSType.Rock;
                case 2: return RPSType.Paper;
                default: return RPSType.Scissors;
            }
        }

        enum RPSType
        {
            Rock,
            Paper,
            Scissors
        }
    }
}