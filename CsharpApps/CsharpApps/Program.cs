namespace CsharpApps
{
    internal class Program
    {
        public static void Main()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Which Program would you like to run? (1-Calculator, 2-RockPaperScissors, 3-TicTacToe, 4-Snake): ");
                string? app = Console.ReadLine();

                switch (app)
                {
                    case "1":
                        Calculator calculator = new();
                        calculator.RunApp();
                        break;

                    case "2":
                        RockPaperScissors_v3 rps = new();
                        rps.RunApp();
                        break;

                    case "3":
                        TicTacToe ttt = new();
                        ttt.RunApp();
                        break;

                    case "4":
                        Snake snake = new();
                        snake.RunApp();
                        break;

                    default:
                        Console.WriteLine("Please choose a valid app");
                        break;
                }

                Console.Clear();
            } while (true);
        }
    }
}