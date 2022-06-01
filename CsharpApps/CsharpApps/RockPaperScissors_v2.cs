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

                if (player1Value==null) return;
                
            } while (true);
        }

        enum RPSType
        {
            Rock,
            Paper,
            Scissors
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
    }
}


//switch (random.Next(1, 4))
//{
//    case 1:
//        computer = "rock";
//        break;

//    case 2:
//        computer = "paper";
//        break;

//    case 3:
//        computer = "scissors";
//        break;
//}


//switch (player)
//{
//    case "rock":
//        if (computer == "rock")
//        {
//            Console.WriteLine("It's a draw!");
//        }
//        else if (computer == "paper")
//        {
//            Console.WriteLine("You lose!");
//        }
//        else
//        {
//            Console.WriteLine("You win!");
//        }
//        break;

//    case "paper":
//        if (computer == "rock")
//        {
//            Console.WriteLine("You win!");
//        }
//        else if (computer == "paper")
//        {
//            Console.WriteLine("It's a draw!");
//        }
//        else
//        {
//            Console.WriteLine("You lose!");
//        }
//        break;
//
//   case "scissors":
//        if (computer == "rock")
//        {
//            Console.WriteLine("You lose!");
//        }
//        else if (computer == "paper")
//        {
//            Console.WriteLine("You win!");
//        }
//        else
//        {
//            Console.WriteLine("It's a draw!");
//        }
//        break;
//}