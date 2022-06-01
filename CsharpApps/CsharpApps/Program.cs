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
                Console.Write("Which Program would you like to run? (1-Calculator, 2-RockPaperScissors): ");
                string? app = Console.ReadLine();

                switch (app)
                {
                    case "1":
                        Calculator calculator = new();
                        calculator.RunApp();
                        break;

                    case "2":
                        RockPaperScissors_v2 rps = new();
                        rps.RunApp();
                        break;

                    default:
                        Console.WriteLine("Please choose a valid app");
                        break;
                }
            } while (true);
        }
    }
}