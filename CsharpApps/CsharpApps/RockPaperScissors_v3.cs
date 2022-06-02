using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpApps
{
    internal class RockPaperScissors_v3
    {
        List<RPSType> _player1Values = new List<RPSType>();

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
            RPSType? result = null;

            do
            {
                Console.WriteLine("Player 1, select (r)ock, (p)aper or (s)cissors");

                string? playerChoice = Console.ReadLine();

                bool isPlayerChoiceValid = playerChoice == "r" || playerChoice == "p" || playerChoice == "s" || playerChoice == "exit";

                if (isPlayerChoiceValid)
                {
                    switch (playerChoice)
                    {
                        case "r": result = RPSType.Rock; break;
                        case "p": result = RPSType.Paper; break;
                        case "s": result = RPSType.Scissors; break;
                        case "exit": return null;
                    }
                }
                else
                {
                    Console.WriteLine("INVALID SELECTION!! Try again.");
                    Console.WriteLine();
                }
            } while (result == null);

            // add player 1 result to our list
            if (result != null)
            {
                _player1Values.Add(result.Value);
            }

            return result;
        }

        private RPSType GetPlayer2Value()
        {
            if (_player1Values.Count < 4)
            {
                // choose a random number

                Random rnd = new();
                int computerChoice = rnd.Next(1, 4);

                switch (computerChoice)
                {
                    case 1: return RPSType.Rock;
                    case 2: return RPSType.Paper;
                    default: return RPSType.Scissors;
                }
            }
            else
            {
                // use some smart logic to determine what player 1 might have chosen

                return RPSType.Rock;
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