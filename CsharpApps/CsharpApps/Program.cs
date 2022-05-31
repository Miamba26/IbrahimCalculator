namespace CsharpApps
{
    internal class Program
    {
        public static void Main()
        {
            Calculator calculator = new();
            calculator.RunApp();

            RockPaperScissors rps = new();
            rps.RunApp();
        }
    }
}