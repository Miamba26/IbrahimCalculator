using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpApps
{
    internal class RockPaperScissors
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
                Console.WriteLine("Choose rock, paper or scissors");
                string? userChoice = Console.ReadLine();
                if (userChoice != null && userChoice == "exit") return;

                Random rnd = new();
                int computerChoice = rnd.Next(1, 4);

                if (computerChoice == 1)
                {
                    if (userChoice == "rock")
                    {
                        Console.WriteLine("The computer chose rock");
                        Console.WriteLine("It is a tie ");
                    }
                    else if (userChoice == "paper")
                    {
                        Console.WriteLine("The computer chose paper");
                        Console.WriteLine("It is a tie ");
                    }
                    else if (userChoice == "scissors")
                    {
                        Console.WriteLine("The computer chose scissors");
                        Console.WriteLine("It is a tie ");
                    }
                    else
                    {
                        Console.WriteLine("Choose rock, paper or scissors");
                    }

                }
                else if (computerChoice == 2)
                {
                    if (userChoice == "rock")
                    {
                        Console.WriteLine("The computer chose paper");
                        Console.WriteLine("You lose, paper beat rock");

                    }
                    else if (userChoice == "paper")
                    {
                        Console.WriteLine("The computer chose scissors");
                        Console.WriteLine("You lose, scissors beat paper ");

                    }
                    else if (userChoice == "scissors")
                    {
                        Console.WriteLine("The computer chose rock");
                        Console.WriteLine("You lose, rock beats scissors");
                    }
                    else
                    {
                        Console.WriteLine("Choose rock, paper or scissors");
                    }
                }
                else if (computerChoice == 3)
                {
                    if (userChoice == "rock")
                    {
                        Console.WriteLine("The computer chose scissors");
                        Console.WriteLine("You win, rock beats scissors");
                    }
                    else if (userChoice == "paper")
                    {
                        Console.WriteLine("The computer chose rock");
                        Console.WriteLine("You win, paper beats rock");
                    }
                    else if (userChoice == "scissors")
                    {
                        Console.WriteLine("The computer chose paper");
                        Console.WriteLine("You win, scissors beat paper");
                    }
                    else
                    {
                        Console.WriteLine("Choose rock, paper or scissors");
                    }
                }
            } while (true);
        }
    }
}
